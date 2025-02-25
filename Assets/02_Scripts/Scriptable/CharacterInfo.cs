using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "Scriptable Object/CharacterInfo", order = int.MaxValue)]

public class CharacterInfo : ScriptableObject
{
    //이름 / 해금에 따른 재화 / 능력설명 / 한마디 / 체력 / 색깔 / 배경 sprite
    //캐릭터 번호
    [SerializeField]
    private int characterNum;

    public int CharacterNum { get { return characterNum; } }

    //캐릭터 이름
    [SerializeField]
    private string charName;

    public string CharName { get { return charName; } }

    //캐릭터 체력
    [SerializeField]
    private float health;

    public float Health { get { return health; } }

    //해금 조건에 맞는 보석
    [SerializeField]
    private Sprite jewel;

    public Sprite Jewel { get { return jewel; } }

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

    //캐릭터 선택창 배경
    [SerializeField]
    private Sprite bgSprite;

    public Sprite BgSprite { get { return bgSprite; } }

    //캐릭터 해금 여부
    [SerializeField]
    private bool isOpened;

    public bool IsOpened { get { return isOpened; } set { isOpened = value; } }

    //캐릭터 사진
    [SerializeField]
    private Sprite charSprite;

    public Sprite CharSprite { get { return charSprite; } }

}
