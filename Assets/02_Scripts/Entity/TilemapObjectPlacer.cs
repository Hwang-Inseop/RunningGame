using RunningGame.Managers;
using RunningGame.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

namespace RunningGame.Entity
{
    public class TilemapObjectPlacer : MonoBehaviour
    {
        [SerializeField] private ObjectPlacerType objectPlacerType;
        [SerializeField] private GameObject coinTilemap;

        private Tilemap tilemap;
        private TilemapRenderer tilemapRenderer;
        private UnityEvent onPatternPlaced;

        private void Awake()
        {
            tilemap = coinTilemap.GetComponent<Tilemap>();
            tilemapRenderer = coinTilemap.GetComponent<TilemapRenderer>();

            if (objectPlacerType == ObjectPlacerType.Static) return;
            onPatternPlaced = new UnityEvent();
            onPatternPlaced.AddListener(PlaceObject);
        }

        public void InvokePatternPlaced()
        {
            onPatternPlaced?.Invoke();
        }

        public void PlaceObject()
        {
            if (tilemap == null)
            {
                Debug.LogError("TilemapObjectPlacer : Tilemap is null");
                return;
            }

            // 사용하는 영역만큼 줄이기
            tilemap.CompressBounds();
            BoundsInt bounds = tilemap.cellBounds;

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
                }
            }

            tilemapRenderer.enabled = false;
        }
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