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
        public GameOverPanel gameOverPanel;
        private Player player = null;
        private bool isPause = false;

        [Header("점수 표시")]
        public int totalScore;
        public TextMeshProUGUI totalScoreTxt;

        [Header("골드 표시")]
        public int totalGold;
        public TextMeshProUGUI totalGoldTxt;

        [Header("보물 표시")]
        public GameObject treasurePanel;
        public Image equippedTreasureImage;

        public override void Init() //시작시 초기화 
        {
            player = MainSceneBase.Instance.CurrentPlayer;
            totalGold = 0;
            totalScore = 0;
            AddScore();
            AddGold();
            UpdateTresurePanel();
        }

        public void ResumeGame()
        {
            SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.1f);
            Debug.Log("Click");
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            pauseBtn.SetActive(true);
            isPause = false;
        }

        public void SelectStageBtn() // 스테이지 선택창 
        {
            SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.1f);
            Time.timeScale = 1f;
            SceneManager.LoadScene("LobbyScene");
            SoundManager.Instance.StopBgm();
        }

        public void QuitGame()   // 게임 종료
        {
            SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.1f);
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

        public void SetCollectedGold()
        {
            GameManager.Instance.JemCount += totalGold;
        }
        
        public void UpdateTresurePanel() // 보물 패널
        {
            if (GameManager.Instance.treasureInfo != null)
            {
                Debug.Log("제대로 연결됨.");
                treasurePanel.SetActive(true);
                equippedTreasureImage.sprite = GameManager.Instance.treasureInfo.TreasureImg;
            }
            else
            {
                treasurePanel.SetActive(false);
            }
        }

    }
    
}