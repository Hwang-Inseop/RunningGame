using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SparkleEffect : MonoBehaviour
{
    public GameObject[] targetObject;
    void Start()
    {
        foreach(GameObject stars in targetObject)
        {
            SpriteRenderer sr = stars.GetComponent<SpriteRenderer>();
            if(sr!= null)
            {
                Color originalColor = sr.color;  //현재 컬러를 저장
                Color yellowColor = Color.yellow;
                Color brightColor = new Color(
                    Mathf.Min(originalColor.r * 2.5f, 1f),
                    Mathf.Min(originalColor.g * 2.5f, 1f),
                    Mathf.Min(originalColor.b * 2.5f, 1f),
                    originalColor.a);

                Sequence seq = DOTween.Sequence(); //여러개의 애니메이션을 연속적으로 연결할 수 있는 Class
                seq.Append(sr.DOColor(brightColor,1f)); //1초동안 brightColor설정값으로 변경
                seq.Append(sr.DOColor(yellowColor, 1f));
                seq.Append(sr.DOColor(originalColor, 1f));
                sr.DOFade(0.3f, 1f)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
            }
        }
    }
}
