using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Item
{

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        // 코인 증가 += cointAmount;
    }


}
