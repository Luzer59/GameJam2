using UnityEngine;
using System.Collections;

public class ShootLazor : MonoBehaviour
{
    public Transform prefab;
    public int laserDelay = 5;
    public GameObject shootsound;

    private GameObject player;

    void Awake()
    {
        shootsound.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
            shootsound.SetActive(false);
            shootsound.SetActive(true);
            Quaternion newRotation = Quaternion.LookRotation(transform.forward, transform.position - (player.transform.position + new Vector3(0f, 1f, 0f)));
            
            newRotation *= Quaternion.Euler(0f, 0f, 90f * Mathf.Sign(transform.localScale.x));

            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 0), newRotation);
            
            i++;
        }
    }
}
