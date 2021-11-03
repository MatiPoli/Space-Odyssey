using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Variables : MonoBehaviour
{
    public float vida;
    public float oxigeno;
    private float tiempo;

    void Start()
    {
    	vida = 100;
    	oxigeno = 100;
    }

    void Update()
    {
    	tiempo += Time.deltaTime;
    	oxigeno = oxigeno - (tiempo/1000); //disminuye proporcionalmente al tiempo
    }
}
