using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Variables : DamageTarget
{
    [Header("Oxigeno")]
    public float oxigeno;
    private float tiempo, tiempoSinOx;

	[Header("Consumo de oxigeno")]
    public float oxigenoPorSegundo=0.0001f;
	public float oxigenoPorMovimiento=0.001f;


	bool sinOx = false;


    public void reducirOxigeno(float amount) { //lo uso para que se ahogue
    	if(oxigeno>0)
			oxigeno -= amount;
		else
			sinOx=true;
    }
    
    public void aumentarOxigeno(float amount) {

    	oxigeno = oxigeno + amount;

    }

    new void Start()
    {
		base.Start();
    	oxigeno = 100;
    }

    new void Update()
    {
    	tiempo += Time.deltaTime;
    	//oxigeno = oxigeno - (tiempo/1000); //disminuye proporcionalmente al tiempo

    	//si se mueve el oxigeno se consume más rapido
    	if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
    		reducirOxigeno(Time.deltaTime*oxigenoPorSegundoAlMoverse);
    	} else {
    		reducirOxigeno(Time.deltaTime*oxigenoPorSegundo);
    	}

		if(sinOx) {
    		tiempoSinOx += Time.deltaTime; 
    		this.recibirDanio(tiempoSinOx/1000); //disminuye proporcionalmente al tiempo
    	} else {
    		sinOx = false; // para cuando este el sistema de recargar oxigeno
    		tiempoSinOx = 0.0f;
    	}
    }
}
