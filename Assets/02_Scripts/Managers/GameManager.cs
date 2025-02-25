using RunningGame.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    private MainUIManager mainUIManager;

    private static GameManager instance; // 싱글톤 인스턴스
    public static GameManager Instance // 싱글톤 프로퍼티
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("GameManager");
                instance = obj.AddComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }


    public List<PlayerController> availablePlayer;  // 사용가능한 캐릭터의 수를 리스트화
    private PlayerController firstPlayer;
    private PlayerController secondPlayer;

    //초기 설정
    public StageInfo stageinfo;

    public CharacterInfo firstCharacterInfo;

    public CharacterInfo CharacterInfo;

    public enum characterState //enum을 통한 캐릭터 상태 
    {
        ready,
        running,
        died
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        /*추후 구조생각하며 스크립트 변동 가능성있어보임.
        //현재 선택된 스테이지 -> 1로 설정해 기본 스테이지에서 달리는 설정
        PlayerPrefs.SetInt("choosedStage", 1);

        //현재 선택된 첫번째 주자의 플레이어 번호 -> 1로 설정해 기본 캐릭터로 달리는 설정
        PlayerPrefs.SetInt("firstRunnerNum", 1);

        //현재 선택된 두번째 주자의 플레이어 번호 -> 0으로 설정해 기본적으로 없는 설정
        PlayerPrefs.SetInt("secondRunnerNum", 0); */

        int firstRunnerNum = PlayerPrefs.GetInt("firstRunnerNum", 1);
        int secondRunnerNum = PlayerPrefs.GetInt("SecondRunnerNum", 0);

        if(availablePlayer != null && availablePlayer.Count>=firstRunnerNum)
        {
            firstPlayer = availablePlayer[firstRunnerNum - 1];
        }
        if(secondRunnerNum>0 && availablePlayer.Count>=secondRunnerNum) //두번째 선택된 캐릭터가 플레이어 번호가 0이므로 0보다는 큰지 확인,
        {
            secondPlayer = availablePlayer[secondRunnerNum - 1];
        }

        firstPlayer.StartRunning();   // 첫번째 캐릭터 이벤트 호출

        //playerController.OnDeath += OnFirstPlayerDeath // 첫번째 캐릭터 죽음 이벤트 
    }
    private void OnFirstPlayerDeath()
    {
        Debug.Log("첫번째 캐릭터 사망");
        secondPlayer.StartRunning();
        GameOver();
    }

    // Player 스크립트에 포함될 내용
    public event Action OnDeath; // OnDeath 이벤트 선언 

    void Die()
    {
        Debug.Log("죽었음");
        OnDeath?.Invoke(); //OnDeath 이벤트 호출 호출
    }

    public bool isRunning = false;
    public void StartRunning() // 게임시작
    {
        isRunning = true;
        // animator.Setbool("isRunning", true); 
        Debug.Log("게임 시작");
    }
    // 

    public void GameOver() 
    {
        if(secondPlayer == null)
        {
            if(firstPlayer.currentHP<=0)
            {
                isGameOver = true;
                mainUIManager.gameOverPanel.SetActive(true);
            }
        }
        else
        {
            if(secondPlayer.currentHP<=0)
            {
                isGameOver = true;
                mainUIManager.gameOverPanel.SetActive(true);
            }
        }
    }
}
