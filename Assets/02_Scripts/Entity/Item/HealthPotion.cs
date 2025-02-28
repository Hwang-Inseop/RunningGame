using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : Item
{
    public int healingAmount = 0;
    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        player.currentHP += healingAmount;
        SoundManager.Instance.PlaySfx(SoundType.PotionSfx, 0.5f);
        if (player.currentHP > player.maxHP) player.currentHP = player.maxHP;
    }
}
