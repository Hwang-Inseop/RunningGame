using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool IsEquipped { get; private set; } // 장착 여부
    [SerializeField] private string name; // 이름
    [SerializeField] private string description; // 설명
    [Header("보물 스탯")]
    [SerializeField] private float speed; // 속도 증가량
    [SerializeField] private float healthDrain; // 체력 감소량
    [SerializeField] private bool canRevive; // 부활 가능 여부

    public void Equip()
    {
        if (!IsEquipped)
        {
            IsEquipped = true;
            // 플레이어 참조해서 추가 스탯 적용
            if (canRevive)
            {
                // 낙사 했을 때 체력 받아와서 부활
            }
        }
    }

    public void Unequip()
    {
        if (IsEquipped)
        {
            IsEquipped = false;
            // Equip() 로직 반대로
        }
    }
}

