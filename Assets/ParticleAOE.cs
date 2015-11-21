using UnityEngine;
using System.Collections;

public class ParticleAOE : MonoBehaviour
{
    private int damage = 0;
    private SphereCollider collider;
    private int testFramesGone = 0;

    void Awake()
    {
        collider = GetComponent<SphereCollider>();
    }

    public void Activate(Vector3 position, int _damage, float radius)
    {
        damage = _damage;
        //collider.enabled = true;

        RaycastHit[] hitArray = Physics.SphereCastAll(position, 0.01f, transform.right, 0.01f);
        Debug.Log(hitArray.Length);
        for (int i = 0; i < hitArray.Length; i++)
        {
            if (hitArray[i].transform.tag == "Enemies")
            {
                hitArray[i].transform.GetComponent<EnemyBehaviour>().TakeDamage(damage);
            }
        }

        /*if (col.tag == "Enemies")
        {
            col.GetComponent<EnemyBehaviour>().TakeDamage(damage);
        }*/
        //ReturnToPool();
    }
  

    void ReturnToPool()
    {
        //collider.enabled = false;
        gameObject.SetActive(false);
    }
}
