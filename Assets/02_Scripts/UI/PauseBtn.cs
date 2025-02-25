#if UNITY_EDITOR
using UnityEditor;
#endif
using DG.Tweening;
using JetBrains.Annotations;
using RunningGame.Managers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    [Header("일시정지 버튼")]
    public GameObject pauseMenu;
    private bool isPause = false;

    //UIManager로 이동할 부분
    [Header("게임 점수")]
    public int totalScore;
    public int currentScore = 0;
    public TextMeshProUGUI totalScoreTxt;

    [Header("얻은 재화")]
    public int totalGold;
    public int currentgold = 0;
    public TextMeshProUGUI totalGoldTxt;

    private float hp;

    public void PauseGame() // 게임 일시 정지
    {
        isPause = !isPause;
        pauseMenu.SetActive(true);
        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    #region UI매니저로 이동할 부분
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
        totalScore += currentScore;
        totalScoreTxt.text = totalScore.ToString();
    }

    public void AddGold() // 재화 추가
    {
        Debug.Log("골드 추가");
        totalGold += currentgold;
        totalGoldTxt.text = totalGold.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //  onDamage(데미지변수 입력);
        }
    }
}
#endregion