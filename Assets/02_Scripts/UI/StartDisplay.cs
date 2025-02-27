using DG.Tweening;
using RunningGame.Managers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float animationDuration; // 애니메이션 지속 시간
    public float spawnOffset;

    [Header("캐릭터 간의 간격")]
    public float horizontal;

    private List<GameObject> spawnedPlayers = new List<GameObject>(); //두번째 애니메이션을 위한 위치 저장 리스트
    void Start()
    {

        Vector3 objectPosition = transform.position;
        Vector2 relativeMin = new Vector2(objectPosition.x + minPosition.x, objectPosition.y + minPosition.y);
        Vector2 relativeMax = new Vector2(objectPosition.x + maxPosition.x, objectPosition.y + maxPosition.y);
        if(characterSprites.Length<countPlayer)
        {
            Debug.LogError("캐릭터 생성시 에러 발생");
        }
        for(int i=0; i<countPlayer; i++)
        {
            float randX = Random.Range(relativeMin.x, relativeMax.x) + horizontal;
            float randY = Random.Range(relativeMin.y, relativeMax.y);
            Vector3 targetPosition = new Vector3(randX, randY, 0); //랜덤 위치로 생성

            Vector3 spawnPosition = targetPosition + new Vector3(0, spawnOffset, 0);

            GameObject displayPlayer = new GameObject($"{i}번째 DisplayPlayer");

            SpriteRenderer sr = displayPlayer.AddComponent<SpriteRenderer>();
            if (i < characterSprites.Length) //sprite 할당
            {
                sr.sprite = characterSprites[i];
            }
            else
            {
                sr.sprite = characterSprites[0]; //예외처리
                Debug.LogError("캐릭터 이미지가 없습니다.");
            }
            displayPlayer.transform.position = spawnPosition; //초기 위치
            displayPlayer.transform.localScale = Vector3.one * 1.5f; //초기 스케일보다 1.5배 크도록

            spawnedPlayers.Add(displayPlayer); //리스트에 추가

            StartCoroutine(AnimateEntry(displayPlayer, targetPosition));
        }
    }
    IEnumerator AnimateEntry(GameObject player, Vector3 targetPosition)
    {
        float timer = 0f;
        Vector3 startPosition = player.transform.position;

        while (timer < animationDuration)
        {
            timer += Time.deltaTime;
            float moveSpeed = timer / animationDuration; //애니메이션이 작동되는 동안의 스피드

            player.transform.position = Vector3.Lerp(startPosition, targetPosition, moveSpeed); //애니메이션의 위치

            yield return null;
        }
        player.transform.position = targetPosition;
    }
    public void OnStartButtonClicked()
    {
        float secondDuration = 1f;
        foreach(GameObject player in spawnedPlayers)
        {
            player.transform.DOMoveY(-13f, secondDuration).SetEase(Ease.InQuad);
        }
    }
}
