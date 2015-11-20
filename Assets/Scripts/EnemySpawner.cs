using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour 
{
	void Start () 
    {
        StartCoroutine(SpawnWaves());
	}

	void Update () 
    {
	
	}

    public bool IsFlying = false;
    public Vector2 spawnValues;
    public int hazardCount;
    public GameObject hazard;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    Vector2 spawnPosition;

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (IsFlying)
                {
                    spawnPosition = new Vector2(spawnValues.x, (float)Random.Range((float)-spawnValues.y, (float)spawnValues.y));
                }
                else
                {
                    spawnPosition = new Vector2(spawnValues.x, spawnValues.y);
                }
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

        }
    }
}
