using UnityEngine;
using System.Collections;

public class AimParticles : MonoBehaviour
{
    private int firePoolIndex;

    private ParticleCollisionEvent[] collisionEvents;
    private ParticleSystem part;
    private PoolController poolController;

    void Awake()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new ParticleCollisionEvent[16];
        poolController = GameObject.FindGameObjectWithTag("PoolController").GetComponent<PoolController>();
    }

    void OnParticleCollision(GameObject other)
    {
        int safeLength = part.GetSafeCollisionEventSize();
        if (collisionEvents.Length < safeLength)
            collisionEvents = new ParticleCollisionEvent[safeLength];

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        /*for (int i = 0; i < numCollisionEvents; i++)
        {

        }*/

        ActivateGroundFireEffect();

    }

    void ActivateGroundFireEffect()
    {
        for (int i = 0; i < poolController.pools[firePoolIndex].Count; i++)
        {
            if (!poolController.pools[firePoolIndex][i].activeInHierarchy)
            {
                poolController.pools[firePoolIndex][i].SetActive(true);
                poolController.pools[firePoolIndex][i].GetComponent<GroundFireEffect>().Activate(collisionEvents[0].intersection, collisionEvents[0].normal);
                break;
            }
        }
    }
}
