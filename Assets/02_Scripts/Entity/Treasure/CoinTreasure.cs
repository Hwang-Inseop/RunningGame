using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure, ICoinGenerator
{
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    private Vector3 coinPosition = Vector3.zero;
    private bool hasSpawned = false;
    private void Update()
    {
        if(IsEquipped && !hasSpawned)
            GenerateCoin();
    }
    public void GenerateCoin()
    {
        if (extraCoin != null)
        {
            StartCoroutine(SpawnCoin());
            hasSpawned = true;
        }

    }

    private IEnumerator SpawnCoin()
    {
        Debug.Log("spawn");
        Instantiate(extraCoin, coinPosition, Quaternion.identity);
        yield return new WaitForSeconds(intervalTime);
        hasSpawned = false;
    }
}
