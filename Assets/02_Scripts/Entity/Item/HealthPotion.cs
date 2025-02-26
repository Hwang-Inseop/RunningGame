using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{

    public int healingAmount = 0;
    public override void ApplyEffect(Player player)
    {
        base.ApplyEffect(player);
        player.currentHP += healingAmount;
    }
}
