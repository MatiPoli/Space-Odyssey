using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 10f;
    Vector3 movimiento;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal")).normalized;
    }

    void FixedUpdate()
    {
        mover(movimiento);    
    }

    void mover(Vector3 direcson)
    {
        rb.MovePosition(rb.position + (transform.TransformDirection(direcson) * velocidad * Time.deltaTime));
    }
}
