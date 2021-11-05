using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozo : MonoBehaviour
{
	private GameObject jugador;
	private float vidaActual;
	private float tiempo = 0.0f;

	/*
	private void OnCollisionStay(Collision collision) //la entrada es un collision, objecto que entra en colision
    {

    	jugador = GameObject.FindWithTag("Player");
    	GameObject objeto = collision.gameObject;

    	if(jugador == objeto) {

    		tiempo += Time.deltaTime;

    		//accedo a la vida que esta en damageTarget
    		vidaActual = jugador.GetComponent<Variables>().getVida(); 

    		if(tiempo >= 15.0f) {
    			vidaActual = vidaActual - 50;
    			jugador.GetComponent<DamageTarget>().actualizarVida(vidaActual);
    		}

    	}

    }
	*/

	private void OnCollisionEnter(Collision collision) //la entrada es un collision, objecto que entra en colision
    {

    	jugador = GameObject.FindWithTag("Player");
    	GameObject objeto = collision.gameObject;

    	if(jugador == objeto) {

    		//accedo a la vida que esta en damageTarget
    		vidaActual = jugador.GetComponent<Variables>().getVida(); 

    		vidaActual = vidaActual - 20;
    		jugador.GetComponent<DamageTarget>().actualizarVida(vidaActual);

    	}

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
