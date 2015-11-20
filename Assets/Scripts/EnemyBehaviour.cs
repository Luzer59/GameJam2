using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public int EnemyHealth = 100;

    void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
    }
}
