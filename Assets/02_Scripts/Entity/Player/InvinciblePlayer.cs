using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePlayer : Player
{
    private bool isCoolDown = false; // 쿨 타임이 끝나고 능력이 발동 가능한 상태
    
    public float coolTime; // 능력 쿨타임
    public float abilityDuration; // 능력 유지 시간

    protected override void Start()
    {
        base.Start();
        ActivateAbility();
    }
    
    protected override void ActivateAbility()
    {
        if (!damaged)
            StartCoroutine(InvincibleAbility());
    }

    IEnumerator InvincibleAbility()
    {
        while (!isCoolDown)
        {
        isCoolDown = true;
        damaged = true;
        StartCoroutine(BlinkEffect());
        Debug.Log("Ability Invincible Start");
        yield return new WaitForSeconds(abilityDuration);
        
        damaged = false;
        Debug.Log("Ability Invincible End");
        isCoolDown = false;
        yield return new WaitForSeconds(coolTime);
        }
    }
}
