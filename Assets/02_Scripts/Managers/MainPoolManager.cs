using System.Collections.Generic;
using RunningGame.Singleton;
using UnityEngine;

namespace RunningGame.Managers
{
    public class MainPoolManager : SceneSingleton<MainPoolManager>
    {
        private readonly Dictionary<string, Queue<GameObject>> poolDict = new();
        private readonly Dictionary<string, GameObject> prefabDict = new();
        private readonly Dictionary<string, Transform> parentDict = new();
        private readonly HashSet<GameObject> despawnObj = new();
        private Transform poolParent;

        public override void Init()
        {
            poolParent = new GameObject("PoolParent").transform;
        }
        
        public void AddPool(GameObject prefab, int poolSize = 5)
        {
            string poolKey = prefab.name;
            
            if (poolDict.ContainsKey(poolKey))
            {
                Debug.LogWarning($"MainPoolManager: {poolKey} is already exist.");
                return;
            }

            poolDict.Add(poolKey, new Queue<GameObject>());
            prefabDict.Add(poolKey, prefab);

            var poolRoot = new GameObject(poolKey + "_Root");
            poolRoot.transform.SetParent(poolParent);
            parentDict.Add(poolKey, poolRoot.transform);

            for (int i = 0; i < poolSize; i++)
            {
                var parent = parentDict[poolKey];
                var obj = Instantiate(prefab, parent);
                obj.name = poolKey;
                obj.SetActive(false);
                poolDict[poolKey].Enqueue(obj);
            }
        }

        public GameObject Spawn(string poolKey, Vector3 position = default, Quaternion rotation = default)
        {
            if (poolDict.TryGetValue(poolKey, out var poolQueue))
            {
                if (poolQueue.Count == 0)
                {
                    var prefab = prefabDict[poolKey];
                    GameObject obj = Instantiate(prefab);
                    obj.name = poolKey;
                    obj.SetActive(false);
                    poolDict[poolKey].Enqueue(obj);
                }

                GameObject spawnObj = poolDict[poolKey].Dequeue();
                spawnObj.SetActive(true);
                spawnObj.transform.position = position;
                spawnObj.transform.rotation = rotation;
                despawnObj.Remove(spawnObj);
                
                return spawnObj;
            }

            Debug.LogWarning($"MainPoolManager: {poolKey} is not exist.");
            return null;
        }

        public GameObject Spawn(string poolKey, Transform parent)
        {
            GameObject obj = Spawn(poolKey);
            obj.transform.SetParent(parent);
            return obj;
        }

        public void Despawn(GameObject obj)
        {
            if (despawnObj.Contains(obj))
            {
                Debug.LogWarning($"MainPoolManager: {obj.name} is already despawned.");
                return;
            }
            
            string poolKey = obj.name;
            if (!poolDict.TryGetValue(poolKey, out var poolQueue))
            {
                Debug.LogWarning($"MainPoolManager: {poolKey} is not exist.");
                return;
            }
            
            obj.SetActive(false);
            obj.transform.SetParent(parentDict[poolKey]);
            poolDict[poolKey].Enqueue(obj);
            despawnObj.Add(obj);
        }
    }

    public enum PatternType
    {
        Pattern1 = 1,
        Pattern2,
        Pattern3,
        Pattern4,
        Pattern5,
    }
}