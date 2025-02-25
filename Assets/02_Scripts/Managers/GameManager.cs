using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫

    public static GameManager Instance // ΩÃ±€≈Ê «¡∑Œ∆€∆º
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

    //√ ±‚ º≥¡§
    public StageInfo stageinfo;

    public CharacterInfo characterInfo;

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
        
    }
}
