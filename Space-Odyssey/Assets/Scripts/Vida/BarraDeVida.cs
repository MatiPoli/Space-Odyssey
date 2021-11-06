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

    private string inicio2 = "inic2" ;
    private int iniciamosV = 0;
    private string vidaPrefsName = "vida";

    protected void Start()
    {
        vidaMaxima = GetComponent<Variables>().getMaxVida();
        iniciamosV = PlayerPrefs.GetInt(inicio2, 0);
        if (iniciamosV == 1)
        {
            PlayerPrefs.SetFloat(vidaPrefsName, GetComponent<Variables>().getMaxVida());
            PlayerPrefs.SetFloat(inicio2, 0);
        }
        LoadData();
    }


    // Update is called once per frame
    void Update()
    {
    	vidaActual = GetComponent<Variables>().getVida(); 
        barraDeVida.fillAmount = vidaActual / vidaMaxima;

        if(barraDeVida.GetComponent<Image>().fillAmount == 0){
        	SceneManager.LoadScene (sceneName:"Game Over");
    	}
    }

    private void SaveData()
    {
        PlayerPrefs.SetFloat(vidaPrefsName, GetComponent<Variables>().getVida());
    }
    private void LoadData()
    {
        GetComponent<Variables>().actualizarVida(PlayerPrefs.GetFloat(vidaPrefsName, 100));
    }

    private void OnDestroy()
    {
        SaveData();
    }
}
