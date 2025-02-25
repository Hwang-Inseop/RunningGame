using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    [Header("ũ�� ��ȭ ����Ʈ ����Ǵ� ��ư ����Ʈ")]
    public List<Button> makeScaleBtn = new List<Button>();

    private void Start()
    {
        
    }

    //�� �ε�
    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //���� ����
    public void OnApplicationQuit()
    {
        Debug.Log("��������");
    }

    //ũ�� ����
    public void IncreaseScale(Button btn)
    {
        btn.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
    }

    //ũ�� ���� (���󺹱�)
    public void DecreaseScale(Button btn)
    {
        btn.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }
}