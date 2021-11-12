using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Minable : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject Personaje;
    public Canvas fondo;
    private GameObject aux;
    private float distancia;
    private Renderer render;
    public Rigidbody rb;
    public Rigidbody Branch_01;
    private int cont; 

    // Start is called before the first frame update
    void Start()
    {
        fondo.GetComponent<Canvas>().enabled = false;

        rb = this.GetComponent<Rigidbody>();
        render = gameObject.GetComponent<Renderer>();

        cont = 0;
    }

    void DestroyGameObject()
    {
        distancia = GetComponent<DistEntreObj>().calcularDistancia();
        Debug.Log(distancia);
        if(distancia<=50f)
        {   
            GameObject instantiatedObject = Instantiate(myPrefab, this.transform.position, this.transform.rotation, null);
            instantiatedObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        float maxDistance = 10;

        if(cont == 3){

            DestroyGameObject();

        }

        cont ++;
    }

    void OnMouseEnter()
    {
        distancia = GetComponent<DistEntreObj>().calcularDistancia();

        if(distancia<=50.0f) {
            fondo.GetComponent<Canvas>().enabled = true;
        }
    }

    void OnMouseOver()
    {
        distancia = GetComponent<DistEntreObj>().calcularDistancia();

        if(distancia > 50.0f) {
            fondo.GetComponent<Canvas>().enabled = false;
        } else {
            fondo.GetComponent<Canvas>().enabled = true;
        }
    }

    void OnMouseExit()
    {
        fondo.GetComponent<Canvas>().enabled = false;
    }

    void OnDestroy(){
        aux = GameObject.Find("FondoMinado");
        aux.GetComponent<Canvas>().enabled = false;
    }
}