using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPlayer : PlayerController
{
    [SerializeField] float coolTime = 30f;
    [SerializeField] float duration = 5f;
    bool abilityActive= false; 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LoopableItem") && abilityActive)
        {
            StartCoroutine(Magnetic(collision.transform));
        }
    }
    public override void ApplyEffect()
    {
        StartCoroutine(AbilityLoop());
    }
    private IEnumerator AbilityLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime);
            abilityActive = true;
            yield return new WaitForSeconds(duration);
            abilityActive = false;
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
