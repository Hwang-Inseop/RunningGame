using DG.Tweening;
using JetBrains.Annotations;
using RunningGame.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    [Header("일시정지 버튼")]
    public GameObject pauseMenu;
    private bool isPause = false;

    //UIManager로 이동할 부분
    [Header("게임 점수")]
    public int totalScore;
    public int currentScore = 0;
    public TextMeshProUGUI totalScoreTxt;

    [Header("얻은 재화")]
    public int totalGold;
    public int currentgold = 0;
    public TextMeshProUGUI totalGoldTxt;

    private float hp;

    [Header("게임 오버시 선택 패널")]
    public CanvasGroup gameOverSelectPanel;
    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    [Header("Fade 효과 시간")]
    [SerializeField] private float fadeTime = 0.5f;

    public void PauseGame() // 게임 일시 정지
    {
        isPause = !isPause;
        if (isPause)
            pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    #region UI매니저로 이동할 부분
    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }


    public void SelectStageBtn() // 스테이지 선택창 
    {
        Time.timeScale = 1f;
        //불러올 씬의 정보로 로드 MainSceneBase.LoadScene(" " );
    }

    public void QuitGame()   // 게임 종료
    {
        Application.Quit();
    }

    public void AddScore() // 점수 추가
    {
        Debug.Log("점수 추가");
        totalScore += currentScore;
        totalScoreTxt.text = totalScore.ToString();
    }

    public void AddGold() // 재화 추가
    {
        Debug.Log("골드 추가");
        totalGold += currentgold;
        totalGoldTxt.text = totalGold.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //  onDamage(데미지변수 입력);
        }
    }

    void Start() //도트윈 사용방법
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
}
#endregion