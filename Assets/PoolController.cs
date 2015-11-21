using UnityEngine;
using System.Collections.Generic;

public class PoolController : MonoBehaviour
{
    public GameObject[] pooledObjects;
    public int[] poolBuffer;
    public List<GameObject>[] pools;
    private GameObject instance;
    private Transform container;

    void Start()
    {
        pools = new List<GameObject>[pooledObjects.Length];
        for (int i = 0; i < pooledObjects.Length; i++)
        {
            pools[i] = new List<GameObject>();
            container = new GameObject(pooledObjects[i].name + " Container").transform;
            container.SetParent(transform);
            for (int u = 0; u < poolBuffer[i]; u++)
            {
                instance = (GameObject)Instantiate(pooledObjects[i]);
                pools[i].Add(instance);
                //instance.GetComponent<PoolInfo>().container = transform;
                instance.transform.SetParent(transform);
                instance.SetActive(false);
            }
        }
    }
}
