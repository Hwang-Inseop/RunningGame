using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : Item
{

    public override void ApplyEffect(PlayerController player)
    {
        base.ApplyEffect(player);
        // 코인 증가 += cointAmount;
        SoundManager.Instance.PlaySfx(SoundType.CoinSfx, 0.5f);
    }


}
