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

    [SerializeField] private int canRevive; // 부활 가능 횟수

    private PlayerController player;
    private void Start()
    {
        StartCoroutine(WaitForStart());
    }
    public void Equip(PlayerController player)
    {
        if (!IsEquipped)
        {
            IsEquipped = true;
            this.player = player;
            if (canRevive > 0)
            {
                // Player 부활 가능 횟수 += canRevive
            }
        }
    }

    public void Unequip()
    {
        if (IsEquipped)
        {
            IsEquipped = false;

            if(canRevive > 0)
            {
                // Player 부활 가능 횟수 -= canRevive
            }
        }
    }
    public virtual void ApplyEffect(PlayerController player) { }
    private IEnumerator WaitForStart() // 게임 시작까지 대기
    {
        while (true) // -> !MainSceneBase.Instance.IsStart())
        {
            yield return null;
        }
        if (IsEquipped) ApplyEffect(player);
    }
}


