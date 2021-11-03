using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 10f;
    public Transform cam;
    Vector3 movimiento;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    //Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb=GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        mover(movimiento);    
    }

    void mover(Vector3 direcson)
    {
        if (direcson.magnitude <= 0.1f)
        {
            //animator.SetBool("isWalking", false);
            return;
        }

        Vector3 moveDir = direcson;

        //if (cam != null)
        //{
        //    float targetAngle = Mathf.Atan2(direcson.x, direcson.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //
        //   moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //}

        //cam.transform.Translate(direcson * velocidad * Time.deltaTime);
        transform.Translate(moveDir.normalized * velocidad * Time.deltaTime);
    }
}
