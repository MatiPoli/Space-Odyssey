using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Nave : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movimiento;

    [Header("Movimiento")]
    public float velocidad = 10f;
    public float velocidad_rotacion = 60f;
    
    [Header("Mouse")]
    public bool cursorLocked=true;

    // Awake is called first, even if the script is not enabled
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(cursorLocked)
            Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision col)
    {
        string nombre = col.gameObject.name;
        if (nombre.Remove(nombre.Length - 1) == "Pared") // Colisionamos con una de las paredes del mapa
            return;
        for(int i=0;i<nombre.Length;i++)                 // Me quedo con solo la primera palabra del objeto con el que colisione
             if(nombre[i]==' ')
             {
                 nombre = nombre.Substring(0, i);
                 break;
             }
        SceneManager.LoadScene("Scenes/Planetas/" + char.ToUpper(nombre[0]) + nombre.Substring(1)); // Ejemplo: Si colisione con el objeto "earth del espacio", entonces va a cargar una escena con nombre "Earth"
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movimiento = new Vector3(0, 0, verticalInput);
        if (horizontalInput<0) transform.Rotate(new Vector3(0, -velocidad_rotacion * Time.deltaTime, 0));
        if (horizontalInput>0) transform.Rotate(new Vector3(0, velocidad_rotacion * Time.deltaTime, 0));
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
