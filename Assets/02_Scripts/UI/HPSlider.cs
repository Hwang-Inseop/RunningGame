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
        }
    }
}
