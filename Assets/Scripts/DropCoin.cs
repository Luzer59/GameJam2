using UnityEngine;
using System.Collections;

public class DropCoin : MonoBehaviour
{
    private PoolController poolController;
    public int coinPoolIndex = 1;

    void Awake()
    {
        poolController = GameObject.FindGameObjectWithTag("PoolController").GetComponent<PoolController>();
    }

    void OnDestroy()
    {
        if (poolController)
        {
            for (int i = 0; i < poolController.pools[coinPoolIndex].Count; i++)
            {
                if (!poolController.pools[coinPoolIndex][i].activeInHierarchy)
                {
                    poolController.pools[coinPoolIndex][i].SetActive(true);
                    poolController.pools[coinPoolIndex][i].GetComponent<CoinToPouch>().Activate(transform.position);
                    break;
                }
            }
        } 
    }
}
