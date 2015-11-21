using UnityEngine;
using System.Collections;

public class AimParticles : MonoBehaviour
{
    public int firePoolIndex;
    public int particleAOEIndex;
    private ParticleCollisionEvent[] collisionEvents;
    private ParticleSystem part;
    private PoolController poolController;
    public int damage = 1;
    public float radius = 0.5f;

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

        // !!!do not remove this!!!
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        if (other.tag != "Enemies")
        {
            ActivateGroundFireEffect();
        }

        Collider[] colliders = Physics.OverlapSphere(collisionEvents[0].intersection, radius);

        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemies")
            {
                col.GetComponent<EnemyBehaviour>().TakeDamage(damage);
            }
        }
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
