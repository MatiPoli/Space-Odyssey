using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Agua : MonoBehaviour
{

	private GameObject jugador;
    public float tiempo = 0.0f;
    public float limiteTiempo = 10.0f;
    public Image barra;
    private Color32 colorOriginal = new Color32(75,181,236,255);

    //private Image barra = GetComponent<BarraDeVida>().barraDeVida;
	
	private void OnCollisionStay(Collision collision) //la entrada es un collision, objecto que entra en colision
    {
        //Color32 colorOriginal = new Color32(75,181,236,255); // color original 75 181 236
        int tiempoEntero;

    	jugador = GameObject.FindWithTag("Player");
    	GameObject objeto = collision.gameObject;
        //barra = GetComponent<BarraDeVida>().barraDeVida;

        //tiempo += Time.deltaTime;
          //  Debug.Log(tiempo);


            
    	if(objeto == jugador) {

            tiempo += Time.deltaTime;


            Debug.Log(tiempo);
            if(tiempo >= limiteTiempo){

                //oxigenoActual = GetComponent<Variables>().oxigeno
                jugador.GetComponent<Variables>().reducirOxigeno();
                //Destroy(jugador);
                tiempoEntero = (int)tiempo;
                if(tiempoEntero % 2 == 0) {
                    barra.GetComponent<Image>().color = new Color32(255,255,225,100);
                } else {
                    barra.GetComponent<Image>().color = colorOriginal;
                }

            }
            //GetComponent<Variables>().vida;
    		//Destroy(jugador);
    	}/*
        if(objeto == jugador){
            SceneManager.LoadScene (sceneName:"Game Over");
        }*/
    	
    }

    //renuevo el tiempo que estuvo abajo cuando sale del agua
    private void OnCollisionExit(Collision collision){
        tiempo = 0.0f;
        barra.GetComponent<Image>().color = colorOriginal;
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
