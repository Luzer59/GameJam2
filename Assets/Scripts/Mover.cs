using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

	void Start () {
        if (GetComponent<Rigidbody>().position.x < 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (GetComponent<Rigidbody>().position.x >= 0)
        {
            GetComponent<Rigidbody>().velocity = transform.right * -speed;
        }
	}
    void OnTriggerEnter(Collider StopPosition)
    {
        GetComponent<Rigidbody>().velocity = transform.right * 0;
    }
	
}
