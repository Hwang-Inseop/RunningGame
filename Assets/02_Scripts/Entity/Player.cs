using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    public int maxHealth;
    public int reviveCount;
    private Vector3 originPosition;
    private Treasure treasure;
    public Button trasureBtn;
    public bool isStart = false;
    private PlayerController playerController;
    private void Start()
    {
        originPosition = transform.position;
        treasure = null;
        reviveCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathPlatform"))
        {
            Debug.Log("Die");
            Revive();
        }
    }

    public void Revive() // 부활
    {

        if (reviveCount > 0)
        {
            int currentHealth = health;
            reviveCount--;

            health = 0;
            //구멍구출 애니메이션
            //기존 포지션 복귀 
            transform.position = originPosition;
            Debug.Log(transform.position);
            health = currentHealth;
        }
        else
        {
            //Death
            health = 0;
        }
    }

    public void Equip(Treasure t)
    {
        if(treasure != null)
        {
            Unequip();
        }
        treasure = t;
        treasure.Equip(playerController);
        if(treasure != null) Debug.Log(treasure);
    }

    public void Unequip()
    {
        if(treasure != null)
        {
            treasure.Unequip();
            treasure = null;
        }
    }
}
