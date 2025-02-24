using RunningGame.Managers;
using RunningGame.Utils;
using UnityEngine;

public class PatternLooper : MonoBehaviour
{
    [SerializeField] private Transform patternScroller; 
    private const int bgCount = 5;
    private const float bgWidth = 20f;
    private readonly Vector3 bgOffset = new Vector3(bgWidth * bgCount, 0, 0);
    
    private string patternKey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(Define.LoopableTag)) return;
        
        Debug.Log("OnTriggerEnter2D : Loopable entered");
        if (!MainPoolManager.Instance.IsExistPool(other.name))
            other.gameObject.SetActive(false);
        else
            MainPoolManager.Instance.Despawn(other.gameObject);
        
        var pattern = MainPoolManager.Instance.Spawn(GetPatternKey(), patternScroller);
        pattern.transform.position = other.transform.position + bgOffset;
    }
    
    private string GetPatternKey()
    {
        var randomIndex = Random.Range(1, Define.PatternMaxCount + 1);
        return $"{patternKey}{randomIndex}";
    }

    public void SetPatternKey(string key)
    {
        patternKey = key;
    }
}
