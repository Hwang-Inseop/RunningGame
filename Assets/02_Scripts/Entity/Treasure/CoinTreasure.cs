using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure, ICoinGenerator
{
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    private Vector3 coinPosition = Vector3.zero;
    private void Start()
    {
        GenerateCoin();
    }
    public void GenerateCoin()
    {
        if (extraCoin != null)
        {
            StartCoroutine(SpawnCoin());
        }
    }

    private IEnumerator SpawnCoin()
    {
        Debug.Log("spawn");
        Instantiate(extraCoin, coinPosition, Quaternion.identity);
        yield return new WaitForSeconds(intervalTime);
    }
}
