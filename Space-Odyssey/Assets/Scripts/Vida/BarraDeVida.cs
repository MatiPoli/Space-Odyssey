using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DamageTarget))]
public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    private float vidaActual;
    float vidaMaxima;
    DamageTarget variables;

    void Start()
    {
        variables = GetComponent<DamageTarget>();
        vidaMaxima = variables.maxVida;
    }
    // Update is called once per frame
    void Update()
    {
    	vidaActual = variables.getVida(); 
        barraDeVida.fillAmount = vidaActual / vidaMaxima;

        if(barraDeVida.fillAmount == 0){
        	SceneManager.LoadScene (sceneName:"Game Over");
    	}
    }
}
