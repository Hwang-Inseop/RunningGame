using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageInfo", menuName = "Scriptable Object/StageInfo", order = int.MaxValue)]

public class StageInfo : ScriptableObject
{
    //스테이지
    [SerializeField]
    private int stageNum;

    public int StageNum { get { return stageNum; } }

    //스테이지 설명
    [SerializeField]
    private string stageDescription;

    public string StageDescription { get { return stageDescription; } }

    //스테이지 배경
    [SerializeField]
    private Sprite background;

    public Sprite Background { get { return background; } }

}
