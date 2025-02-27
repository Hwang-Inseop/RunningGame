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
    private bool isPause = false;
    public GameObject pauseMenu;
    public void PauseGame() // 게임 일시 정지
    {
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.1f);
        Debug.Log("게임 일시 정지");
        isPause = !isPause;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}