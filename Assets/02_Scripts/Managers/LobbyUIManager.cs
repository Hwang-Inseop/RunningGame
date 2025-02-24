using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    [Header("Fade 효과 적용시킬 Panel")]
    public CanvasGroup fadePanel = new CanvasGroup();
    public GameObject fadePanelGo;

    [Header("Fade 효과 시간")]
    [SerializeField]            
    private float fadeTime = 0.5f;

    [Header("스테이지 설명 텍스트")]
    public Text stageDescriptionTxt;

    [Header("스테이지 설명 이미지")]
    public Image stageDescriptionImg;

    [Header("체크 이미지 리스트")]
    public List<GameObject> checkImg = new List<GameObject>();

    //초기 설정
    void Start()
    {
        fadePanelGo.SetActive(true);
        fadePanel.alpha = 0f;
        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);

        PlayerPrefs.SetInt("choosedStage", 1);


        foreach (Button button in makeScaleBtn)
        {
            button.onClick.AddListener(() =>
            {
                button.transform.DOKill();
                button.transform.localScale = Vector3.one;

                button.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
            });
        }
    }

    public void PanelFadeIn()
    {
        ControlPanel(0f, true);
        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        fadePanel.DOFade(1, fadeTime);
    }

    public void PanelFadeOut()
    {
        ControlPanel(1f, false);
        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        fadePanel.DOFade(0, fadeTime);
    }

    void ControlPanel(float alpha, bool isInteractable)
    {
        fadePanel.alpha = alpha;
        fadePanel.interactable = isInteractable;
    }

    public void ShowStageDescription(StageInfo stageInfo)
    {
        PlayerPrefs.SetInt("choosedStage", stageInfo.StageNum);
        stageDescriptionTxt.text = stageInfo.StageDescription;
        stageDescriptionImg.sprite = stageInfo.Background;
    }

    public void CheckSelectedStage()
    {
        for(int i = 1; i <= checkImg.Count; i++)
        {
            if (PlayerPrefs.GetInt("choosedStage") == i)
            {
                checkImg[i - 1].SetActive(true);
            }
            else
            {
                checkImg[i - 1].SetActive(false);
            }
        }
    }
}
