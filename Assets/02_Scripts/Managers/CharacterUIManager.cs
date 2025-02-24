using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    [Header("캐릭터 선택 패널")]
    public CanvasGroup characterSelectPanel;

    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    [Header("나가기 버튼")]
    public GameObject exitBtn;

    [Header("Fade 효과 시간")]
    [SerializeField]
    private float fadeTime = 0.5f;

    //초기 설정
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

        RectTransform rectTransform = characterSelectPanel.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -25f), fadeTime, false).SetEase(Ease.InOutQuint);
        characterSelectPanel.DOFade(1, fadeTime);
    }

    void Update()
    {
        
    }

    //크기 증가
    public void IncreaseScale()
    {
        exitBtn.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }

    //크기 감소 (원상복구)
    public void DecreaseScale()
    {
        exitBtn.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }

    //씬 로드
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //

}
