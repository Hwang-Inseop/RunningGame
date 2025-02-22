using RunningGame.Singleton;

namespace RunningGame.Managers
{
    // 씬 진입 시 MainScene에 대한 초기화를 담당
    public class MainSceneBase : SceneSingleton<MainSceneBase>
    {
        private void Start()
        {
            Init();
        }

        public override void Init()
        {
            // Manger 초기화
            MainPoolManager.Instance.Init();
            MainUIManager.Instance.Init();
            
            // 메인 게임 초기화
            CreatPatternPool();
        }

        private void CreatPatternPool()
        {
            // 스테이지에 맞는 패턴 풀 생성
        }
    }
}