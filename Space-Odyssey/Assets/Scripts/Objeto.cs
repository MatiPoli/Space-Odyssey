/*
  Script para darle gravedad a los objetos y se colocquen automaticamente sobre la superficie.
 Se necesita agregar un collider y el rigid body. Y asignar el planeta al que va a ser atraido
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objeto : MonoBehaviour
{

    public GameObject planeta; // Planeta al que atraemos objetos
    //Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //Bloqueo las rotaciones del objeto
        Rigidbody m_Rigidbody;
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        //Stop the Rigidbody from rotating
        m_Rigidbody.freezeRotation = true;

    	gravedadObjetos();
        
    }

    void OnMouseDown()
    {
        Debug.Log("Toca Objeto");
        SceneManager.LoadScene("Scenes/Espacio");
    }

    void gravedadObjetos()
    {
        Physics.gravity = planeta.transform.position - transform.position;  // Hace que el vector gravedad siempre apunte al centro del planeta.
        transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation; // Alinea el eje Y del personaje con el vector gravedad del planeta.
    }

    // Update is called once per frame
    void Update()
    {
        gravedadObjetos();
    }

    
}
