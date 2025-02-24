using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool IsEquipped { get; private set; } // ���� ����
    [SerializeField] private string name; // �̸�
    [SerializeField] private string description; // ����
    [Header("���� ����")]
    [SerializeField] private float speed; // �ӵ� ������
    [SerializeField] private float healthDrain; // ü�� ���ҷ�
    [SerializeField] private bool canRevive; // ��Ȱ ���� ����

    public void Equip()
    {
        if (!IsEquipped)
        {
            IsEquipped = true;
            // �÷��̾� �����ؼ� �߰� ���� ����
            if (canRevive)
            {
                // ���� ���� �� ü�� �޾ƿͼ� ��Ȱ
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

