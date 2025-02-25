using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionItemDatas", menuName = "ScriptableObjects/InteractionItemDatas")]
public class InteractionItemDatas : ScriptableObject
{
    [SerializeField] private List<GameObject> coinPrefabs;
    [SerializeField] private GameObject gemPrefab;
    
    public List<GameObject> GetCoinPrefabs()
    {
        return coinPrefabs;
    }
    
    public GameObject GetGemPrefab()
    {
        return gemPrefab;
    }
}
