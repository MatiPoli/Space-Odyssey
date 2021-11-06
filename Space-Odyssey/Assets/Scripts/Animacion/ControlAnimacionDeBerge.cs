using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ControlAnimacionDeBerge : MonoBehaviour
{
    Animator animator;

    private bool enPiso;
    private bool saltando;

    public bool esPlayer = false;


    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumping = animator.GetBool("isJumping");

        bool isWalking = animator.GetBool("isWalking");
        bool isWalkingBackwards = animator.GetBool("isWalkingBackwards");
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");

        if(esPlayer)
        {
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

            if (!enPiso && saltando && !isJumping)
            {
                animator.SetBool("isJumping", true);
            }

            if (isJumping && !saltando && enPiso)
            {
                animator.SetBool("isJumping", false);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackwards", false);
        }

    }
}
