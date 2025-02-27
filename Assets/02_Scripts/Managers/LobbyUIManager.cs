using DG.Tweening;
using RunningGame.Managers;
using RunningGame.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public TextMeshProUGUI stageDescriptionTxt;

    [Header("스테이지 설명 이미지")]
    public Image stageDescriptionImg;

    [Header("체크 이미지 리스트")]
    public List<GameObject> checkImg = new List<GameObject>();

    [Header("첫 주자 이미지")]
    [SerializeField]
    private Image firstRunnerImg;

    [Header("둘째 주자 이미지")]
    [SerializeField]
    private Image secondRunnerImg;

    [Header("보물 이미지")]
    [SerializeField]
    private Image treasureImg;

    [Header("보물 이름 텍스트")]
    [SerializeField]
    private TextMeshProUGUI treasureNameTxt;

    [Header("장착보물이 없다는 sprite")]
    [SerializeField]
    private Sprite noTreasureSprite;

    [Header("StageInfo")]
    public List<StageInfo> stages = new List<StageInfo>();

    [Header("CharacterInfo")]
    public List<CharacterInfo> cInfos = new List<CharacterInfo>();

    private int currentStagePage = 1;

    //초기 설정
    void Start()
    {
        if(!SoundManager.Instance.IsPlayingBgm())
        {
            SoundManager.Instance.PlayBgm(SoundType.LobbyBGM, 0.1f);
        }

        currentStagePage = GameManager.Instance.stageinfo.StageNum;

        stageDescriptionTxt.text = GameManager.Instance.stageinfo.StageDescription;
        stageDescriptionImg.sprite = GameManager.Instance.stageinfo.Background;
        CheckSelectedStage();
        InitCharacterImg();
        InitTreasureInfo();

        fadePanelGo.SetActive(true);
        fadePanel.alpha = 0f;
        RectTransform rectTransform = fadePanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);

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
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        fadePanel.DOFade(0, fadeTime);

        SoundManager.Instance.PlaySfx(SoundType.PanelSfx, 0.5f);
    }

    //패널의 상호작용 및 투명도 조절
    void ControlPanel(float alpha, bool isInteractable)
    {
        fadePanel.alpha = alpha;
        fadePanel.interactable = isInteractable;
    }

    //스테이지 설명 보여주기
    public void ShowStageDescription(StageInfo stageInfo)
    {
        currentStagePage = stageInfo.StageNum;

        stageDescriptionTxt.text = stageInfo.StageDescription;
        stageDescriptionImg.sprite = stageInfo.Background;

        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.5f);
    }

    //적용된 스테이지 체크표시해주기
    public void CheckSelectedStage()
    {
        GameManager.Instance.stageinfo = stages[currentStagePage - 1];

        for (int i = 1; i <= checkImg.Count; i++)
        {
            if (i == currentStagePage)
            {
                checkImg[i - 1].SetActive(true);
            }
            else
            {
                checkImg[i - 1].SetActive(false);
            }
        }
    }

    //선택된 스테이지로 변경
    public void ChangeSelectedStage()
    {
        GameManager.Instance.stageinfo = stages[currentStagePage - 1];
    }

    //씬 로드
    public void LoadScene(String sceneName)
    {
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.5f);
        SceneManager.LoadScene(sceneName);
        if(sceneName == "MainScene")
        {
            SoundManager.Instance.StopBgm();
        }
    }

    //시작 시에 선택된 캐릭터의 이미지가 보이게 하도록 하기 
    public void InitCharacterImg()
    {
        CharacterInfo cInfo01 = GameManager.Instance.firstCharacterInfo;
        CharacterInfo cInfo02 = GameManager.Instance.secondCharacterInfo;
        firstRunnerImg.sprite = cInfo01.CharSprite;
        
        //이어달리기 유무를 고려
        if (GameManager.Instance.secondCharacterInfo != null)
        {
            SetSecondImageOpicity(1);
           
            secondRunnerImg.sprite = cInfo02.CharSprite;
        }
        else
        {
            SetSecondImageOpicity(0);
        }
    }

    //시작 시에 선택된 보물의 정보가 보이도록 하기
    public void InitTreasureInfo()
    {
        if(GameManager.Instance.treasureInfo != null)
        {
            treasureImg.sprite = GameManager.Instance.treasureInfo.TreasureImg;
            treasureNameTxt.text = GameManager.Instance.treasureInfo.TreasureName;
        }
        else
        {
            treasureImg.sprite = noTreasureSprite;
            treasureNameTxt.text = "보물 미장착중";
        }
    }


    //2번째 주자의 이미지 투명도 조절
    public void SetSecondImageOpicity(float index)
    {
        Color color = secondRunnerImg.color;
        color.a = Mathf.Clamp01(index);
        secondRunnerImg.color = color;
    }

    //Dotween 오류 방지
    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
