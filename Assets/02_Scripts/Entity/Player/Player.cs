using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

//플레이어가 가질 수 있는 상태 정의: 땅에서 달리는 상태, 땅에 붙어있는 상태, 점프한 상태
public enum PlayerState {isRunning, isJumping, isSliding}

public class Player : MonoBehaviour
{
    private bool isRunning = false; // idle 바닥에서 달리는 중인 상태
    
    public float jumpForce = 0f; // 기본 점프 힘
    public float maxJumpHoldTime = 0f; // 점프 키 누르는 시간의 한계 시간
    public float doubleJumpForce = 0f; // 더블 점프 힘
    private float jumpHoldTimer = 0f; // 점프 키 누르는 시간
    private bool canDoubleJump = false; // 더블 점프 가능한 상태
    private bool isJumping = false; //점프중인 상태
    
    public bool isSliding = false; // 슬라이딩중인 상태
    public Collider2D normalCollider; // 기본 상태 콜라이더
    public Collider2D slideCollider; // 슬라이딩용 콜라이더
    
    public int maxHP; // 최대 HP
    public int currentHP; // 현재 HP
    public int damage; // 대미지 수치
    public float hpDrainInterval = 1f; // 체력 지속 소모 시간 간격 (1초)
    protected bool damaged = false; // 대미지 입은 상태, true 되면 체력 감소, 잠시간 무적화
    public float invincible; //무적 시간
    
    protected bool die = false; // 사망 상태
    public bool isDropped = false;
    public int canRevive;
    
    private Rigidbody2D rb;
    private Animator animator;
    
    private PlayerState playerState;

    private Treasure treasure; // 착용 보물
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChangeState(PlayerState.isRunning); //게임 시작 즉시 Awake에서 상태를 isRunning로
    }

    protected virtual void Start()
    {
        slideCollider.enabled = false; // 기본적으로 슬라이딩 콜라이더 비활성화
        TreasureInst();
        currentHP = maxHP; // 게임 시작시 HP MAX
        StartCoroutine(DrainHp()); // 체력 지속 소모 시작
    }
    
    protected virtual void Update()
    {
        HandleInput();
        UpdateState();
    }

    protected virtual void ActivateAbility()
    {
        
    }

    /// <summary>
    /// 키 입력을 받으면 상태 전이 실행
    /// </summary>
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Z)) ChangeState(PlayerState.isJumping);
        if (Input.GetKeyDown(KeyCode.X)) ChangeState(PlayerState.isSliding);
    }
    
    /// <summary>
    /// 상태 전이되면 조작 메서드를 실행
    /// </summary>
    private void UpdateState()
    {
        switch (playerState)
        {
            case PlayerState.isJumping:
                PlayerJump();
                break;
            case PlayerState.isSliding:
                PlayerSlide();
                break;
        }
    }

    #region 점프 조작
    /// <summary>
    /// 점프 조작 메서드
    /// </summary>
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isRunning) // Z키 눌렀을 때 && 땅에 붙어있을 때
        {
            isRunning = false;
            isJumping = true;
            canDoubleJump = true;
            jumpHoldTimer = 0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
            Debug.Log("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.Z) && canDoubleJump) // 공중에서 한 번 더 점프 가능
        {
            canDoubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
            Debug.Log("DoubleJump");
        }

        // 점프 버튼 입력 시간 비례 점프 높이 조절 (최대 `maxJumpHoldTime` 까지)
        if (Input.GetKey(KeyCode.Z) && isJumping)
        {
            if (jumpHoldTimer < maxJumpHoldTime)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * 2f);
                jumpHoldTimer += Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z)) // 점프 키에서 손을 떼면 멈춤
        {
            isJumping = false;
        }
    }
    #endregion

    #region 슬라이드 조작
    /// <summary>
    /// 슬라이드 조작 메서드
    /// </summary>
    void PlayerSlide()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isSliding && !isJumping)
        {
            isSliding = true;
            normalCollider.enabled = false; // 기본 콜라이더 비활성화
            slideCollider.enabled = true; // 슬라이딩용 콜라이더 활성화
            animator.SetBool("isSliding", true);
            Debug.Log("Start Slide");
        }
        else if (Input.GetKeyUp(KeyCode.X) && isSliding)
        {
            isSliding = false;
            normalCollider.enabled = true; // 기본 콜라이더 활성화
            slideCollider.enabled = false; // 슬라이딩용 콜라이더 비활성화
            animator.SetBool("isSliding", false);
            Debug.Log("End Slide");
        }
    }
    #endregion
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")) // Ground 태그 오브젝트와 닿아있으면 바닥에서 달리는 상태
            isRunning = true;
        Debug.Log("isRunning");
        animator.SetBool("isRunning", true);
        animator.SetBool("isJumping", false);
    }

    /// <summary>
    /// 상태 전이
    /// </summary>
    /// <param name="newState"></param>
    private void ChangeState(PlayerState newState)
    {
        if (newState == playerState) return;
        playerState = newState;
    }
    
    /// <summary>
    /// 달리는동안 체력 지속 소모
    /// </summary>
    /// <returns></returns>
    protected IEnumerator DrainHp()
    {
        while (currentHP > 0)
        {
            yield return new WaitForSeconds(hpDrainInterval);
            TakeDamage(damage);
            Debug.Log("HP: " + currentHP);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 장애물과 충돌하면 대미지, 잠시 무적
        if (!damaged && collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(10);
            Debug.Log("Collision, Damaged -10");
            StartCoroutine(Invincible());
        }
        
        // 낙사 구간에 빠지면 Die
        if (collision.gameObject.CompareTag("DropZone"))
        {
            isDropped = true;
            Die();
        }
    }

    /// <summary>
    /// 장애물과 충돌 시 invincible 시간동안 무적 상태
    /// </summary>
    /// <returns></returns>
    IEnumerator Invincible()
    {
        damaged = true;
        float invincibleTime = invincible;
        Debug.Log("Invincible Start");
        
        yield return new WaitForSeconds(invincibleTime);
        
        damaged = false;
        Debug.Log("Invincible End");
    }
    
    /// <summary>
    /// 대미지 처리하는 메서드
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        if (!damaged)
        {
            currentHP -= damage;

            if (currentHP <= 0)
            {
                Die();
            }
        }
    }
    
    /// <summary>
    /// 사망 시 호출되는 메서드
    /// </summary>
    void Die()
    {
        if (canRevive == 0)
        {
        die = true;
        Debug.Log("Die");
        }
    }

    // 보물 관련
    public void TreasureInst()
    {
        Treasure treasure = GameManager.Instance.GetTreasureInstance();
        if (treasure == null) Debug.Log("null");
        Debug.Log(treasure);
        if (treasure != null)
        {
            Equip(treasure);
        }
    }
    public void Equip(Treasure t)
    {
        if (treasure != null)
        {
            Unequip();
        }
        treasure = t;
        treasure.Equip(this);

    }

    public void Unequip()
    {
        if (treasure != null)
        {
            treasure.Unequip();
            treasure = null;
        }
    }
}