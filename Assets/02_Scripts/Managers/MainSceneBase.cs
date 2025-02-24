using RunningGame.Scriptable;
using RunningGame.Singleton;
using RunningGame.Utils;
using UnityEngine;

namespace RunningGame.Managers
{
    // 씬 진입 시 MainScene에 대한 초기화를 담당
    public class MainSceneBase : SceneSingleton<MainSceneBase>
    {
        [SerializeField] private PatternDatas patternDatas;
        [SerializeField] private PatternLooper patternLooper;
        [SerializeField] private Transform playerSpawnPoint;
        private int selectedStage;
        
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
            patternLooper.Init(selectedStage);
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

        private void SpawnPlayer()
        {
            // TODO: 플레이어 스폰 구현
        }
    }
}