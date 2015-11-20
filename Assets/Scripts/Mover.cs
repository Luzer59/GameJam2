using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

	void Start () {
        if (GetComponent<Rigidbody2D>().position.x < 0)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        if (GetComponent<Rigidbody2D>().position.x >= 0)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
        }
	}
    void OnTriggerEnter2D(Collider2D StopPosition)
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * 0;
    }
	
}
