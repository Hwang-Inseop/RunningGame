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
    public StageInfo stageinfo;

    public CharacterInfo firstCharacterInfo;

    public CharacterInfo secondCharacterInfo;


    public TreasureInfo treasureInfo;


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
        if (Instance.treasureInfo == null)
        {
            Debug.LogError("GameManager: treasureInfo가 설정되지 않았습니다.");
            return null;
        }

        if (Instance.treasureInfo.TreasureObj == null)
        {
            Debug.LogError("GameManager: treasureInfo.TreasureObj가 설정되지 않았습니다.");
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
}
