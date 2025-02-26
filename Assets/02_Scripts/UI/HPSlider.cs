using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    private Player player;
    private HealthPotion healthPotion;
    [SerializeField] private Slider slider;
    private float smoothSpeed = 5f; //체력이 자연스럽게 줄어들도록 만들기 위한 속도
    private void Awake()
    {
        //if(player.CompareTag("Player"))
        //player = FindObjectOfType<Player>();
    }
    void Start()
    {
        slider.maxValue = GameManager.Instance.firstCharacterInfo.Health;
        if(player == null)
        {
            Debug.LogError("캐릭터가 없음.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.currentHP;
        float targetValue = player.currentHP; //체력이 자연스럽게 줄기위한 현재 줄어들고있는 체력의 목표값
        slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * smoothSpeed); //Mathf를 통한 자연스러움으로 표현
    }
    public void AddHP()
    {
        Debug.Log("체력회복");
    }
}
