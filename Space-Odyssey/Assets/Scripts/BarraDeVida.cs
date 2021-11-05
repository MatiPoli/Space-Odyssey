using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    private float vidaActual;
    public float vidaMaxima;

    // Update is called once per frame
    void Update()
    {
    	vidaActual = GetComponent<Variables>().getVida(); 
        barraDeVida.fillAmount = vidaActual / vidaMaxima;

        if(barraDeVida.GetComponent<Image>().fillAmount == 0){
        	SceneManager.LoadScene (sceneName:"Game Over");
    	}
    }
}
