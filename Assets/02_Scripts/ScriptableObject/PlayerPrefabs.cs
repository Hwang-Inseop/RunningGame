using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunningGame.Scriptable
{
    [CreateAssetMenu(fileName = "PlayerPrefabs", menuName = "ScriptableObjects/PlayerPrefabs")]
    public class PlayerPrefabs : ScriptableObject
    {
        [SerializeField] private List<GameObject> playerPrefabs;
        
        public GameObject GetPlayerPrefab(int index)
        {
            return playerPrefabs[index];
        }
    }
}