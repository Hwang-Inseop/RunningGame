using RunningGame.Singleton;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

namespace RunningGame.Managers
{
    // UI와 오브젝트의 중간 매개체 역할을 하는 MainUIManager 클래스
    public class MainUIManager : SceneSingleton<MainUIManager>
    {
        private bool isPause = false;
        private float hp;

        public GameObject pauseMenu;

        [Header("점수 표시")]
        public int totalScore = 0;
        private int score = 0;
        public TextMeshProUGUI totalScoreTxt;

        [Header("골드 표시")]
        public int totalGold = 0;
        private int gemAmount = 0;
        public TextMeshProUGUI totalGoldTxt;

        public override void Init()
        {
            // 시작할 때 필요한 초기화
        }
        public void ResumeGame()
        {
            Debug.Log("Click");
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            gameObject.SetActive(true);
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
            totalScore += score;
            totalScoreTxt.text = totalScore.ToString();
        }

        public void AddGold() // 재화 추가
        {
            Debug.Log("골드 추가");
            totalGold += gemAmount;
            totalGoldTxt.text = totalGold.ToString();
        }
        public void LoadToLobby()
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(0);
        }
    }
}

        
