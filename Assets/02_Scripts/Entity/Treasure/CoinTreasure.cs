using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTreasure : Treasure, ICoinGenerator
{
    [SerializeField] private GameObject extraCoin; // �߰� ���� ����
    [SerializeField] private Transform coinPosition; // �߰� ���� ���� ��ġ

    public void GenerateCoin()
    {
        if (extraCoin != null && coinPosition != null)
        {
            Instantiate(extraCoin, coinPosition.position, Quaternion.identity);
        }
    }
}
