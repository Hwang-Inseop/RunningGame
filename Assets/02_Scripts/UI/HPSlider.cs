using RunningGame.Managers;
using RunningGame.Scriptable;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    private HealthPotion healthPotion;
    [SerializeField] private Slider slider;
    private float smoothSpeed = 5f; //체력이 자연스럽게 줄어들도록 만들기 위한 속도

    public void Init()
    {
        slider.maxValue =(float)MainSceneBase.Instance.CurrentPlayer.maxHP/100;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainSceneBase.Instance.IsStart())
        {
            slider.value = (float)MainSceneBase.Instance.CurrentPlayer.currentHP / (float)MainSceneBase.Instance.CurrentPlayer.maxHP;
            //float targetValue = (float)MainSceneBase.Instance.CurrentPlayer.currentHP/ (float)MainSceneBase.Instance.CurrentPlayer.maxHP; //체력이 자연스럽게 줄기위한 현재 줄어들고있는 체력의 목표값
            // slider.value = Mathf.Lerp(slider.value, targetValue, Time.deltaTime * smoothSpeed); //Mathf를 통한 자연스러움으로 표현
        }
    }
}
