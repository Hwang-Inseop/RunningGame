using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTreasure : Treasure
{
    private void Update()
    {
        if (player.canRevive > 0 && player.isDropped)
        {
            int currentHealth = player.currentHP;
            player.canRevive--;

            player.currentHP = 0;
            StartCoroutine(Revive(player, currentHealth));
        }
    }
    public override void ApplyEffect(Player player)
    {
        this.player = player;
        player.canRevive++;
        
    }
    public IEnumerator Revive(Player player, int currentHp) // 부활
    {
        Vector3 startPos = player.transform.position;
        Vector3 targetPos = Vector3.zero;
        float duration = 1.5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            player.transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime/duration); 
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        player.transform.position = targetPos;
        player.currentHP = currentHp;
        player.isDropped = false;
    }
}
