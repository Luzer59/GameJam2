using UnityEngine;
using System.Collections;

public class ShootLazor : MonoBehaviour {
    public Transform prefab;
    public int laserDelay = 5;

    void OnTriggerEnter(Collider StopPosition)
    {
        StartCoroutine(shootlasers());
    }
    IEnumerator shootlasers()
    {
        int i = 0;
        while (i < 30)
        {
            yield return new WaitForSeconds(laserDelay);
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            
            i++;
        }
    }
}
