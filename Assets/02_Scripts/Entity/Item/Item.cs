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
    public virtual void ApplyEffect(PlayerController player) // 아이템 효과
    {  
        // 플레이어 점수 += Score;
    }
    public void DestroyItem() // 사라지는 애니메이션 후 Destroy
    {
        animator.SetTrigger("Contact");
        Destroy(gameObject, .05f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PlayerController>() != null) // 플레이어와 충돌 시
        {
            if (collision is BoxCollider2D)
            {
                PlayerController player = collision.GetComponentInParent<PlayerController>();
                ApplyEffect(player);
                DestroyItem();
            }
        }
    }
}
