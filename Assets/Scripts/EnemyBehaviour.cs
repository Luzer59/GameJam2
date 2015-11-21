using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    //public GameObject Tower;
    //public GameObject Player;
    public int EnemyHealth = 100;

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            EnemyDeath();
        }
    }

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
    }

    void EnemyDeath()
    {
            Destroy(gameObject);
    }

}
