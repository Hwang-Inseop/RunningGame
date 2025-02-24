using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

//플레이어가 가질 수 있는 상태 정의: Idle, 땅에 붙어있는 상태, 점프한 상태
public enum PlayerState { idle, isJumping, isSliding }

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 0f; // 기본 점프 힘
    public float maxJumpHoldTime = 0f; // 점프 키 누르는 시간의 한계 시간
    public float doubleJumpForce = 0f; // 더블 점프 힘
    private float jumpHoldTimer = 0f; // 점프 키 누르는 시간

    private bool canDoubleJump = false;
    private bool isJumping = false;
    public bool isSliding = false;
    bool isGrounded = false;    
    public Collider2D normalCollider; // 기본 상태 콜라이더
    public Collider2D slideCollider; // 슬라이딩용 콜라이더

    private Rigidbody2D rb;

    private PlayerState playerState;

    //게임 시작 즉시 Awake에서 상태를 Idle로
    private void Awake()
    {
        ChangeState(PlayerState.idle);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 기본적으로 슬라이딩 콜라이더 비활성화
        slideCollider.enabled = false;
    }

    void Update()
    {
        HandleInput();
        UpdateState();
        Debug.Log(isGrounded);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Z)) ChangeState(PlayerState.isJumping);
        if (Input.GetKeyDown(KeyCode.X)) ChangeState(PlayerState.isSliding);
    }

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
    // 점프 조작 메서드
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded) // Z키 처음 눌렀을 때
        {
            isJumping = true;
            isGrounded = false;
            canDoubleJump = true;
            jumpHoldTimer = 0f;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           
        }
        else if (Input.GetKeyDown(KeyCode.Z) && canDoubleJump && !isGrounded) // 공중에서 한 번 더 점프 가능
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
    void PlayerSlide()
    {
        if (!isSliding)
        {
            isSliding = true;
            normalCollider.enabled = false; // 기본 콜라이더 비활성화
            slideCollider.enabled = true; // 슬라이딩용 콜라이더 활성화
            Debug.Log("Start Slide");
        }
        else if (isSliding)
        {
            isSliding = false;
            normalCollider.enabled = true; // 기본 콜라이더 활성화
            slideCollider.enabled = false; // 슬라이딩용 콜라이더 비활성화
            Debug.Log("End Slide");
        }
    }
    #endregion

    private void ChangeState(PlayerState newState)
    {
        if (newState == playerState) return;
        playerState = newState;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }
}