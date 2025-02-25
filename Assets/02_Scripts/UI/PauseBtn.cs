using JetBrains.Annotations;
using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    public Text totalScoreTxt;

    [Header("얻은 재화")]
    public int totalGold;
    public int currentgold = 0;
    public Text totalGoldTxt;

    private float hp;
    public void PauseGame() // 게임 일시 정지
    {
        isPause = !isPause;
        if (isPause)
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
    }

    // UIManager로 이동해야 할 부분
    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    //UIManager로 이동할 부분
    public void SelectStageBtn() // 스테이지 선택창 
    {
        Time.timeScale = 1f;
        //불러올 씬의 정보로 로드 MainSceneBase.LoadScene(" " );
    }

    // UIManager로 이동할 부분

    public void QuitGame()   // 게임 종료
    {
        Application.Quit();
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
    //private int OnDamage(int damage)
    //{
    //  hp -= damage
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
           //  onDamage(데미지변수 입력);
        }
    }
}
