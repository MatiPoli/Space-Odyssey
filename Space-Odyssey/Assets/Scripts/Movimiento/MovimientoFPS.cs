using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFPS : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad = 10f;
    public Transform cam;
    //Animator animator;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;

    public float fuerzaSalto=100;

    // Para detectar el piso
    public Transform groundCheck;
    public float groundDistance=0.1f;
    public LayerMask groundMask;

    // Linterna
    public Light flashlight;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        mover(movimiento);
        if (Input.GetKey(KeyCode.Space) && enPiso())
            saltar();
        if (Input.GetKeyDown("f")) {
            triggerFlashlight();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void rotateOnCameraDirection()
    {
        Quaternion rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0).normalized;
        this.transform.rotation = rotation;
    }

    void saltar()
    {
        rb.AddForce(fuerzaSalto * transform.up);
    }

    void mover(Vector3 direcson)
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * 250f);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * 250f;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cam.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 targetMovementAmount = direcson * velocidad;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMovementAmount, ref smoothMoveVelocity, .15f);

        if (Input.GetKey(KeyCode.Space) && enPiso())
            saltar();
    }

    bool enPiso()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void triggerFlashlight() {
        flashlight.enabled = !flashlight.enabled;
    }
}
