using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{

	private GameObject jugador;
	
	private void OnCollisionEnter(Collision collision) //la entrada es un collision, objecto que entra en colision
    {
    	jugador = GameObject.FindWithTag("Player");
    	GameObject objeto = collision.gameObject;
    	if(objeto == jugador) {
    		Destroy(jugador);
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
