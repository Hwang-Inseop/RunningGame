using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTreasure : Treasure
{
    [SerializeField] private float healthDrain; // 체력 감소량

    public override void ApplyEffect(PlayerController player)
    {
        StartCoroutine(CoDrain(player));
    } 
    
    private IEnumerator CoDrain(PlayerController player)
    {
        while (true)
        {
            //if (!MainSceneBase.Instance.IsStart()) yield break; //게임 끝나면 중단
            yield return new WaitForSeconds(intervalTime);

            int originalDamage = player.damage;
            player.damage -= (int)healthDrain;

            yield return new WaitForSeconds(duration);

            player.damage = originalDamage; // 상태 복구
        }
    }

}
