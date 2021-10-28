using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimacion : MonoBehaviour
{
    Animator animator;
    private bool enPiso=true;
    public GameObject planeta;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject == planeta)
        {
            enPiso=true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject == planeta)
        {
            enPiso=false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        bool isJumping = animator.GetBool("isJumping");
        bool isWalking = animator.GetBool("isWalking");
        bool isWalkingBackwards = animator.GetBool("isWalkingBackwards");
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool spacePressed = Input.GetKey("space");

        if (!isWalkingBackwards && backwardPressed)
        {
            animator.SetBool("isWalkingBackwards", true);
        }

        if (isWalkingBackwards && !backwardPressed)
        {
            animator.SetBool("isWalkingBackwards", false);
        }

        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        if (spacePressed && !isJumping)
        {
            animator.SetBool("isJumping", true);
        }

        if (!spacePressed  && isJumping)
        {
            animator.SetBool("isJumping", false);
        }

        
    }
}
