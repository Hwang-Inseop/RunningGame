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
        [SerializeField] private PlayerPrefabs playerPrefabs;
        
        [Header("MainScene Transform")]
        [SerializeField] private Transform loopableObjectRoot;
        [SerializeField] private Transform playerSpawnPoint;
        
        [Header("Event")]
        [SerializeField] private UnityEvent onGameStart = new();
        [SerializeField] private UnityEvent onPatternSpawn = new();
        
        private int selectedStage;
        private bool isGameStart;
        
        private void Start()
        {
            Init();
        }
        
        private void OnDestroy()
        {
            onGameStart.RemoveAllListeners();
            onPatternSpawn.RemoveAllListeners();
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
            staticObjectPlacer.AddGameStartListener(onGameStart, selectedStage);
            
            // 게임 시작
            onGameStart?.Invoke();
            SpawnPlayer();
            PlayBgm();
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
                MainPoolManager.Instance.CreatePool(prefab, 100);
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
            // TODO: GameManager에서 선택한 캐릭터 정보 가져오기

            var obj = playerPrefabs.GetPlayerPrefab(0);
            var player = Instantiate(obj, playerSpawnPoint);
            player.transform.localPosition = Vector3.zero;
            player.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }

        private void PlayBgm()
        {
            switch (selectedStage)
            {
                case 1:
                    SoundManager.Instance.PlayBgm(SoundType.Stage01Bgm, 0.3f);
                    break;
                case 2:
                    SoundManager.Instance.PlayBgm(SoundType.Stage02Bgm, 0.3f);
                    break;
                case 3:
                    SoundManager.Instance.PlayBgm(SoundType.Stage03Bgm, 0.3f);
                    break;
                default:
                    Debug.LogError("MainSceneBase : Invalid stage key");
                    break;
            }
        }

        public void GameOver()
        {
            // TODO: 2p 죽으면 브금 멈춰
            // if (!isSecondPlayer)
            // 
            // else
            // GameOver
        }

        public bool IsStart()
        {
            return isGameStart;
        }

        public Transform GetLoopableRoot()
        {
            return loopableObjectRoot;
        }

        #region Event
        public void AddPatternSpawnListener(UnityAction action)
        {
            onPatternSpawn.AddListener(action);
        }
        
        public void InvokePatternSpawn()
        {
            onPatternSpawn?.Invoke();
        }
        #endregion
    }
}