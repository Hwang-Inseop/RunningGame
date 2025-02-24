using JetBrains.Annotations;
using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool pause = false;
    public void PauseGame()
    {
        pause = !pause;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    //UIManager로 이동할 부분
    public void SelectStageBtn() // 스테이지 선택창 
    {
        Time.timeScale = 1f;
        //불러올 씬의 정보로 로드 MainSceneBase.LoadScene(" " );
    }

    // UIManager로 이동할 부분

    public void QuitGame()
    {
        Application.Quit();
    }
}
