using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Item
{
    [SerializeField] private int coinAmount; // 재화 증가
    public override int Score => 0; // 점수

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        // 코인 증가 += cointAmount;
    }


}
