using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item
{
    [SerializeField] private int gemAmount; // ��ȭ ����

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        //��ȭ ���� += gemAmount
    }
}
