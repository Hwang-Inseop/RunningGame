using DG.Tweening;
using RunningGame.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    private bool isGameOver = false;

    [SerializeField] private CanvasGroup gameOverSelectPanel;
    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    [Header("Fade 효과 시간")]
    [SerializeField] private float fadeTime = 0.5f;
    private void GameOver()
    {    
        if(!isGameOver)
        {
            isGameOver = true;
            gameObject.SetActive(true);
        }
    }
    void Start() 
    {
        foreach (Button button in makeScaleBtn)
        {
            button.onClick.AddListener(() =>
            {
                button.transform.DOKill();
                button.transform.localScale = Vector3.one;

                button.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
            });
        }
        RectTransform rectTransform = gameOverSelectPanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -500f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 10f), fadeTime, false).SetEase(Ease.OutBounce);
        gameOverSelectPanel.DOFade(1, fadeTime);
    }
    public void LoadToLobby()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
        SoundManager.Instance.StopBgm();
    }
}

