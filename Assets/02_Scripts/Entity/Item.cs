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
    public abstract void ApplyEffect(); // ������ ȿ��

    public void DestroyItem() // ������� �ִϸ��̼� �� Destroy
    {
        animator.SetTrigger("Contact");
        Destroy(gameObject, .1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �÷��̾�� �浹 ��
        {
            ApplyEffect();
            DestroyItem();
        }
    }
}
