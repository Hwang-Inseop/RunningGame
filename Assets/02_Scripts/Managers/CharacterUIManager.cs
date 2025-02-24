using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    [Header("ĳ���� ���� �г�")]
    public CanvasGroup characterSelectPanel;

    [Header("ũ�� ��ȭ ����Ʈ ����Ǵ� ��ư ����Ʈ")]
    public List<Button> makeScaleBtn = new List<Button>();

    [Header("������ ��ư")]
    public GameObject exitBtn;

    [Header("Fade ȿ�� �ð�")]
    [SerializeField]
    private float fadeTime = 0.5f;

    //�ʱ� ����
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

    //ũ�� ����
    public void IncreaseScale()
    {
        exitBtn.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }

    //ũ�� ���� (���󺹱�)
    public void DecreaseScale()
    {
        exitBtn.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }

    //�� �ε�
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //

}
