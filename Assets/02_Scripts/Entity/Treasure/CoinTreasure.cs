using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure
{
    [SerializeField] private GameObject extraCoin; // 추가 코인 생성
    private Transform coinPosition; // 추가 코인 생성 위치
    private bool hasSpawned = false;
    private void Start()
    {
        coinPosition.position = transform.position;
        coinPosition.position = transform.position + new Vector3(5, 0, 0);
    }
    public override void ApplyEffect(Player player)
    {
        if (extraCoin != null &&  !hasSpawned)
        {
            StartCoroutine(GenerateCoin());
        }
    }

    private IEnumerator GenerateCoin()
    {
        Debug.Log("코루틴");
        hasSpawned = true;
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            Instantiate(extraCoin, coinPosition.position, Quaternion.identity);
            Debug.Log("코인 생성");

        }
    }
}
