using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public abstract void ApplyEffect(); // 아이템 효과

    public void DestroyItem() // 사라지는 애니메이션 후 Destroy
    {
        animator.SetTrigger("Contact");
        Destroy(gameObject, .1f);
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
