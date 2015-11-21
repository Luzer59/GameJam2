using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    //public GameObject Tower;
    //public GameObject Player;
    public int EnemyHealth = 100;
    int maxhealth = 100;
    bool isdead = false;
    bool onfire = false;
    private int BurningDamage = 10;
    Animator animator;
    public GameObject Fire;
    
    void Start()
    {
        GameObject Fire = new GameObject();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(EnemyHealth <= 0.8f*maxhealth)
        {

            onfire = true;
            Fire.GetComponent<BurningAnimation>().changesprite(onfire);
            StartCoroutine(Burning());

        }
        
        if (EnemyHealth <= 0)
        {
            isdead = true;
            animator.SetBool("Dead", isdead);
            StartCoroutine(EnemyDeath());
        }
    }

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
    }

     IEnumerator EnemyDeath()
    {
        if (isdead)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
    }

    IEnumerator Burning()
     {
         yield return new WaitForSeconds(1);
         GetComponent<EnemyBehaviour>().TakeDamage(BurningDamage);
         


     }

}
