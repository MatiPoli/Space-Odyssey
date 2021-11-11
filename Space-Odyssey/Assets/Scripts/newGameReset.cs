using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newGameReset : MonoBehaviour
{
   
    public void SaveData()
    {
        PlayerPrefs.SetInt("inic", 1);
        PlayerPrefs.SetInt("inic2", 1);
        PlayerPrefs.SetInt("inic3", 1);
        PlayerPrefs.SetInt("inic4", 1);
        PlayerPrefs.SetInt("Muerto", 0);
    }

    public void Continuar()
    {
        PlayerPrefs.SetInt("continuar", 1);
    }

    public void SeMurió()
    {
        PlayerPrefs.SetInt("Muerto", 1);
        Debug.Log(PlayerPrefs.GetInt("Muerto", 1));
    }

}
