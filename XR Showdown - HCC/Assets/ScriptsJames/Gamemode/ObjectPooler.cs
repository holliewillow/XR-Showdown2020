using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public int amount_to_pool;
    public GameObject object_to_pool;
    public bool should_expand;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooled_objects;
    public List<ObjectPoolItem> items_to_pool;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooled_objects = new List<GameObject>();

        foreach (ObjectPoolItem item in items_to_pool)
        {
            for (int i = 0; i < item.amount_to_pool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.object_to_pool);
                obj.SetActive(false);
                pooled_objects.Add(obj);
            }
        }
    }


    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooled_objects.Count; i++)
        {
            if (!pooled_objects[i].activeInHierarchy && pooled_objects[i].tag == tag)
            {
                return pooled_objects[i];
            }
        }//end of for

        foreach (ObjectPoolItem item in items_to_pool)
        {
            if (item.object_to_pool.tag == tag)
            {
                if (item.should_expand)
                {
                    GameObject obj = (GameObject)Instantiate(item.object_to_pool);
                    obj.SetActive(false);
                    pooled_objects.Add(obj);
                    return obj;
                }
            }
        }//end of foreach
        return null;
    }
}
