using RunningGame.Entity;
using RunningGame.Managers;
using RunningGame.Utils;
using UnityEngine;

public class PatternLooper : MonoBehaviour
{
    [SerializeField] private Transform patternScrollerTr;
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
        // LoopableItemTag인 경우 Despawn 하고 return
        if (other.CompareTag(Define.LoopableItemTag))
        {
            MainPoolManager.Instance.Despawn(other.gameObject);
            return;
        }
        
        // LoopableTag가 아닌 경우 return
        if (!other.CompareTag(Define.LoopableTag)) return;
        
        if (!MainPoolManager.Instance.IsExistPool(other.name))
        {
            other.gameObject.SetActive(false);
        }
        else
            MainPoolManager.Instance.Despawn(other.gameObject);
        
        var pattern = MainPoolManager.Instance.Spawn(GetPatternKey(), patternScrollerTr);
        pattern.transform.position = other.transform.position + bgOffset;
        
        var objectPlacer = pattern.GetComponent<TilemapObjectPlacer>();
        objectPlacer.PlaceObject();
    }
    
    private string GetPatternKey()
    {
        var randomIndex = Random.Range(1, Define.PatternMaxCount + 1);
        return $"{Define.PatternKey}{selectedStage.ToString()}_0{randomIndex.ToString()}";
    }
}
