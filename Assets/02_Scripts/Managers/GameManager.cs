using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    //초기 설정
    public StageInfo stageinfo;

    public CharacterInfo firstCharacterInfo;

    public CharacterInfo CharacterInfo;

    private PlayerController player;
    public enum characterState //enum을 통한 캐릭터 상태 
    {
        ready,
        running,
        finished
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
        //현재 선택된 스테이지 -> 1로 설정해 기본 스테이지에서 달리는 설정
        PlayerPrefs.SetInt("choosedStage", 1);

        //현재 선택된 첫번째 주자의 플레이어 번호 -> 1로 설정해 기본 캐릭터로 달리는 설정
        PlayerPrefs.SetInt("firstRunnerNum", 1);

        //현재 선택된 두번째 주자의 플레이어 번호 -> 0으로 설정해 기본적으로 없는 설정
        PlayerPrefs.SetInt("secondRunnerNum", 0);
    }
}
