using DG.Tweening;
using RunningGame.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    private StartDisplay startDisplay;
    [Header("크기 변화 이펙트 적용되는 버튼 리스트")]
    public List<Button> makeScaleBtn = new List<Button>();

    private void Start()
    {
        startDisplay = FindObjectOfType<StartDisplay>();
        SoundManager.Instance.PlayBgm(SoundType.TitleBgm, 0.01f);
    }

    //씬 로드
    public void LoadSceneDelayed()
    {
        SceneManager.LoadScene("LobbyScene", 0);
    }

    //게임 종료
    public void OnApplicationQuit()
    {
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.8f);
#if UNITY_EDITOR    //Unity 에디터에서 실행시
        EditorApplication.isPlaying = false;
#else   //실제 빌드된 게임에서 실행시
        Application.Quit();
#endif
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
    public void PressStart()
    {
        SoundManager.Instance.PlaySfx(SoundType.ButtonSfx, 0.8f);
        startDisplay.OnStartButtonClicked();
        Invoke("LoadSceneDelayed", 1.5f);
    }
}