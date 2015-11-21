using UnityEngine;
using System.Collections;

public class LazorMechanics : MonoBehaviour 
{
    public GameObject player;
    public int Damage = 10;
    public float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (GetComponent<Rigidbody>().position.x < 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * speed;
            transform.localScale = new Vector3(-0.3329205f, 0.3329205f, 0.3329205f);
        }
        if (GetComponent<Rigidbody>().position.x >= 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * -speed;
        }
    }

    void Update()
    {

    }

    Animator animator;
    void OnTriggerEnter(Collider StopPosition)
    {
        GetComponent<Rigidbody>().velocity = transform.right * 0;
        damageplayer();
        Destroy(gameObject);
    }
    void damageplayer()
    {
        player.GetComponent<PlayerState>().TakeDamage(Damage);
    }
}
