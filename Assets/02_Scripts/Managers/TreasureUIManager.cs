using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class TreasureUIManager : MonoBehaviour
{
    [Header("보물 선택 Panel")]
    public CanvasGroup treasureSelectPanel = new CanvasGroup();

    [Header("상점 주인 역할 Alien")]
    public CanvasGroup alienImg = new CanvasGroup();

    [Header("Fade 효과 적용시킬 Panel")]
    public CanvasGroup fadePanel = new CanvasGroup();
    public GameObject fadePanelGo;

    [Header("Fade 효과 시간")]
    [SerializeField]
    private float fadeTime = 0.5f;

    [Header("TreasureInfo")]
    public List<TreasureInfo> treasureInfos = new List<TreasureInfo>();

    [Header("보물 정보 패널을 띄우는 Button")]
    public List<Button> displayInfoBtns = new List<Button>();

    [Header("보물 이미지 들아갈 Image")]
    public Image treasureImg;

    [Header("보물 이름 들아갈 Text")]
    public TextMeshProUGUI treasureNameTxt;

    [Header("보물 능력 들아갈 Text")]
    public TextMeshProUGUI treasureAbilityTxt;

    [Header("체크 이미지")]
    public List<GameObject> checkImgs = new List<GameObject>();

    private int currentTreasureNum = 0;

    void Start()
    {
        fadePanelGo.SetActive(true);
        fadePanel.alpha = 0f;
        fadePanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, -1000f, 0f);

        treasureSelectPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, -1000f, 0f);
        treasureSelectPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, -25f), fadeTime, false).SetEase(Ease.InOutQuint);
        treasureSelectPanel.DOFade(1, fadeTime);

        alienImg.GetComponent<RectTransform>().transform.localPosition = new Vector3(-120f, -2000f, 0f);
        alienImg.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-120f, -150f), fadeTime * 2, false).SetEase(Ease.OutQuad);
        alienImg.DOFade(1, fadeTime);

    }

    //씬 로드
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Fade In 효과
    public void PanelFadeIn()
    {
        ControlPanel(0f, true);
        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        fadePanel.DOFade(1, fadeTime);
    }

    //Fade Out 효과
    public void PanelFadeOut()
    {
        ControlPanel(1f, false);
        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        fadePanel.DOFade(0, fadeTime);

        currentTreasureNum = 0;
    }

    //패널의 상호작용 및 투명도 조절
    void ControlPanel(float alpha, bool isInteractable)
    {
        fadePanel.alpha = alpha;
        fadePanel.interactable = isInteractable;
    }

    //보물에 맞는 정보 띄우기
    public void DisplayTreasurePanel(TreasureInfo treasureInfo)
    {
        treasureImg.sprite = treasureInfo.TreasureImg;
        treasureNameTxt.text = treasureInfo.TreasureName;
        treasureAbilityTxt.text = treasureInfo.Ability;

        currentTreasureNum = treasureInfo.TreasureNum;
    }

    public void SelectTreasure()
    {
        GameManager.Instance.treasureInfo = treasureInfos[currentTreasureNum - 1];
        for (int i = 1; i <= checkImgs.Count; i++)
        {
            if (i == GameManager.Instance.treasureInfo.TreasureNum)
            {
                checkImgs[i - 1].SetActive(true);
            }
            else
            {
                checkImgs[i - 1].SetActive(false);
            }
        }
    }

    public void UnSelectTreasure()
    {
        checkImgs[currentTreasureNum - 1].SetActive(false);
        GameManager.Instance.treasureInfo = null;
    }
}
