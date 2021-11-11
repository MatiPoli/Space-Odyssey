using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaOxigeno : MonoBehaviour
{

	private float oxigenoActual;
	private float distancia;
	private GameObject jugador;
/*
	private void OnCollisionStay(Collision collision){

		jugador = GameObject.FindWithTag("Player");
    	GameObject objeto = collision.gameObject;

    	if(jugador == objeto) {
    		distancia = jugador.GetComponent<DistEntreObj>().calcularDistancia();
    		oxigenoActual = jugador.GetComponent<Variables>().oxigeno;

    		if(oxigenoActual < 100) {
    			
    			jugador.GetComponent<Variables>().aumentarOxigeno(0.1f);

    		}

    	}

	}*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	jugador = GameObject.FindWithTag("Player");
    	//GameObject objeto = collision.gameObject;
    		distancia = jugador.GetComponent<DistEntreObj>().calcularDistancia();
    		//Debug.Log(distancia);
    		oxigenoActual = jugador.GetComponent<Variables>().oxigeno;
			//Debug.Log(oxigenoActual);
    		if(distancia < 50) {
    			if(oxigenoActual < 100) {
    			
    			jugador.GetComponent<Variables>().aumentarOxigeno(0.01f);

    		}
    		}
    		
        
    }
}
