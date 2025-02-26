using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectionPlayer : Player
{
    
    public float revivalInterval = 1f;

    void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        ActivateAbility();
    }
    
    protected override void ActivateAbility()
    {
        if (canRevive > 0 && currentHP <= 0)
        {
            canRevive--;
            StartCoroutine(ResurrectionAbility());
            StartCoroutine(DrainHp()); // 체력 지속 소모 시작
        }
    }

    IEnumerator ResurrectionAbility()
    {
        currentHP = maxHP / 2;
        yield return new WaitForSeconds(revivalInterval);
        
        Debug.Log("Revive");
    }

}
