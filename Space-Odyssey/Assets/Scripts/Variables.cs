using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Variables : MonoBehaviour
{
    public float vida;
    public float oxigeno;
    private float tiempo, tiempoSinOx;
    public bool sinOx = false;


    public void reducirOxigeno() { //lo uso para que se ahogue

    	oxigeno = oxigeno - 0.05f;

    }

    void Start()
    {
    	vida = 100;
    	oxigeno = 100;
    }

    void Update()
    {
    	tiempo += Time.deltaTime;
    	//oxigeno = oxigeno - (tiempo/1000); //disminuye proporcionalmente al tiempo

    	//si se mueve el oxigeno se consume más rapido
    	if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
    		oxigeno = oxigeno - 0.01f;
    	} else {
    		oxigeno = oxigeno - 0.001f;
    	}

    	sinOx = GetComponent<BarraDeOxigeno>().sinOxigeno;
    	if(sinOx) {
    		tiempoSinOx += Time.deltaTime; 
    		vida = vida - (tiempoSinOx/1000); //disminuye proporcionalmente al tiempo
    	} else {
    		sinOx = false; // para cuando este el sistema de recargar oxigeno
    		tiempoSinOx = 0.0f;
    	}
    }
}
