using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure, ICoinGenerator
{
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    [SerializeField] private Transform coinPosition; // 추가 코인 생성 위치

    public void GenerateCoin()
    {
        if (extraCoin != null && coinPosition != null)
        {
            Instantiate(extraCoin, coinPosition.position, Quaternion.identity);
        }
    }
}
