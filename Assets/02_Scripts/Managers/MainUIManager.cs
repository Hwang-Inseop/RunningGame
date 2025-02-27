using RunningGame.Singleton;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RunningGame.Managers
{
    // UI와 오브젝트의 중간 매개체 역할을 하는 MainUIManager 클래스
    public class MainUIManager : SceneSingleton<MainUIManager>
    {
        public HPSlider hPSlider;
        public GameObject pauseBtn;
        public GameObject pauseMenu;
        public GameObject gameOverPanel;
        public GameObject treasurePanel;
        private Player player = null;
        private bool isPause = false;

        [Header("점수 표시")]
        public int totalScore = 0;
        public TextMeshProUGUI totalScoreTxt;

        [Header("골드 표시")]
        public int totalGold = 0;
        public TextMeshProUGUI totalGoldTxt;

        public override void Init() //시작시 초기화 
        {
            player = MainSceneBase.Instance.CurrentPlayer;
            int totalGold = 0;
            int totalScore = 0;
            AddScore();
            AddGold();
            hPSlider.Init();
        }

        public void ResumeGame()
        {
            Debug.Log("Click");
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            pauseBtn.SetActive(true);
            isPause = false;
        }

        public void SelectStageBtn() // 스테이지 선택창 
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("LobbyScene");
        }

        public void QuitGame()   // 게임 종료
        {
#if UNITY_EDITOR    //Unity 에디터에서 실행시
            EditorApplication.isPlaying = false;
#else   //실제 빌드된 게임에서 실행시
        Application.Quit();
#endif
        }

        public void AddScore() // 점수 추가
        {
            totalScoreTxt.text = totalScore.ToString();
        }

        public void AddGold() // 재화 추가
        {
            totalGoldTxt.text = totalGold.ToString();
        }
        //public void UnEquip() //장착하지 않은 보물패널 비활성화
        //{

        //}
    }
}