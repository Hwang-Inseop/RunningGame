using RunningGame.Scriptable;
using RunningGame.Singleton;
using RunningGame.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace RunningGame.Managers
{
    public class MainSceneBase : SceneSingleton<MainSceneBase>
    {
        [Header("Components")]
        [SerializeField] private PatternLooper patternLooper;
        [SerializeField] private StaticObjectPlacers staticObjectPlacer;
        
        [Header("MainScene Datas")]
        [SerializeField] private InteractionItemDatas interactionItemDatas;
        [SerializeField] private PatternDatas patternDatas;
        
        [Header("MainScene Transform")]
        [SerializeField] private Transform LoopableObjectRoot;
        [SerializeField] private Transform playerSpawnPoint;
        
        [Header("Event")]
        [SerializeField] private UnityEvent onGameStart = new();
        private int selectedStage;
        private bool isGameStart;
        
        private void Start()
        {
            Init();
        }

        public override void Init()
        {
            // Manager 초기화
            MainPoolManager.Instance.Init();
            MainUIManager.Instance.Init();
            
            // 메인 게임 초기화
            CreatPatternPool();
            CreateItemPool();
            patternLooper.Init(selectedStage);
            staticObjectPlacer.AddGameStartListener(onGameStart);
            
            // 게임 시작
            onGameStart?.Invoke();
            isGameStart = true;
        }

        private void CreatPatternPool()
        {
            // TODO: GameManager에서 선택한 스테이지 정보 가져오기
            
            selectedStage = 1;
            var patternList = patternDatas.GetPatternList(selectedStage);
            for (int i = 0; i < patternList.Count; i++)
            {
                var prefab = patternList[i];
                MainPoolManager.Instance.CreatePool(prefab);
            }
        }

        private void CreateItemPool()
        {
            var coinList = interactionItemDatas.GetCoinPrefabs();
            for (int i = 0; i < coinList.Count; i++)
            {
                var prefab = coinList[i];
                MainPoolManager.Instance.CreatePool(prefab, 50);
            }

            var heartList = interactionItemDatas.GetHeartPrefabs();
            for (int i = 0; i < heartList.Count; i++)
            {
                var prefab = heartList[i];
                MainPoolManager.Instance.CreatePool(prefab);
            }
            
            var gemPrefab = interactionItemDatas.GetGemPrefab();
            MainPoolManager.Instance.CreatePool(gemPrefab, 10);
        }

        private void SpawnPlayer()
        {
            // TODO: 플레이어 스폰 구현
        }

        public bool IsStart()
        {
            return isGameStart;
        }

        public Transform GetLoopableRoot()
        {
            return LoopableObjectRoot;
        }
        
        public void AddGameStartListener(UnityAction action)
        {
            onGameStart.AddListener(action);
        }
    }
}