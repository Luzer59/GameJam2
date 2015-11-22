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
    private Transform body;
    private Direction direction = Direction.right;
    private PlayerState playerState;
    
    void Awake()
    {
        playerState = GetComponent<PlayerState>();
        aimTarget = GameObject.Find("AimTarget").transform;
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name == "Head")
            {
                head = children[i];
            }
            else if (children[i].name == "Body")
            {
                body = children[i];
            }
        }
    }

    void Update()
    {
        if (!playerState.GameOver)
        {
            AimAtTarget();
        }

        /*if(isLerpping)
        {

            float timeSinceStarted = Time.time - startTime;
            float percentage = timeSinceStarted / timeTakenToLerp;
            print(percentage);
            transform.localScale = Vector3.Lerp(startScale, endScale, percentage);

            if(percentage >= 1)
            {
                isLerpping = false;
            }

        }*/
    }

    void AimAtTarget()
    {
        Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, head.position - aimTarget.position);
        newRotation *= Quaternion.Euler(0f, 0f, -90f);
        head.rotation = newRotation;

        if (aimTarget.position.x < head.position.x)
        {
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

        Debug.DrawRay(head.position, head.right * 5f);
    }


    /*bool isLerpping;
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
    }*/

    void SwitchDirection()
    {
        body.localScale = new Vector3(-body.localScale.x, body.localScale.y, body.localScale.z);
        head.localScale = new Vector3(head.localScale.x, -head.localScale.y, head.localScale.z);
    }
}
