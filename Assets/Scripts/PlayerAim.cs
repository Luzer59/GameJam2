using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
    private Transform aimTarget;

    void Awake()
    {
        aimTarget = GameObject.Find("AimTarget").transform;
    }

    void Update()
    {
        /*Quaternion newRotation = Quaternion.LookRotation(aimTarget.position);
        newRotation *= Quaternion.Euler(0f,-90f,0f);  
        GetComponent<Rigidbody2D>().rotation = newRotation;*/
        if (aimTarget.position.y >= transform.position.y)
        {
            GetComponent<Rigidbody2D>().rotation = Vector3.Angle(Vector3.right, aimTarget.position - transform.position);
        }
        else
        {
            GetComponent<Rigidbody2D>().rotation = 360f - Vector3.Angle(Vector3.right, aimTarget.position - transform.position);
        }

        Debug.DrawRay(transform.position, transform.right * 5f);
    }
}
