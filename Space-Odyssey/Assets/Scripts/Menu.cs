using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour
{
    public void SaliR()           //Fuction to exit
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void LoadScene(string sceneName)   //Function that loads a new scene
    {
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Main menu"));
        SceneManager.LoadScene(sceneName);
    }

}

