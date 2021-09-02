using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private CharacterController controller;
    public GameObject planeta; // Planeta actual

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = planeta.transform.position - transform.position;  // Hace que el vector gravedad siempre apunte al centro del planeta(creo).

        transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation; // Tengo que investigar la matematica detras de esto, pero basicamente alinea el eje Y del personaje con el del planeta.
        
    }
}