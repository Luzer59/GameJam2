using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public int EnemyHealth = 100;
    int maxhealth = 100;
    bool isdead = false;
    bool onfire = false;
    private int BurningDamage = 10;
    Animator animator;
    public GameObject Fire;
    public int damage = 5;
    private GameObject tower;
    public bool IsFlyingEnemy = false;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tower = GameObject.Find("Tower");
        GameObject Fire = new GameObject();
        animator = GetComponent<Animator>();
        maxhealth = EnemyHealth;
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
    
    void OnTriggerEnter(Collider StopPosition)
    {
        GetComponent<Rigidbody>().velocity = transform.right * 0;
        if (IsFlyingEnemy == false)
        {
            StartCoroutine(hittower());
        }
    }
    IEnumerator hittower()
    {
        //int i = 0;
        while (player.GetComponent<PlayerState>().GameOver == false)
        {
            yield return new WaitForSeconds(1);
            //i = tower.GetComponent<TowerController>().getpiece();
            tower.GetComponent<TowerController>().TakeDamage(damage);
                
        }

    }

}
