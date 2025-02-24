using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "Scriptable Object/CharacterInfo", order = int.MaxValue)]

public class CharacterInfo : ScriptableObject
{
    //캐릭터 번호
    [SerializeField]
    private int characterNum;

    public int CharacterNum { get { return characterNum; } }

    //캐릭터 이름
    [SerializeField]
    private string charName;

    public string CharName { get { return charName; } }

    //해금 조건
    [SerializeField]
    private string howToGet;

    public string HowToGet { get { return howToGet; } }

    //능력 설명
    [SerializeField]
    private string ability;

    public string Ability { get { return ability; } }

    //캐릭터 한마디
    [SerializeField]
    private string talk;

    public string Talk { get { return talk; } }

    //캐릭터 사진
    [SerializeField]
    private Sprite photo;

    public Sprite Photo { get { return photo; } }

}
