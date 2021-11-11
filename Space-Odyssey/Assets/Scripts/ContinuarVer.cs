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
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Main menu"));
        PlayerPrefs.SetInt("continuar", 1);
    }

}
