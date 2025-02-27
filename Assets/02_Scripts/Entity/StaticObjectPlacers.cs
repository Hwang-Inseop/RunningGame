using RunningGame.Entity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StaticObjectPlacers : MonoBehaviour
{
    [SerializeField] private List<TilemapObjectPlacer> stage01_Placers;
    [SerializeField] private List<TilemapObjectPlacer> stage02_Placers;
    [SerializeField] private List<TilemapObjectPlacer> stage03_Placers;

    public void AddGameStartListener(UnityEvent unityEvent, int selectedStage)
    {
        switch (selectedStage)
        {
            case 1:
                for (int i = 0; i < stage01_Placers.Count; i++)
                {
                    unityEvent.AddListener(stage01_Placers[i].PlaceObject);
                }
                break;
            case 2:
                for (int i = 0; i < stage02_Placers.Count; i++)
                {
                    unityEvent.AddListener(stage02_Placers[i].PlaceObject);
                }
                break;
            case 3:
                for (int i = 0; i < stage03_Placers.Count; i++)
                {
                    unityEvent.AddListener(stage03_Placers[i].PlaceObject);
                }
                break;
            default:
                Debug.LogError("StaticObjectPlacers : Invalid stage key");
                break;
        }
    }
}