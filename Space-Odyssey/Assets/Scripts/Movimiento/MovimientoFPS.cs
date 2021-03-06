using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoFPS : MonoBehaviour
{
    Rigidbody rb;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;

    [Header("Movimiento")]
    public float velocidad = 10f;
    public float fuerzaSalto = 100;

    [Header("Camara")]
    public Transform cam;

    [Header("Animaciones")]
    public Animator animator;

    // Para detectar el piso
    [Header("Deteccion de piso")]
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;


    // Linterna
    [Header("Linterna")]
    public Light flashlight;
    
    [Header("Mouse")]
    public float sensibilidadVertical = 250f;
    public float sensibilidadHorizontal = 250f;
    public bool bloquearCursor;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        #region Manejo de errores
        if (animator == null)
            Debug.LogWarning("No se a seleccionado un Animator para el personaje",animator);
        if (cam == null)
            Debug.LogWarning("No se a seleccionado una camara para el personaje",cam);
        if (groundCheck == null)
            Debug.LogWarning("El personaje no podra saltar sin un groundCheck",groundCheck);
        if (groundMask.value==0)
            Debug.LogWarning("groundMask seleccionado en Nothing, el personaje no saltara bajo estas condiciones", this);
        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        if (bloquearCursor)
            Cursor.lockState = CursorLockMode.Locked;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimiento = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        mover(movimiento);

        if (Input.GetKey(KeyCode.Space) && enPiso())
            saltar();
        if (Input.GetKeyDown("l")) {
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

        #region Animaciones de caminata
        if (animator!=null)
        {
            bool isWalking = false, isWalkingBackwards = false;
            if (direcson.z > 0)
                isWalking = true;
            if (direcson.z < 0)
                isWalkingBackwards = true;

            if (animator.GetBool("isWalking") != isWalking)
                animator.SetBool("isWalking", isWalking);
            if (animator.GetBool("isWalkingBackwards") != isWalkingBackwards)
                animator.SetBool("isWalkingBackwards", isWalkingBackwards);
        }
        #endregion

        #region Movimiento de camara
        if (cam != null)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * sensibilidadHorizontal);
            verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibilidadVertical;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
            cam.localEulerAngles = Vector3.left * verticalLookRotation;
        }
        #endregion

        #region Movimiento de Personaje
        Vector3 targetMovementAmount = direcson * velocidad;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMovementAmount, ref smoothMoveVelocity, .15f);
        #endregion

        #region Salto
        bool en_piso = enPiso();
        if (en_piso && animator!=null)
            animator.SetBool("isJumping", false);
        if (Input.GetKey(KeyCode.Space))
        {
            if (en_piso)
            {
                if(animator!=null)
                    animator.SetBool("isJumping", true);
                saltar();
            }
        }
        #endregion
    }

    bool enPiso()
    {
        if (groundCheck == null)
            return false;
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void triggerFlashlight() {
        flashlight.enabled = !flashlight.enabled;
    }
}
