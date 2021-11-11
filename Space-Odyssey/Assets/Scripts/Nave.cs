using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movimiento;
    public float velocidad = 10f;
    public float velocidad_rotacion = 60f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = this.GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Click!");
        SceneManager.LoadScene("Scenes/Planetas/Earth");
    }
    void OnCollisionEnter(Collision col)
    {
        string nombre = col.gameObject.name;
        if(nombre != "Pared1" && nombre != "Pared2" && nombre != "Pared3" && nombre != "Pared4" && nombre != "Pared5")
        {
            for(int i=0;i<nombre.Length;i++)
                if(nombre[i]==' ')
                {
                    nombre = nombre.Substring(0, i);
                    break;
                }
            if (nombre == "lowpoly_earth")
                SceneManager.LoadScene("Scenes/Juego");
            else
                SceneManager.LoadScene("Scenes/Planetas/" + char.ToUpper(nombre[0]) + nombre.Substring(1));
        }
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Pause"); // Solucion temporal para salir del juego
        movimiento = new Vector3(0, 0, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, -velocidad_rotacion * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, velocidad_rotacion * Time.deltaTime, 0));
    }

    void FixedUpdate()
    {
        if (movimiento.z < 0)
            mover(movimiento, velocidad / 2);
        else
            mover(movimiento, 3*velocidad / 2);
    }

    void mover(Vector3 move, float velocidad)
    {
        rb.AddRelativeForce(movimiento * velocidad);
    }
   
}
