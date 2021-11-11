using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuarVer : MonoBehaviour
{
    public void Continuar()
    {
        if(PlayerPrefs.GetInt("scene", 1) == 1)
        {
            SceneManager.LoadScene("Scenes/Espacio");

        }
        if(PlayerPrefs.GetInt("scene", 1) == 2)
        {
            SceneManager.LoadScene("Scenes/Planetas/Havay");
        }
        if(PlayerPrefs.GetInt("scene", 1) == 3)
        {
            SceneManager.LoadScene("Scenes/Planetas/Earth");
        }
        if(PlayerPrefs.GetInt("scene", 1) == 4)
        {
            SceneManager.LoadScene("Scenes/Planetas/Alolea");
        }
        if(PlayerPrefs.GetInt("scene", 1) == 5)
        {
            SceneManager.LoadScene("Scenes/Planetas/Egipt");
        }
        if(PlayerPrefs.GetInt("scene", 1) == 6)
        {
            SceneManager.LoadScene("Scenes/Planetas/Ice");
        }
        if(PlayerPrefs.GetInt("scene", 1) == 7)
        {
            SceneManager.LoadScene("Scenes/Planetas/Orange");
        }
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Main menu"));
        PlayerPrefs.SetInt("continuar", 1);
    }

}
