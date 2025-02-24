using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LobbyBGLooper : MonoBehaviour
{
    [Header("Background 리스트")]
    public List<GameObject> bgs = new List<GameObject>();

    [Header("Background를 반복시킬 Looper")]
    public GameObject looper;

    [Header("StageInfo")]
    public List<StageInfo> stages = new List<StageInfo>();

    [Header("이동 속도")]
    private float moveSpeed = 0.005f;

    [Header("이동시킬 위치")]
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
        //Debug.Log("충돌!");
        collision.transform.position = MovePos;
    }

    public void ChangeBackground()
    {
        StageInfo stage = stages.FirstOrDefault(stage => stage.StageNum == PlayerPrefs.GetInt("choosedStage"));
        foreach (GameObject go in bgs)
        {
            go.transform.GetComponent<SpriteRenderer>().sprite = stage.Background;
        }
    }
}
