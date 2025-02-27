using RunningGame.Entity;
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
        GameObject playerSpawnPos = GameObject.Find("Grid");
        coinPosition = playerSpawnPos.transform;
        //coinPosition.position += new Vector3(5, 0,0);   
        coinPosition.SetParent(playerSpawnPos.transform);
    }
    public override void ApplyEffect(Player player)
    {
        if (extraCoin != null &&  !hasSpawned)
        {
            StartCoroutine(GenerateCoin(player));
        }
    }

    private IEnumerator GenerateCoin(Player player)
    {
        hasSpawned = true;
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            GameObject newCoin = Instantiate(extraCoin, coinPosition.position, Quaternion.identity);
            newCoin.transform.SetParent(coinPosition);
            Debug.Log("코인 생성");
            StartCoroutine(Magnetic(newCoin.transform, player.transform));

        }
    }
    public IEnumerator Magnetic(Transform coin, Transform player)
    {
        Debug.Log("코루틴");
        while (coin != null)
        {
            float duration = 1f; // 이동하는 데 걸리는 시간
            float elapsedTime = 0f;

            Vector3 startPos = coin.position;
            Vector3 targetPos = player.position;

            while (elapsedTime < duration && player != null)
            {
                coin.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
