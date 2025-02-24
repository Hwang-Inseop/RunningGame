using RunningGame.Managers;
using RunningGame.Utils;
using UnityEngine;

public class PatternLooper : MonoBehaviour
{
    [SerializeField] private Transform patternScroller;
    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;
    
    private const int bgCount = 5;
    private const float bgWidth = 20f;
    private readonly Vector3 bgOffset = new Vector3(bgWidth * bgCount, 0, 0);
    
    private int selectedStage;

    public void Init(int key)
    {
        selectedStage = key;
        switch (key)
        {
            case 1:
                stage1.SetActive(true);
                stage2.SetActive(false);
                stage3.SetActive(false);
                break;
            case 2:
                stage1.SetActive(false);
                stage2.SetActive(true);
                stage3.SetActive(false);
                break;
            case 3:
                stage1.SetActive(false);
                stage2.SetActive(false);
                stage3.SetActive(true);
                break;
            default:
                Debug.LogError("PatternLooper : Invalid stage key");
                break;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(Define.LoopableTag)) return;
        
        Debug.Log("OnTriggerEnter2D : Loopable entered");
        if (!MainPoolManager.Instance.IsExistPool(other.name))
        {
            // other.gameObject.SetActive(false);
        }
        else
            MainPoolManager.Instance.Despawn(other.gameObject);
        
        var pattern = MainPoolManager.Instance.Spawn(GetPatternKey(), patternScroller);
        pattern.transform.position = other.transform.position + bgOffset;
    }
    
    private string GetPatternKey()
    {
        var randomIndex = Random.Range(1, Define.PatternMaxCount + 1);
        return $"{Define.PatternKey}{selectedStage.ToString()}_0{randomIndex.ToString()}";
    }
}
