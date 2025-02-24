using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageInfo", menuName = "Scriptable Object/StageInfo", order = int.MaxValue)]

public class StageInfo : ScriptableObject
{
    //��������
    [SerializeField]
    private int stageNum;

    public int StageNum { get { return stageNum; } }

    //�������� ����
    [SerializeField]
    private string stageDescription;

    public string StageDescription { get { return stageDescription; } }

    //�������� ���
    [SerializeField]
    private Sprite background;

    public Sprite Background { get { return background; } }

}
