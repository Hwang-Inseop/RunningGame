using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure
{
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    [SerializeField] private Transform coinPosition; // 추가 코인 생성 위치
    private bool hasSpawned = false;

    public override void ApplyEffect(PlayerController player)
    {
        if (extraCoin != null && coinPosition != null && !hasSpawned)
        {
            StartCoroutine(GenerateCoin());
        }
    }

    private IEnumerator GenerateCoin()
    {
        hasSpawned = true;
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            Instantiate(extraCoin, coinPosition.position, Quaternion.identity);

        }
    }
}
