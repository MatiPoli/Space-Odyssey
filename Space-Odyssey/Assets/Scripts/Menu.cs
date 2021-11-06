using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour
{
    public Toggle toggle;
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

    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

        isMuted = PlayerPrefs.GetFloat("MUTED") == 1;    
        AudioListener.pause = isMuted;

        /*
        if(Screen.fullScreen)         
        {
            toggle.isOn = true;
            
        }
        else
        {
            toggle.isOn = false;
            
        }*/
    }
   public void ActivateFullScreen(bool fullscreen)       //FullScreen
    {
        Screen.fullScreen = fullscreen;
        Debug.Log("FullScreen");
    }
    public void ChangeVolume()            //Volume Slider
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        //volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    private bool isMuted;

    public void MutePressed()           //Mute Fuction
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
        Debug.Log("Mute");
    }

}

