using DG.Tweening;
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
        [SerializeField] private GameObject footHold;
        
        [Header("MainScene Datas")]
        [SerializeField] private InteractionItemDatas interactionItemDatas;
        [SerializeField] private PatternDatas patternDatas;
        [SerializeField] private PlayerPrefabs playerPrefabs;
        
        [Header("MainScene Transform")]
        [SerializeField] private Transform loopableObjectRoot;
        [SerializeField] private Transform playerSpawnPoint;
        
        [Header("Event")]
        [SerializeField] private UnityEvent onGameStart = new();

        public Player CurrentPlayer { get; private set; }
        private List<int> patternList = new();
        private int selectedStage;
        private bool isGameStart;
        private bool isSecondPlayer = false;
        
        private void Start()
        {
            Init();
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
            staticObjectPlacer.ExecuteStaticObjectPlace(selectedStage);
            
            // 게임 시작
            onGameStart?.Invoke();
            PlayBgm();
            Time.timeScale = 1f;
            isGameStart = true;
        }

        private void CreatPatternPool()
        {
            selectedStage = GameManager.Instance.stageinfo.StageNum;
            var patterns = patternDatas.GetPatternList(selectedStage);
            for (int i = 0; i < patterns.Count; i++)
            {
                var prefab = patterns[i];
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
            int selectedPlayer = 0;
            if (!isSecondPlayer)
                selectedPlayer = GameManager.Instance.firstCharacterInfo.CharacterNum;
            else
                selectedPlayer = GameManager.Instance.secondCharacterInfo.CharacterNum;
            
            var obj = playerPrefabs.GetPlayerPrefab(selectedPlayer - 1);
            var player = Instantiate(obj, playerSpawnPoint);
            CurrentPlayer = player.GetComponent<Player>();
            CurrentPlayer.transform.localPosition = Vector3.zero;
            CurrentPlayer.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            SetPlayerCurrentHp();
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
            if (!isSecondPlayer && GameManager.Instance.secondCharacterInfo != null)
            {
                isSecondPlayer = true;
                Destroy(CurrentPlayer.gameObject);
                SpawnPlayer();
                SpawnFootHold();
                return;
            }

            GameOver();
        }
        
        private void SpawnFootHold()
        {
            var footHoldObj = Instantiate(footHold, loopableObjectRoot);
            footHoldObj.transform.parent = loopableObjectRoot;
            footHoldObj.transform.position = CurrentPlayer.transform.position + Vector3.down;
            footHoldObj.transform.localScale = Vector3.one;
        }

        private void SetPlayerCurrentHp()
        {
            if (!isSecondPlayer)
            {
                CurrentPlayer.currentHP = CurrentPlayer.maxHP;
            }
            else
            {
                CurrentPlayer.currentHP = CurrentPlayer.maxHP / 2;
            }
        }

        private void GameOver()
        {
            isGameStart = false;
            SoundManager.Instance.StopBgm();
            MainUIManager.Instance.gameOverPanel.GameOver();
        }

        public bool IsStart()
        {
            return isGameStart;
        }

        public bool IsSecondPlayer()
        {
            return isSecondPlayer;
        }
        
        public Transform GetLoopableRoot()
        {
            return loopableObjectRoot;
        }
    }
}