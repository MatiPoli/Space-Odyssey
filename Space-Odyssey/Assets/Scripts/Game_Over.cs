using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Game_Over : MonoBehaviour
{
    public void SaliR()           //Fuction to exit
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void LoadScene(string sceneName)   //Function that loads a new scene
    {
        if (sceneName == "Espacio")
            Destroy(GameObject.FindGameObjectWithTag("Main menu"));
        SceneManager.LoadScene(sceneName);
    }
   

}

