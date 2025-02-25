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
        private bool isPause = false;
        private PlayerController player;
        public GameObject pauseBtn;
        public GameObject pauseMenu;
        public Item item;
        public GameObject gameOverPanel;

        [Header("점수 표시")]
        public int totalScore = 0;
        public TextMeshProUGUI totalScoreTxt;

        [Header("골드 표시")]
        public int totalGold = 0;
        public TextMeshProUGUI totalGoldTxt;

        [Header("체력 표시")]
        private float hp;
        public Slider healthSlider;
        

        public override void Init()
        {
            // 시작할 때 필요한 초기화
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
            SceneManager.LoadScene("CharacterScene");
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
            Debug.Log("점수 추가");
            
            totalScoreTxt.text = totalScore.ToString();
        }

        public void AddGold() // 재화 추가
        {
            Debug.Log("골드 추가");
            totalGoldTxt.text = totalGold.ToString();
        }
        public void OpenPanel()
        {
            gameOverPanel.SetActive(true);
        }
    }
}

        
