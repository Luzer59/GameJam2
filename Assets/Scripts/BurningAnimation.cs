using UnityEngine;
using System.Collections;

public class BurningAnimation : MonoBehaviour 
{

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
public void changesprite(bool onfire)
    {
        animator.SetBool("Burning", onfire);
    }
}
