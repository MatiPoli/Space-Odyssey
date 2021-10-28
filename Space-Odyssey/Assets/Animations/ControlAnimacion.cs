using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimacion : MonoBehaviour
{
    Animator animator;
    public GameObject planeta;
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
        bool forwardPressed = Input.GetKey("w");
        bool spacePressed = Input.GetKeyDown(KeyCode.Space);
        if (!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        if (isWalking && spacePressed  && !isJumping)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isJumping", true);
        }

        
    }
}
