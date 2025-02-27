using RunningGame.Managers;
using System;
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
    //스테이지 정보
    public StageInfo stageinfo;

    //1번째 주자
    public CharacterInfo firstCharacterInfo;

    //두번째 주자
    public CharacterInfo secondCharacterInfo;

    //보물
    public TreasureInfo treasureInfo;

    //현재 보유하고 있는 잼의 개수
    private int jemCount = 0;

    public int JemCount { get { return jemCount; } set { jemCount = value; } }

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

    public Treasure GetTreasureInstance()
    {
        if (Instance.treasureInfo == null || Instance.treasureInfo.TreasureObj == null)
        {
            return null;
        }
        GameObject treasureObj = Instantiate(Instance.treasureInfo.TreasureObj, transform);
        Treasure treasure = treasureObj.GetComponent<Treasure>();

        if (treasure == null)
        {
            Destroy(treasureObj);
            return null;
        }

        return treasure;
    }
    private void Start()
    {
        jemCount = PlayerPrefs.GetInt("JemCount", 0);
    }
}
