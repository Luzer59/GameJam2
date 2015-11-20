using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    //public GameObject Tower;
    //public GameObject Player;
    public int EnemyHealth = 100;

    void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
    }
    void EnemyDeath()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
