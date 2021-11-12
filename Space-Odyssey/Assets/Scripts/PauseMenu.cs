using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject hud;
    public static bool GameIsPaused = false;


    public GameObject player;
    public GameObject PauseMenuUI;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!player.GetComponent<Inventario>().prendido()&&!player.GetComponent<CraftSystem>().prendido())
            {
                if(GameIsPaused)
                {
                Resume();
                }else
                {
                Pause();
                }
            }
            
        }
    }
    public void SaliiR()           //Fuction to exit
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Exit");
    }
    public void Resume()
    {
        hud.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Pause()
    {
        hud.SetActive(false);
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("asdad");
        Time.timeScale = 0f;
        
    }

    public void Loadscene()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

   
}
