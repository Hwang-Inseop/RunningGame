using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure, ICoinGenerator
{
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    [SerializeField] private Transform coinPosition; // 추가 코인 생성 위치

    private void Start()
    {
        if (IsEquipped)
        {
            GenerateCoin();
        }
    }
    public void GenerateCoin()
    {
        if (extraCoin != null && coinPosition != null)
        {
            StartCoroutine(SpawnCoin());
        }
    }

    private IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            Instantiate(extraCoin, coinPosition.position, Quaternion.identity);
        }
    }
}
