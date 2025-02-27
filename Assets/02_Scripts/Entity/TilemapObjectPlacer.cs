using System;
using RunningGame.Managers;
using RunningGame.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapObjectPlacer : MonoBehaviour
{
    [SerializeField] private ObjectPlacerType objectPlacerType;
    [SerializeField] private PatternType patternType;
    
    private readonly Dictionary<PatternType, bool> existPatternDict = new();
    private Dictionary<Vector3, string> objectPosDict;
    private Tilemap tilemap;
    private TilemapRenderer tilemapRenderer;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    private void Start()
    {
        if (objectPlacerType == ObjectPlacerType.Static) return;
        if (existPatternDict.ContainsKey(patternType)) return;

        MainSceneBase.Instance.AddPatternSpawnListener(PlaceObject);
        existPatternDict.Add(patternType, true);
    }

    public void PlaceObject()
    {
        if (tilemap == null)
        {
            Debug.LogError("TilemapObjectPlacer : Tilemap is null");
            return;
        }

        if (objectPosDict != null)
        {
            foreach (var pair in objectPosDict)
            {
                var pos = pair.Key;
                var poolKey = pair.Value;
                var coinObj = MainPoolManager.Instance.Spawn(poolKey, pos, Quaternion.identity);
                coinObj.transform.parent = MainSceneBase.Instance.GetLoopableRoot();
            }
            return;
        }

        // 사용하는 영역만큼 줄이기
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        objectPosDict = new Dictionary<Vector3, string>();

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                // 타일이 존재하지 않으면 패스
                Vector3Int cellPosition = new(x, y, 0);
                if (!tilemap.HasTile(cellPosition)) continue;

                // 타일 이름으로 풀 키 가져오기
                var tileName = tilemap.GetTile(cellPosition).name;
                var poolKey = tileName.GetPoolKey();

                // 타일 위치에 오브젝트 생성
                Vector3 worldPos = tilemap.CellToWorld(cellPosition) + tilemap.tileAnchor;
                var coinObj = MainPoolManager.Instance.Spawn(poolKey, worldPos, Quaternion.identity);
                coinObj.transform.parent = MainSceneBase.Instance.GetLoopableRoot();
                objectPosDict.Add(worldPos, poolKey);
            }
        }

        tilemapRenderer.enabled = false;
    }

    public enum ObjectPlacerType
    {
        Static,
        Dynamic,
    }

    public enum PatternType
    {
        Pattern1,
        Pattern2,
        Pattern3,
        Pattern4,
        Pattern5,
    }
}