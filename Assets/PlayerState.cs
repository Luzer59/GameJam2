using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

    public int maxHealth = 100;
    public int health;
    public bool GameOver = false;
    public GameObject healthBar;

    private float t;

	void Start () 
    {
        health = maxHealth;
	}
	void Update () 
    {
	    if(health <= 0 && !GameOver)
        {
            GameOver = true;
            StartCoroutine(GetComponent<PlayerDeath>().DeathEffect());
        }
	}
    public void TakeDamage(int damage)
    {
        health -= damage;
        t = (float)health / (float)maxHealth;
        healthBar.transform.localPosition = new Vector3(healthBar.transform.localPosition.x, Mathf.Lerp(-75f, 0f, t), healthBar.transform.localPosition.z);
    }


}
