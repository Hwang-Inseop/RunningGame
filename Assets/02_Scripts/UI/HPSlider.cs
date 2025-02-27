using RunningGame.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private HealthPotion healthPotion;
    [SerializeField] private Slider slider;
    private float smoothSpeed = 5f; //체력이 자연스럽게 줄어들도록 만들기 위한 속도

    void Start()
    {
        Invoke("GetInfo", 0.01f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //slider.value = player.GetComponent<Player>().currentHP;
        //float targetValue = player.GetComponent<Player>().currentHP; //체력이 자연스럽게 줄기위한 현재 줄어들고있는 체력의 목표값
        //slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * smoothSpeed); //Mathf를 통한 자연스러움으로 표현
    }
    public void AddHP()
    {
        Debug.Log("체력회복");
    }
    public void GetInfo()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            slider.maxValue = player.GetComponent<Player>().maxHP;
    }
}
