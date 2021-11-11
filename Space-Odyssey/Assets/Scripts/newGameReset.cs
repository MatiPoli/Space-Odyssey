using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newGameReset : MonoBehaviour
{
    private string inicio = "inic";
    private string inicio2 = "inic2";
   
    public void SaveData()
    {
        PlayerPrefs.SetInt(inicio, 1);
        PlayerPrefs.SetInt(inicio2, 1);
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
