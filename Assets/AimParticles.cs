using UnityEngine;
using System.Collections;

public class AimParticles : MonoBehaviour
{
    private ParticleCollisionEvent[] collisionEvents;
    private ParticleSystem part;

    void Awake()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new ParticleCollisionEvent[16];
    }

    void OnParticleCollision(GameObject other)
    {
        int safeLength = part.GetSafeCollisionEventSize();
        if (collisionEvents.Length < safeLength)
            collisionEvents = new ParticleCollisionEvent[safeLength];

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            Debug.Log(collisionEvents[i].intersection);
            /*Vector3 pos = collisionEvents[i].intersection;
            Vector3 force = collisionEvents[i].velocity * 10;*/
        }
    }
}
