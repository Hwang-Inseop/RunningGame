using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBGLooper : MonoBehaviour
{
    [Header("Background ����Ʈ")]
    public List<GameObject> bgs = new List<GameObject>();

    [Header("Background�� �ݺ���ų Looper")]
    public GameObject looper;

    [Header("�̵� �ӵ�")]
    private float moveSpeed = 0.005f;

    [Header("�̵���ų ��ġ")]
    private Vector3 MovePos;

    void Start()
    {
        MovePos = bgs[bgs.Count - 1].transform.position;
    }

    void Update()
    {
        foreach (GameObject go in bgs)
        {
            go.transform.position -= new Vector3(moveSpeed, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹!");
        collision.transform.position = MovePos;
    }
}
