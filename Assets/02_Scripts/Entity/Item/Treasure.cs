using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool IsEquipped { get; private set; } // ���� ����
    [SerializeField] private string name; // �̸�
    [SerializeField] private string description; // ����
    [SerializeField] private float intervalTime; // ��Ÿ��
    [SerializeField] private float duration; // ȿ�� ���� �ð�
    [Header("���� ����")]
    [SerializeField] private float speed; // �ӵ� ������
    [SerializeField] private float healthDrain; // ü�� ���ҷ�
    [SerializeField] private bool canRevive; // ��Ȱ ���� ����
#nullable enable
    [SerializeField] private GameObject extraCoin; // �߰� ���� ����
    [SerializeField] private Transform coinPosition; // �߰� ���� ���� ��ġ

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
            if (extraCoin != null)
            {
                Instantiate(extraCoin, coinPosition.position, Quaternion.identity); //���� ��ġ ����
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

