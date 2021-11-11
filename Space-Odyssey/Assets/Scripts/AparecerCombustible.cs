using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerCombustible : MonoBehaviour
{

	public GameObject myPrefab;
	public Transform respawn;
	//private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	float distancia;

    	distancia = this.GetComponent<DistEntreObj>().calcularDistancia();

    	if(Input.GetKeyDown("p")){
	    	if(distancia <= 50.0f){
	    		GameObject instantiatedObject = Instantiate(myPrefab, respawn.position, respawn.rotation, null);
	            instantiatedObject.name = "Gasolina";
	            instantiatedObject.AddComponent<Rigidbody>();
	            instantiatedObject.GetComponent<Rigidbody>().freezeRotation = true;
	    	}
        }
    }
}
