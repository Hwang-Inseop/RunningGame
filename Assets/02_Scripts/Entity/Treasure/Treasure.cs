using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool IsEquipped { get; private set; } // ���� ����
    [SerializeField] private string name; // �̸�
    [SerializeField] private string description; // ����
    [SerializeField] protected float intervalTime; // ��Ÿ��
    [SerializeField] private float duration; // ȿ�� ���� �ð�
    [Header("���� ����")]
    [SerializeField] private float speed; // �ӵ� ������
    [SerializeField] private float healthDrain; // ü�� ���ҷ�
    [SerializeField] private int canRevive; // ��Ȱ ���� Ƚ��


    public void Equip(Player player)
    {
        if (!IsEquipped)
        {
            IsEquipped = true;
            // �÷��̾� �����ؼ� �߰� ���� ����
            if (canRevive != 0)
            {
                player.reviveCount += canRevive;
            }
        }
    }

    public void Unequip()
    {
        if (IsEquipped)
        {
            IsEquipped = false;
            // Equip() ���� �ݴ��
        }
    }
}


