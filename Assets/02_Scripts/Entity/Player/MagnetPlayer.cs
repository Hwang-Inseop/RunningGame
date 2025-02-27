using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MagnetPlayer : Player
{
    public GameObject magnetZone;
    [SerializeField] float coolTime = 30f;
    [SerializeField] float duration = 5f;
    bool abilityActive = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LoopableItem") && abilityActive)
        {
            ActivateAbility();
        }
    }
    private void Start()
    {
        base.Start();
        magnetZone.SetActive(false);
        ActivateAbility();
    }
    protected override void ActivateAbility()
    {
        StartCoroutine(AbilityLoop());
    }
    private IEnumerator AbilityLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime);
            abilityActive = true;
            magnetZone.SetActive(true);
            yield return new WaitForSeconds(duration);
            abilityActive = false;
            magnetZone.SetActive(false);
        }
    }
    public void AttractItem(Transform item)
    {
        if (abilityActive)
        {
            StartCoroutine(Magnetic(item));
        }
    }
    public IEnumerator Magnetic(Transform coin)
    {
        float duration = 1f; // 이동하는 데 걸리는 시간
        float elapsedTime = 0f;

        Vector3 startPos = coin.position;
        Vector3 targetPos = transform.position;

        while (elapsedTime < duration && coin != null)
        {
            coin.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
