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

    public Canvas fondo;

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

	void OnCollisionEnter(Collision collision) {
		fondo.GetComponent<Canvas>().enabled = true;
	}

	void OnCollisionExit(Collision collision) {
		fondo.GetComponent<Canvas>().enabled = false;
	}

    void Start()
    {   
    	fondo.GetComponent<Canvas>().enabled = false;

        if (PlayerPrefs.GetInt("inic4", 0) == 1)
        {
            PlayerPrefs.SetInt("powerup", 0);
            PlayerPrefs.SetInt("inic4", 0);
        }

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

        if (PlayerPrefs.GetInt("powerup", 0)==1)
        {
            // Desactiva el collider cuando tenga las mejoras de la nave
            m_Collider.enabled = false;
            Debug.Log("holaa");
            //Debug.Log("Collider.enabled = " + m_Collider.enabled);
        }


		nave = GameObject.FindWithTag("Nave");

        distancia = nave.GetComponent<DistEntreObj>().calcularDistancia();

        if(distancia <= 70.0f) {
        	Debug.Log("ganaste");
       		SceneManager.LoadScene ("Scenes/Menus/You win"); //HABRIA QUE CARGAR OTRA ESCENA CON CARACTERISTICAS SIMILARES A GAMEOVER
       	}
    }
}
