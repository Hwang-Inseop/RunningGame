using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTreasure : Treasure
{
    [SerializeField] private float healthDrain; // 체력 감소량
    private bool isActive = false;
    int originalDamage;
    public override void ApplyEffect(PlayerController player)
    {
        if (!isActive)
        {
            isActive = true;
            originalDamage = player.damage;
            StartCoroutine(CoDrain(player));
        }
    } 
    
    private IEnumerator CoDrain(PlayerController player)
    {
        while (true)
        {
            isActive = false;
            yield return new WaitForSeconds(intervalTime);
            Debug.Log("체력 감소 감소");

            player.damage = originalDamage - (int)healthDrain;
            
            yield return new WaitForSeconds(duration);

            player.damage = originalDamage; // 상태 복구
        }
    }

}
