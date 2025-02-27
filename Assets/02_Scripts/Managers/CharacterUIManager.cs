using DG.Tweening;
using RunningGame.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    [Header("characterInfo")]
    public List<CharacterInfo> characterInfos = new List<CharacterInfo>();

    [Header("캐릭터 선택 패널")]
    public CanvasGroup characterSelectPanel;

    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    [Header("나가기 버튼")]
    public GameObject exitBtn;

    [Header("Fade 효과 시간")]
    [SerializeField]
    private float fadeTime = 0.5f;

    [Header("캐릭터 정보 패널이 뜰 때 패널 외 버튼의 상호작용 방지용 패널")]
    public GameObject emptyPanel;

    [Header("캐릭터 정보 패널")]
    public CanvasGroup characterInfoPanel;
    public GameObject characterInfoPanelGo;

    [Header("캐릭터 사진이 보이는 칸")]
    [SerializeField]
    private Image charImage;

    [Header("캐릭터 이름이 적힐 칸")]
    [SerializeField]
    private TextMeshProUGUI nameTxt;

    [Header("캐릭터 체력이 적힐 칸")]
    [SerializeField]
    private TextMeshProUGUI healthTxt;

    [Header("캐릭터의 한마디가 적힐 칸")]
    [SerializeField]
    private TextMeshProUGUI charTalk;

    [Header("캐릭터 능력이 적힐 칸")]
    [SerializeField]
    private TextMeshProUGUI abilityTxt;

    [Header("보유한 잼의 개수가 적힐 칸 - 패널 내")]
    [SerializeField]
    private TextMeshProUGUI jemCountTxt;

    [Header("해금하기 버튼")]
    [SerializeField]
    private GameObject unlockBtn;

    [Header("1주자로 달린다는 표시")]
    public List<GameObject> firstSelectedImage = new List<GameObject>();

    [Header("2주자로 달린다는 표시")]
    public List<GameObject> secondSelectedImage = new List<GameObject>();

    [Header("1주자 설정 버튼")]
    [SerializeField]
    private GameObject firstRunnerSettingBtn;

    [Header("2주자 설정 버튼")]
    [SerializeField]
    private GameObject secondRunnerSettingBtn;

    [Header("해금 완료 패널")]
    [SerializeField]
    private GameObject unlockCompletePanel;

    [Header("보유한 잼의 개수가 적힐 칸 - 패널 외")]
    [SerializeField]
    private TextMeshProUGUI wholeJemCount;

    //패널에 뜨는 주자의 번호
    private int runnerPanelNum = 0;

    //잠금해제를 위한 잼의 필요 개수
    private int limitToUnlock = 50;

    //초기 설정
    void Start()
    {
        ChangeSelectedFirstRunner();
        ChangeSelectedSecondRunner();

        wholeJemCount.text = GameManager.Instance.JemCount.ToString();

        characterInfoPanel.transform.localPosition = new Vector3(0f, -1000f, 0f);

        foreach (Button button in makeScaleBtn)
        {
            button.onClick.AddListener(() =>
            {
                button.transform.DOKill();
                button.transform.localScale = Vector3.one;

                button.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f).SetLoops(2, LoopType.Yoyo);
            });
        }

        RectTransform rectTransform = characterSelectPanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -25f), fadeTime, false).SetEase(Ease.InOutQuint);
        characterSelectPanel.DOFade(1, fadeTime);
    }

    //크기 증가
    public void IncreaseScale()
    {
        if (exitBtn != null)
            exitBtn.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }

    //크기 감소 (원상복구)
    public void DecreaseScale()
    {
        if (exitBtn != null)
            exitBtn.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }

    //씬 로드
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.5f);
    }

    //캐릭터에 맞는 정보 띄우기
    public void DisplayCharPanel(CharacterInfo charInfo)
    {
        characterInfoPanelGo.GetComponent<Image>().sprite = charInfo.BgSprite;
        charImage.sprite = charInfo.Photo;
        nameTxt.text = charInfo.CharName;
        healthTxt.text = charInfo.Health.ToString();
        charTalk.text = charInfo.Talk;
        abilityTxt.text = charInfo.Ability;

        jemCountTxt.text = GameManager.Instance.JemCount.ToString();
        if(charInfo.IsOpened)
        {
            unlockBtn.SetActive(false);
            firstRunnerSettingBtn.SetActive(true);
            secondRunnerSettingBtn.SetActive(true);
            unlockCompletePanel.SetActive(true);
        }
        else
        {
            unlockBtn.SetActive(true);
            firstRunnerSettingBtn.SetActive(false);
            secondRunnerSettingBtn.SetActive(false);
            unlockCompletePanel.SetActive(false);
        }

        runnerPanelNum = charInfo.CharacterNum;
        PanelFadeIn();

        OpenEmptyPanel();
    }

    //Fade In 효과
    public void PanelFadeIn()
    {
        characterInfoPanel.alpha = 0;
        RectTransform rectTransform = characterInfoPanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
        characterInfoPanel.DOFade(1, fadeTime);
        SoundManager.Instance.PlaySfx(SoundType.PanelSfx, 0.5f);
    }

    //Fade Out 효과
    public void PanelFadeOut()
    {
        characterInfoPanel.alpha = 1;
        RectTransform rectTransform = characterInfoPanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        characterInfoPanel.DOFade(0, fadeTime);
        SoundManager.Instance.PlaySfx(SoundType.PanelSfx, 0.5f);
        runnerPanelNum = 0;
    }

    //첫번째 주자 바꾸기
    public void ChangeFirstRunner()
    {
        CharacterInfo cInfo01 = GameManager.Instance.secondCharacterInfo;
        CharacterInfo cInfo02 = characterInfos[runnerPanelNum - 1];

        if (cInfo01 == cInfo02 || !cInfo02.IsOpened) { }
        else
        {
            GameManager.Instance.firstCharacterInfo = characterInfos[runnerPanelNum - 1];
            for (int i = 1; i <= firstSelectedImage.Count; i++)
            {
                if (i == runnerPanelNum)
                {
                    firstSelectedImage[i- 1].SetActive(true);
                }
                else
                {
                    firstSelectedImage[i - 1].SetActive(false);
                }
            }
        }
        CloseEmptyPanel();
    }

    //두번째 주자 바꾸기
    public void ChangeSecondRunner()
    {
        CharacterInfo cInfo01 = characterInfos[runnerPanelNum - 1];
        CharacterInfo cInfo02 = GameManager.Instance.firstCharacterInfo;

        if (cInfo02 == cInfo01 || !cInfo01.IsOpened) { }
        else
        {
            GameManager.Instance.secondCharacterInfo = characterInfos[runnerPanelNum - 1];
            for (int i = 1; i <= secondSelectedImage.Count; i++)
            {

                if (i == runnerPanelNum)
                {
                    secondSelectedImage[i - 1].SetActive(true);
                }
                else
                {
                    secondSelectedImage[i - 1].SetActive(false);
                }
            }
        }
        CloseEmptyPanel();
    }

    //첫번째 주자 초기화
    public void ChangeSelectedFirstRunner()
    {
        for (int i = 1; i <= firstSelectedImage.Count; i++)
        {
            if (i == GameManager.Instance.firstCharacterInfo.CharacterNum)
            {
                firstSelectedImage[i - 1].SetActive(true);
            }
            else
            {
                firstSelectedImage[i - 1].SetActive(false);
            }
        }
    }

    //두번째 주자 초기화
    public void ChangeSelectedSecondRunner()
    {
        //이어달리기 설정을 안하는 경우도 고려
        if (GameManager.Instance.secondCharacterInfo != null)
        {
            for (int i = 1; i <= secondSelectedImage.Count; i++)
            {

                if (i == GameManager.Instance.secondCharacterInfo.CharacterNum)
                {
                    secondSelectedImage[i - 1].SetActive(true);
                }
                else
                {
                    secondSelectedImage[i - 1].SetActive(false);
                }
            }
        }
    }

    //이어달리기 전부 해제
    public void CheckoutSecondRunner()
    {
        GameManager.Instance.secondCharacterInfo = null;
        foreach (GameObject secondImgs in secondSelectedImage)
        {
            secondImgs.SetActive(false);
        }
    }

    //방지 패널 닫기
    public void CloseEmptyPanel()
    {
        emptyPanel.SetActive(false);
    }

    //방지 패널 열기
    public void OpenEmptyPanel()
    {
        emptyPanel.SetActive(true);
    }

    //캐릭터 잠금해제
    public void UnlockCharacter()
    {
        if(GameManager.Instance.JemCount >= limitToUnlock)
        {
            PlayerPrefs.SetInt("JemCount", GameManager.Instance.JemCount - 50);
            jemCountTxt.text = GameManager.Instance.JemCount.ToString();
            characterInfos[runnerPanelNum - 1].IsOpened = true;
            unlockBtn.SetActive(false);
            firstRunnerSettingBtn.SetActive(true);
            secondRunnerSettingBtn.SetActive(true);
            unlockCompletePanel.SetActive(true);

            wholeJemCount.text = GameManager.Instance.JemCount.ToString();
            
            SoundManager.Instance.PlaySfx(SoundType.UnlockSfx, 0.5f);
        }
    }

    //Dotween 오류 방지
    private void OnDestroy()
    {
        DOTween.KillAll();
    }

}
