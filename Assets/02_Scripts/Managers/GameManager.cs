using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // �̱��� �ν��Ͻ�

    public static GameManager Instance // �̱��� ������Ƽ
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("GameManager");
                instance = obj.AddComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

    //�ʱ� ����
    public StageInfo stageinfo;

    public CharacterInfo firstCharacterInfo;

    public CharacterInfo CharacterInfo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //���� ���õ� �������� -> 1�� ������ �⺻ ������������ �޸��� ����
        PlayerPrefs.SetInt("choosedStage", 1);

        //���� ���õ� ù��° ������ �÷��̾� ��ȣ -> 1�� ������ �⺻ ĳ���ͷ� �޸��� ����
        PlayerPrefs.SetInt("firstRunnerNum", 1);

        //���� ���õ� �ι�° ������ �÷��̾� ��ȣ -> 0���� ������ �⺻������ ���� ����
        PlayerPrefs.SetInt("secondRunnerNum", 0);
    }
}
