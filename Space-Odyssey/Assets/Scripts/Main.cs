using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public float velocidad = 100;
    public GameObject planeta; // Planeta actual
    public float size;
    private Rigidbody rb;
    private bool enPiso=true;

    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(size, size, size);
        aplicarGravedad();

        rb = GetComponent<Rigidbody>();
    }

    void mover()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(new Vector3(0, 0, -velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.A)) { transform.Rotate(new Vector3(0, -velocidad * Time.deltaTime, 0)); }
        if (Input.GetKey(KeyCode.D)) { transform.Rotate(new Vector3(0, velocidad * Time.deltaTime, 0)); }
        if (Input.GetKeyDown(KeyCode.Space) && enPiso) { rb.AddForce(transform.up * 500000); }
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