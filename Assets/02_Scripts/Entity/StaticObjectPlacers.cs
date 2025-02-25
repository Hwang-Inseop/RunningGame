using System;
using System.Collections.Generic;
using RunningGame.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class StaticObjectPlacers : MonoBehaviour
{
    [SerializeField] private List<TilemapObjectPlacer> tilemapObjectPlacers;

    public void AddGameStartListener(UnityEvent unityEvent)
    {
        for (int i = 0; i < tilemapObjectPlacers.Count; i++)
        {
            unityEvent.AddListener(tilemapObjectPlacers[i].PlaceObject);
            tilemapObjectPlacers[i].Init();
        }
    }
}
