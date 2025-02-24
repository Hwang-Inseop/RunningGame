using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool IsEquipped { get; private set; } // 장착 여부
    [SerializeField] private string name; // 이름
    [SerializeField] private string description; // 설명
    [SerializeField] private float intervalTime; // 쿨타임
    [SerializeField] private float duration; // 효과 지속 시간
    [Header("보물 스탯")]
    [SerializeField] private float speed; // 속도 증가량
    [SerializeField] private float healthDrain; // 체력 감소량
    [SerializeField] private bool canRevive; // 부활 가능 여부
#nullable enable
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    [SerializeField] private Transform coinPosition; // 추가 코인 생성 위치

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
            if (extraCoin != null)
            {
                Instantiate(extraCoin, coinPosition.position, Quaternion.identity); //추후 위치 지정
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

