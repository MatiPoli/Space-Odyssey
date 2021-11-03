using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newGameReset : MonoBehaviour
{
    private string inicio = "inic";
   

    public void SaveData()
    {
        PlayerPrefs.SetInt(inicio, 1);
    }


}
