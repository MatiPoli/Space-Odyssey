using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject planeta; // Planeta actual
    private float velocidad = 100;

    // Use this for initialization
    void Start()
    {
        
    }
    
    void mover()
    {
        if(Input.GetKey(KeyCode.W)) { transform.Translate(new Vector3(0,0,velocidad*Time.deltaTime));  }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(new Vector3(0, 0, -velocidad * Time.deltaTime)); }
        if (Input.GetKey(KeyCode.A)) { transform.Rotate(new Vector3(0, -velocidad * Time.deltaTime, 0)); }
        if (Input.GetKey(KeyCode.D)) { transform.Rotate(new Vector3(0, velocidad * Time.deltaTime, 0)); }
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        Physics.gravity = planeta.transform.position - transform.position;  // Hace que el vector gravedad siempre apunte al centro del planeta(creo).

        transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation; // Tengo que investigar la matematica detras de esto, pero basicamente alinea el eje Y del personaje con el del planeta.
        
    }
}