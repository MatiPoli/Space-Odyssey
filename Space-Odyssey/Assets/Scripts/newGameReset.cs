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
    }


}
