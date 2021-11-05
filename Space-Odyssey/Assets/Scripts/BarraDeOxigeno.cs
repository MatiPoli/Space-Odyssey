using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeOxigeno : MonoBehaviour
{
    public Image barraDeOxigeno;
    private float oxigenoActual;
    public float oxigenoMaximo;
    private float tiempo;
    public bool sinOxigeno = false;

    // Update is called once per frame
    void Update()
    {
        //barraDeOxigeno.GetComponent<Image>().fillAmount -= 0.00001f; 
    	oxigenoActual = GetComponent<Variables>().oxigeno;    	
        barraDeOxigeno.fillAmount = oxigenoActual / oxigenoMaximo;

        
        if(barraDeOxigeno.GetComponent<Image>().fillAmount <= 0){
        	//SceneManager.LoadScene (sceneName:"Game Over");
        	sinOxigeno = true;
    	}
    	/*
    	if(oxigenoActual == 0) {
    		sinOxigeno = true; 
    	}
    	*/

    }
}
