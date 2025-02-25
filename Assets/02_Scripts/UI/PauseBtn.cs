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



    public void PauseGame() // 게임 일시 정지
    {
        isPause = !isPause;
        pauseMenu.SetActive(true);
        // gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
}