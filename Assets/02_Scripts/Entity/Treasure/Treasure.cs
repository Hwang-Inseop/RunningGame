using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool IsEquipped { get; private set; } // 장착 여부
    [SerializeField] private string name; // 이름
    [SerializeField] private string description; // 설명
    [SerializeField] private int reqGem; // 필요한 젬 개수
    [SerializeField] protected float intervalTime; // 쿨타임
    [SerializeField] protected float duration; // 효과 지속 시간
    private bool hasEffect = false;

    private Player player;

    private void Update()
    {
        if (!MainSceneBase.Instance.IsStart())
        {
            StopAllCoroutines();
        }
    }
    public void Equip(Player player)
    {
        if (!IsEquipped)
        {
            IsEquipped = true;
            this.player = player;

            Canvas canvas = FindObjectOfType<Canvas>();
            if(canvas != null)
            {
                transform.SetParent(canvas.transform, true);
            }
            
            StartCoroutine(WaitForStart());
        }
    }

    public void Unequip()
    {
        if (IsEquipped)
        {
            IsEquipped = false;
        }
    }
    public virtual void ApplyEffect(Player player) { }
    private IEnumerator WaitForStart() // 게임 시작까지 대기
    {
        while (!MainSceneBase.Instance.IsStart())
        {
            yield return null;
        }
        if (IsEquipped && !hasEffect)
        {
            ApplyEffect(player);
            hasEffect = true;
        }
        yield return null;
    }
}


