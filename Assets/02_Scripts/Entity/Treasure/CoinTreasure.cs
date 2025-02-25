using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure, ICoinGenerator
{
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    [SerializeField] private Transform coinPosition; // 추가 코인 생성 위치
    private bool hasSpawned = false;

    private void Update()
    {
        if (IsEquipped && !hasSpawned) 
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
        hasSpawned = true;
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            Instantiate(extraCoin, coinPosition.position, Quaternion.identity);
            //게임 끝나면 break
        }
    }
}
