using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    private void Start()
    {
        
    }

    //씬 로드
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //게임 종료
    public void OnApplicationQuit()
    {
        Debug.Log("게임종료");
    }

    //크기 증가
    public void IncreaseScale(Button btn)
    {
        btn.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }

    //크기 감소 (원상복구)
    public void DecreaseScale(Button btn)
    {
        btn.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }
}