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
    public float oxigenoPorSegundo=0.01f;
	public float oxigenoPorMovimiento=0.1f;


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
        if(oxigeno==0)
    	    oxigeno = 100;
    }

    void Update()
    {
    	tiempo += Time.deltaTime;
    	//oxigeno = oxigeno - (tiempo/1000); //disminuye proporcionalmente al tiempo

    	//si se mueve el oxigeno se consume más rapido
    	if (Input.GetAxisRaw("Horizontal")!=0f || Input.GetAxisRaw("Vertical")!=0f) {
    		//reducirOxigeno(Time.deltaTime*oxigenoPorSegundoAlMoverse);
    		reducirOxigeno(Time.deltaTime*oxigenoPorMovimiento);
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
