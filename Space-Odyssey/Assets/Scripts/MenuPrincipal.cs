using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    private void Start()
    {
    }
    public void empezar()
    {
        SceneManager.LoadScene(1);
    }
    public void salir()
    {
        Debug.Log("SALISTE DEL JUEGO");
        Application.Quit();
    }
}
