using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item
{
    [SerializeField] private int gemAmount; // 재화 증가

    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        SoundManager.Instance.PlaySfx(SoundType.GemSfx, 0.5f);
        MainUIManager.Instance.totalGold += gemAmount;
        MainUIManager.Instance.AddGold();
    }
}
