using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    [Tooltip("Put object prefab here")]
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
}

public class ObjectPool : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    private void OnEnable()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            GameObject tmp;
            for (int i = 0; i < item.amountToPool; i++)
            {
                tmp = Instantiate(item.objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}