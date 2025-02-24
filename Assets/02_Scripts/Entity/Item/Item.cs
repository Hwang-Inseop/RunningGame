using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Animator animator;
    public virtual int Score { get; }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public virtual void ApplyEffect() // ������ ȿ��
    {  
        // �÷��̾� ���� += Score;
    }
    public void DestroyItem() // ������� �ִϸ��̼� �� Destroy
    {
        animator.SetTrigger("Contact");
        Destroy(gameObject, .05f);
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
