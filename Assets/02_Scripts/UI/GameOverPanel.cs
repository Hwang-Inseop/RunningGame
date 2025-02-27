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
    [SerializeField] private CanvasGroup gameOverSelectPanel;
    [SerializeField] private Image characterImg;
    [SerializeField] private TextMeshProUGUI totalScoreTxt;
    [SerializeField] private TextMeshProUGUI totalGoldTxt; 

    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    [Header("Fade 효과 시간")]
    [SerializeField] private float fadeTime = 0.5f;

    public void GameOver()
    {
        SoundManager.Instance.PlaySfx(SoundType.GameOverBgm, 0.1f);
        gameObject.SetActive(true);
        if (GameManager.Instance.firstCharacterInfo != null)
        {
            Debug.Log("제대로 연결됨.");
            characterImg.sprite = GameManager.Instance.firstCharacterInfo.Photo;
            UpdateStatus();
        }
        else
        {
            gameObject.SetActive(false);
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

        RectTransform rectTransform = gameOverSelectPanel.GetComponent<RectTransform>();  //게임패널 애니메이션
        rectTransform.transform.localPosition = new Vector3(0f, -500f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 10f), fadeTime, false).SetEase(Ease.OutBounce);
        gameOverSelectPanel.DOFade(1, fadeTime);

        RectTransform imgRect = characterImg.GetComponent<RectTransform>(); //이미지 애니메이션
        imgRect.localPosition = new Vector3(0f, -500f, 0f); //게임패널과 동일하게 
        imgRect.DOAnchorPos(new Vector2(0f, 10f), fadeTime, false).SetEase(Ease.OutBounce); 
    }

    public void LoadToLobby()
    {
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        SoundManager.Instance.StopBgm();
    }
    public void UpdateStatus()
    {
        totalScoreTxt.text = MainUIManager.Instance.totalScore.ToString();
        totalGoldTxt.text = MainUIManager.Instance.totalGold.ToString();
    }
}