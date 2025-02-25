using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Animator animator;
    [SerializeField] protected int score;
    public virtual int Score => score;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public virtual void ApplyEffect() // 아이템 효과
    {  
        // 플레이어 점수 += Score;
    }
    public void DestroyItem() // 사라지는 애니메이션 후 Destroy
    {
        // animator.SetTrigger("Contact");
        Destroy(gameObject, .05f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 플레이어와 충돌 시
        {
            ApplyEffect();
            DestroyItem();
        }
    }
}
