using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganador : MonoBehaviour
{
	public bool mejoraNave; // VARIABLE QUE DEFINE SI EL JUGADOR GANA O NO.

    private GameObject nave;
    private Renderer rend;
    Collider m_Collider;

/*
	void OnCollisionEnter(Collision collision) {

		float distancia;

		nave = GameObject.FindWithTag("Nave");
        GameObject objeto = collision.gameObject;

        distancia = nave.GetComponent<DistEntreObj>().calcularDistancia();

        if(nave == objeto){
        	if(distancia <= 70.0f) {
        		Debug.Log("ganaste");
        		SceneManager.LoadScene (sceneName:"Game Over");
        	}
        }

	}
*/
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;

        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider>();
        m_Collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    	float distancia;

        if (mejoraNave)
        {
            // Desactiva el collider cuando tenga las mejoras de la nave
            m_Collider.enabled = false;

            //Debug.Log("Collider.enabled = " + m_Collider.enabled);
        }


		nave = GameObject.FindWithTag("Nave");

        distancia = nave.GetComponent<DistEntreObj>().calcularDistancia();

        if(distancia <= 70.0f) {
        	Debug.Log("ganaste");
       		SceneManager.LoadScene (sceneName:"Game Over"); //HABRIA QUE CARGAR OTRA ESCENA CON CARACTERISTICAS SIMILARES A GAMEOVER
       	}
    }
}
