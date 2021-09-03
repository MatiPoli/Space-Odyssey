using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public float velocidad = 100;
    public GameObject planeta = null; // Planeta actual
    public float size;
    // public Rigidbody player;

    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(size, size, size);
        aplicarGravedad();
    }

    void mover()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(new Vector3(0, 0, -velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.A)) { transform.Rotate(new Vector3(0, -velocidad * Time.deltaTime, 0)); }
        if (Input.GetKey(KeyCode.D)) { transform.Rotate(new Vector3(0, velocidad * Time.deltaTime, 0)); }
        // if (Input.GetKeyDown(KeyCode.Space)) { player.AddForce(transform.up * 500000); } -> hay que ver el error!!!!!
    }
    void aplicarGravedad()
    {
        if (planeta != null)
        {
            Physics.gravity = planeta.transform.position - transform.position;  // Hace que el vector gravedad siempre apunte al centro del planeta.

            transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation; // Alinea el eje Y del personaje con el vector gravedad del planeta.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){ SceneManager.LoadScene("Scenes/Menu");} // Solucion temporal para salir del juego
        aplicarGravedad();
        mover();
    }
}