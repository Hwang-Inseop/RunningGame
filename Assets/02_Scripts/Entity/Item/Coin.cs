using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Item
{

    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        // 코인 증가 += cointAmount;
    }


}
