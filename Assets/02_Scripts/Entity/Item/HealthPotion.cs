using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : Item
{
    private HPSlider hpSlider;
    public int healingAmount = 0;
    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        player.currentHP += healingAmount;
    }
}
