using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDisplay : MonoBehaviour
{
    [Header("캐릭터 이미지 배열")]
    public Sprite[] characterSprites;

    [Header("생성할 캐릭터 수")]
    public int countPlayer = 5;

    [Header("생성될 최종 위치 범위")]
    public Vector2 minPosition; 
    public Vector2 maxPosition;

    [Header("애니메이션 설정")]
    public float animationDuration = 3f; // 애니메이션 지속 시간
    public float spawnOffset = 2f;
    void Start()
    {
        if(characterSprites.Length<countPlayer)
        {
            Debug.LogError("캐릭터 생성시 에러 발생");
        }
        for(int i=0; i<countPlayer; i++)
        {
            float randX = Random.Range(minPosition.x, maxPosition.x);
            float randY = Random.Range(minPosition.y, maxPosition.y);
            Vector3 targetPosition = new Vector3(randX, randY, 0); //랜덤 위치로 생성

            Vector3 spawnPosition = targetPosition + new Vector3(0, spawnOffset, 0);

            GameObject displayPlayer = new GameObject($"{i}번째 DisplayPlayer");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
