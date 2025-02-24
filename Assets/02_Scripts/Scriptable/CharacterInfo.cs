using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "Scriptable Object/CharacterInfo", order = int.MaxValue)]

public class CharacterInfo : ScriptableObject
{
    //ĳ���� ��ȣ
    [SerializeField]
    private int characterNum;

    public int CharacterNum { get { return characterNum; } }

    //ĳ���� �̸�
    [SerializeField]
    private string charName;

    public string CharName { get { return charName; } }

    //�ر� ����
    [SerializeField]
    private string howToGet;

    public string HowToGet { get { return howToGet; } }

    //�ɷ� ����
    [SerializeField]
    private string ability;

    public string Ability { get { return ability; } }

    //ĳ���� �Ѹ���
    [SerializeField]
    private string talk;

    public string Talk { get { return talk; } }

    //ĳ���� ����
    [SerializeField]
    private Sprite photo;

    public Sprite Photo { get { return photo; } }

}
