using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool IsEquipped { get; private set; } // 장착 여부
    [SerializeField] private string name; // 이름
    [SerializeField] private string description; // 설명
    [SerializeField] protected float intervalTime; // 쿨타임
    [SerializeField] private float duration; // 효과 지속 시간
    [Header("보물 스탯")]
    [SerializeField] private float speed; // 속도 증가량
    [SerializeField] private float healthDrain; // 체력 감소량
    [SerializeField] private int canRevive; // 부활 가능 횟수


    public void Equip()
    {
        if (!IsEquipped)
        {
            IsEquipped = true;
            // 플레이어 참조해서 추가 스탯 적용
            if (canRevive > 0)
            {
                // Player 부활 가능 횟수 += canRevive
            }
        }
    }

    public void Unequip()
    {
        if (IsEquipped)
        {
            IsEquipped = false;
            // Equip() 로직 반대로
            if(canRevive > 0)
            {
                // Player 부활 가능 횟수 -= canRevive
            }
        }
    }
}


