using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Item
{
    [SerializeField] private int coinAmount; // ��ȭ ����
    public override int Score => 0; // ����

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        // ���� ���� += cointAmount;
    }


}
