using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimacion : MonoBehaviour
{
    Animator animator;

    private bool enPiso;
    private bool saltando;
    private Main script;
    public GameObject Padre;


    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        script = Padre.GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {

        enPiso = script.enPiso;
        saltando = script.saltando;
        bool isJumping = animator.GetBool("isJumping");
        Debug.Log(isJumping);
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

        if (!enPiso && saltando && !isJumping)
        {
            animator.SetBool("isJumping", true);
        }

        if (isJumping && !saltando && enPiso)
        {
            animator.SetBool("isJumping", false);
        }

        
    }
}
