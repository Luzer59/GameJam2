using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

    public int health = 100;
    bool GameOver = false;
	void Start () 
    {
        health = 100;
	}
	void Update () 
    {
	    if(health <= 0 )
        {
            GameOver = true;
            health = 100;
        }
	}
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
