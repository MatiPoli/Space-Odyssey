using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerCombustible : MonoBehaviour
{

	public GameObject myPrefab;
	public Transform respawn;
	public Canvas fondo;

    // Start is called before the first frame update
    void Start()
    {
        fondo.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    	float distancia;

    	distancia = this.GetComponent<DistEntreObj>().calcularDistancia();

        if(distancia <=  50.0f) {
            fondo.GetComponent<Canvas>().enabled = true;
        } else {
            fondo.GetComponent<Canvas>().enabled = false;
        }

    	if(Input.GetKeyDown("p")){
	    	if(distancia <= 30.0f){
	    		GameObject instantiatedObject = Instantiate(myPrefab, respawn.position, respawn.rotation, null);
	            instantiatedObject.name = "Gasolina";
	            //instantiatedObject.AddComponent<Rigidbody>();
	            instantiatedObject.GetComponent<Rigidbody>().freezeRotation = true;
	    	}
        }
    }
}
