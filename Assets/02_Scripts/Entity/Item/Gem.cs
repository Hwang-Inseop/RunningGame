using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Item
{
    [SerializeField] private int gemAmount; // 재화 증가

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        //재화 증가 += gemAmount
    }
}
