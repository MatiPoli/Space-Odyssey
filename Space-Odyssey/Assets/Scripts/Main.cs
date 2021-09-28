using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public float velocidad = 100;
    public GameObject planeta; // Planeta actual
    private Rigidbody rb;
    private bool enPiso=true;
    private Vector3 movimiento;
    public float fuerzaSalto = 500000f;

    // Use this for initialization
    void Start()
    {
        aplicarGravedad();

        rb = GetComponent<Rigidbody>();
    }

    void mover()
    {
        float vert = Input.GetAxisRaw("Vertical"), hori = Input.GetAxisRaw("Horizontal");
        movimiento = new Vector3(0, 0,vert).normalized;
        transform.Translate(movimiento * velocidad * Time.deltaTime);
        if (hori<0) { transform.Rotate(new Vector3(0, -velocidad * Time.deltaTime, 0)); }
        if (hori>0) { transform.Rotate(new Vector3(0, velocidad * Time.deltaTime, 0)); }
        if (Input.GetKeyDown(KeyCode.Space) && enPiso) { rb.AddForce(transform.up * fuerzaSalto); }
        
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + (transform.TransformDirection(movimiento) * velocidad * Time.deltaTime))
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

    void aplicarGravedad()
    {
        Physics.gravity = planeta.transform.position - transform.position;  // Hace que el vector gravedad siempre apunte al centro del planeta.
        transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation; // Alinea el eje Y del personaje con el vector gravedad del planeta.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){ SceneManager.LoadScene("Scenes/Espacio");} // Solucion temporal para ir a la nave
        aplicarGravedad();
        mover();
    }
}