using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHP; // 최대 HP
    public int currentHP; // 현재 HP
    
    public float hpDrainInterval = 1f; // 체력 지속 소모 시간 간격 (1초)

    public int damage;
    
    private bool damaged = false; // 대미지 입은 상태, true 되면 체력 감소, 잠시간 무적화
    public float invincibleTime; // 무적 시간
    
    void Start()
    {
        currentHP = maxHP; // 게임 시작시 HP MAX
        StartCoroutine(DrainHp()); // 지속 소모 시작
    }
    
    void Update()
    {
        
    }

    IEnumerator DrainHp()
    {
        while (currentHP > 0)
        {
            yield return new WaitForSeconds(hpDrainInterval);
            TakeDamage(damage);
            Debug.Log("HP: " + currentHP);

        }
    }
    
    // 장애물과 충돌하면 대미지, 잠시 무적
    private void OnCollisionTrigger2D(Collider2D collision)
    {
        if(!damaged && collision.gameObject.CompareTag("Obstacle"))
            TakeDamage(10);
    }
    
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
    
    void Die()
    {
        Debug.Log("Die");
    }
}
