using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTreasure : Treasure
{
    [SerializeField] private GameObject footHold;

    private void Start()
    {
        canRescue = true;
    }

    private void Update()
    {
        if (canRescue && player.isDropped)
        {
            int currentHealth = player.currentHP;
            //player.canRevive--;

            StartCoroutine(Revive(player, currentHealth));
        }
    }

    public override void ApplyEffect(Player player)
    {
        this.player = player;
        //player.canRevive++;
    }

    public IEnumerator Revive(Player player, int currentHp) // 부활
    {
        Debug.Log("ReviveTreasure : Revive");

        Vector3 startPos = player.transform.localPosition;
        Vector3 targetPos = new Vector3(0, 0.2f, 0);
        float duration = 1f;
        float elapsedTime = 0f;
        //player.currentHP = 0;
        while (elapsedTime < duration)
        {
            player.transform.localPosition = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.localPosition = targetPos;
        player.currentHP = currentHp;
        player.isDropped = false;
        footHold.transform.parent = MainSceneBase.Instance.GetLoopableRoot();
        footHold.transform.position = player.transform.position + Vector3.down;
        footHold.transform.localScale = Vector3.one;
        footHold.SetActive(true);
        canRescue = false;
    }
}