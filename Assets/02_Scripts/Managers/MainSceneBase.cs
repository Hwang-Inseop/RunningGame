using RunningGame.Entity;
using RunningGame.Scriptable;
using RunningGame.Singleton;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RunningGame.Managers
{
    public class MainSceneBase : SceneSingleton<MainSceneBase>
    {
        [Header("Map Controll")]
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

        public Player CurrentPlayer { get; private set; }
        private readonly Dictionary<PatternType, bool> existPatternEventDict = new();
        private int selectedStage;
        private bool isGameStart;
        private bool isSecondPlayer;
        
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
            // 플레이어 스폰
            SpawnPlayer();

            // Manager 초기화
            MainPoolManager.Instance.Init();
            MainUIManager.Instance.Init(); // UI매니저에서 플레이어 할당
            
            // 메인 게임 초기화
            CreatPatternPool();
            CreateItemPool();
            patternLooper.Init(selectedStage);
            staticObjectPlacer.AddGameStartListener(onGameStart, selectedStage);
            
            // 게임 시작
            onGameStart?.Invoke();
            PlayBgm();
            isGameStart = true;
        }

        private void CreatPatternPool()
        {
            // TODO: 씬 로드하고 수정
            // selectedStage = GameManager.Instance.stageinfo.StageNum;
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
            // TODO: 씬 로드하고 수정
            int selectedPlayer = 0;
            // if (!isSecondPlayer)
            //     selectedPlayer = GameManager.Instance.firstCharacterInfo.CharacterNum;
            // else
            //     selectedPlayer = GameManager.Instance.secondCharacterInfo.CharacterNum;
            
            selectedPlayer = 1;
            var obj = playerPrefabs.GetPlayerPrefab(selectedPlayer - 1);
            var player = Instantiate(obj, playerSpawnPoint);
            CurrentPlayer = player.GetComponent<Player>();
            CurrentPlayer.transform.localPosition = Vector3.zero;
            CurrentPlayer.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }

        private void PlayBgm()
        {
            switch (selectedStage)
            {
                case 1:
                    SoundManager.Instance.PlayBgm(SoundType.Stage01Bgm, 0.1f);
                    break;
                case 2:
                    SoundManager.Instance.PlayBgm(SoundType.Stage02Bgm, 0.1f);
                    break;
                case 3:
                    SoundManager.Instance.PlayBgm(SoundType.Stage03Bgm, 0.1f);
                    break;
                default:
                    Debug.LogError("MainSceneBase : Invalid stage key");
                    break;
            }
        }

        public void PlayerDeath()
        {
            // TODO: 2p 죽으면 브금 멈춰
            if (!isSecondPlayer)
            {
                Destroy(CurrentPlayer.gameObject);
                SpawnPlayer();
                isSecondPlayer = true;
            }
            else
            {
                // 게임 오버
            }
        }

        public bool IsStart()
        {
            return isGameStart;
        }
        
        public Transform GetLoopableRoot()
        {
            return loopableObjectRoot;
        }
        
        public bool TryAddPatternEventDict(PatternType type)
        {
            return existPatternEventDict.TryAdd(type, true);
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