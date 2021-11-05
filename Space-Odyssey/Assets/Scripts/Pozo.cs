using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pozo : MonoBehaviour
{
	private GameObject jugador;
	private float vidaActual;
	private float tiempo = 0.0f;

	private void OnCollisionStay(Collision collision) //la entrada es un collision, objecto que entra en colision
    {

    	jugador = GameObject.FindWithTag("Player");
    	GameObject objeto = collision.gameObject;

    	if(jugador == objeto) {

    		tiempo += Time.deltaTime;

    		//accedo a la vida que esta en damageTarget
    		vidaActual = jugador.GetComponent<Variables>().getVida(); 

    		if(tiempo <= 2 || tiempo >= 5) {
    			vidaActual = vidaActual/2;
    			jugador.GetComponent<DamageTarget>().actualizarVida(vidaActual);
    		}

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
