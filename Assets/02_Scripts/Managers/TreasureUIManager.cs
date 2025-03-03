using DG.Tweening;
using RunningGame.Managers;
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

    [Header("AlienTalkInfo")]
    public List<AlienTalkInfo> alienTalkInfos = new List<AlienTalkInfo>();

    [Header("Alien 말풍선 Text")]
    public TextMeshProUGUI alienTalk;

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

    [Header("보유한 잼의 개수가 적힐 칸")]
    [SerializeField]
    private TextMeshProUGUI jemCountTxt;

    [Header("해금하기 버튼")]
    [SerializeField]
    private GameObject unlockBtn;

    [Header("장착 버튼")]
    [SerializeField]
    private GameObject equipTreasureBtn; 

    [Header("해제 버튼")]
    [SerializeField]
    private GameObject unEquipTreasureBtn;

    [Header("해금 완료 패널")]
    [SerializeField]
    private GameObject unlockCompletePanel;

    [Header("보유한 잼의 개수가 적힐 칸 - 패널 외")]
    [SerializeField]
    private TextMeshProUGUI wholeJemCount;


    //패널을 누를때 현재 보이는 보물의 숫자
    private int currentTreasureNum = 0;

    //잠금해제를 위한 잼의 필요 개수
    private int limitToUnlock = 50;

    void Start()
    {
        wholeJemCount.text = GameManager.Instance.JemCount.ToString();

        fadePanelGo.SetActive(true);
        fadePanel.alpha = 0f;
        fadePanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, -1000f, 0f);

        treasureSelectPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, -1000f, 0f);
        treasureSelectPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, -25f), fadeTime, false).SetEase(Ease.InOutQuint);
        treasureSelectPanel.DOFade(1, fadeTime);

        alienImg.GetComponent<RectTransform>().transform.localPosition = new Vector3(-120f, -2000f, 0f);
        alienImg.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-120f, -150f), fadeTime * 2, false).SetEase(Ease.OutQuad);
        alienImg.DOFade(1, fadeTime);

        for (int i = 1; i <= checkImgs.Count; i++)
        {
            if (GameManager.Instance.treasureInfo == null) { }
            else if (i == GameManager.Instance.treasureInfo.TreasureNum)
            {
                checkImgs[i - 1].SetActive(true);
            }
            else
            {
                checkImgs[i - 1].SetActive(false);
            }
        }

    }

    //씬 로드
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.5f);
    }

    //Fade In 효과
    public void PanelFadeIn()
    {
        ControlPanel(0f, true);
        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        fadePanel.DOFade(1, fadeTime);
        SoundManager.Instance.PlaySfx(SoundType.PanelSfx, 0.5f);
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
        SoundManager.Instance.PlaySfx(SoundType.PanelSfx, 0.5f);
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
        jemCountTxt.text = GameManager.Instance.JemCount.ToString();

        if (treasureInfo.IsOpened)
        {
            unlockBtn.SetActive(false);
            equipTreasureBtn.SetActive(true);
            unEquipTreasureBtn.SetActive(true);
            unlockCompletePanel.SetActive(true);
        }
        else
        {
            unlockBtn.SetActive(true);
            equipTreasureBtn.SetActive(false);
            unEquipTreasureBtn.SetActive(false);
            unlockCompletePanel.SetActive(false);
        }
    }

    //보물 선택
    public void SelectTreasure()
    {
        if(treasureInfos[currentTreasureNum - 1].IsOpened)
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
    }

    //보물 해제
    public void UnSelectTreasure()
    {
        checkImgs[currentTreasureNum - 1].SetActive(false);
        GameManager.Instance.treasureInfo = null;
    }

    //보물 해금
    public void UnlockTreasure()
    {
        if (GameManager.Instance.JemCount >= limitToUnlock)
        {
            PlayerPrefs.SetInt("JemCount", GameManager.Instance.JemCount - limitToUnlock);
            GameManager.Instance.JemCount -= limitToUnlock;
            jemCountTxt.text = GameManager.Instance.JemCount.ToString();
            treasureInfos[currentTreasureNum - 1].IsOpened = true;
            unlockBtn.SetActive(false);
            wholeJemCount.text = GameManager.Instance.JemCount.ToString();

            unlockBtn.SetActive(false);
            equipTreasureBtn.SetActive(true);
            unEquipTreasureBtn.SetActive(true);
            unlockCompletePanel.SetActive(true);
            SoundManager.Instance.PlaySfx(SoundType.UnlockSfx, 0.5f);
        }
    }

    public void ChangeTalk()
    {
        Random random = new Random();
        alienTalk.text = alienTalkInfos[random.Next(alienTalkInfos.Count)].Talk;
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.5f);
    }

    //Dotween 오류 방지
    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
