using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{
    private enum Direction
    {
        left,right
    }

    private Transform aimTarget;
    private Transform head;
    private Direction direction = Direction.right;
    private Rigidbody2D headRigidbody;

    
    void Awake()
    {
        aimTarget = GameObject.Find("AimTarget").transform;
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name == "Head")
            {
                head = children[i];
                break;
            }
        }
        headRigidbody = head.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        AimAtTarget();

        if(isLerpping)
        {

            float timeSinceStarted = Time.time - startTime;
            float percentage = timeSinceStarted / timeTakenToLerp;
            print(percentage);
            transform.localScale = Vector3.Lerp(startScale, endScale, percentage);

            if(percentage >= 1)
            {
                isLerpping = false;
            }

        }
    }

    void AimAtTarget()
    {
        if (aimTarget.position.y >= transform.position.y)
        {
            headRigidbody.rotation = Vector3.Angle(Vector3.right, aimTarget.position - transform.position);
        }
        else
        {
            headRigidbody.rotation = 360f - Vector3.Angle(Vector3.right, aimTarget.position - transform.position);
        }

        if (headRigidbody.rotation > 90f && headRigidbody.rotation < 270f)
        {
            headRigidbody.rotation *= -1;

            if (direction != Direction.left)
            {
                SwitchDirection();
                direction = Direction.left;
            }
        }
        else
        {
            if (direction != Direction.right)
            {
                SwitchDirection();
                direction = Direction.right;
            }
        }

        //Debug.DrawRay(transform.position, transform.right * 5f);
    }


    bool isLerpping;
    public float timeTakenToLerp  =0.4f;
    float startTime;
    Vector3 startScale;
    Vector3 endScale;


    void startLerp()
    {
        startTime = Time.time;
        startScale = transform.localScale;
        endScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isLerpping = true;
    }

   


    void SwitchDirection()
    {
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        startLerp();
        head.localScale = new Vector3(-head.localScale.x, -head.localScale.y, head.localScale.z);
    }
}
