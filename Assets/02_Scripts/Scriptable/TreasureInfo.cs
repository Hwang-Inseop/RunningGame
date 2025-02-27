using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "TreasureInfo", menuName = "Scriptable Object/TreasureInfo", order = int.MaxValue)]

public class TreasureInfo : ScriptableObject
{
    //보물 번호
    [SerializeField]
    private int treasureNum;

    public int TreasureNum { get { return treasureNum; } }

    //보물 이름
    [SerializeField]
    private string treasureName;

    public string TreasureName { get { return treasureName; } }

    //보물 능력 설명
    [SerializeField]
    private string ability;

    public string Ability { get { return ability; } }

    //보물 이미지
    [SerializeField]
    private Sprite treasureImg;

    public Sprite TreasureImg { get { return treasureImg; } }

    //보물 해금 여부
    [SerializeField]
    public bool isOpened;

    public bool IsOpened { get { return isOpened; } set { isOpened = value; EditorUtility.SetDirty(this); } }

    [SerializeField] // 보물 프리팹
    private GameObject treasureObj;
    public GameObject TreasureObj { get { return treasureObj; } }
}
