using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTreasure : Treasure
{
    [SerializeField] private float healthDrain; // 체력 감소량

    public override void ApplyEffect()
    {
        StartCoroutine(CoDrain());
    } 
    
    private IEnumerator CoDrain()
    {
        while (true)
        {
            //if (!MainSceneBase.Instance.IsStart()) yield break; //게임 끝나면 중단
            yield return new WaitForSeconds(intervalTime);

            //float originalDamage = Player.instance.damage;
            //Player.instance.damage *= healthDrain;

            //yield return new WaitForSeconds(duration);

            //Player.instance.damage = originalDamage; // 상태 복구
        }
    }

}
