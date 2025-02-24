using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public override int Score => 0;
    public int healingAmount = 0;
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        // 플레이어 체력 += healingAmount;
    }
}
