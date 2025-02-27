using RunningGame.Entity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StaticObjectPlacers : MonoBehaviour
{
    [SerializeField] private List<TilemapObjectPlacer> stage01_Placers;
    [SerializeField] private List<TilemapObjectPlacer> stage02_Placers;
    [SerializeField] private List<TilemapObjectPlacer> stage03_Placers;

    public void ExecuteStaticObjectPlace(int selectedStage)
    {
        switch (selectedStage)
        {
            case 1:
                for (int i = 0; i < stage01_Placers.Count; i++)
                {
                    var placer = stage01_Placers[i];
                    placer.PlaceObject();
                }
                break;
            case 2:
                for (int i = 0; i < stage02_Placers.Count; i++)
                {
                    var placer = stage02_Placers[i];
                    placer.PlaceObject();
                }
                break;
            case 3:
                for (int i = 0; i < stage03_Placers.Count; i++)
                {
                    var placer = stage03_Placers[i];
                    placer.PlaceObject();
                }
                break;
            default:
                Debug.LogError("StaticObjectPlacers : Invalid stage key");
                break;
        }
    }
}