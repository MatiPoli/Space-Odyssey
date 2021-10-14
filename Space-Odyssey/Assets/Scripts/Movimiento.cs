using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 10f;
    public float sensibility = 10f;
    public Camera playerCamera;
    Vector3 movimiento;
    private float cameraVerticalAngle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb=GetComponent<Rigidbody>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal")).normalized;
        Debug.Log(rb.velocity);
    }

    void FixedUpdate()
    {
        mover(movimiento);    
    }

    private void Look() // Robadisimo de alex diaz
    {
        Vector3 rotationinput = Vector3.zero;

        rotationinput.x = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

        cameraVerticalAngle = cameraVerticalAngle + rotationinput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);
    }

    void mover(Vector3 direcson)
    {
        rb.MovePosition(rb.position + (transform.TransformDirection(direcson) * velocidad * Time.deltaTime));
    }
}
