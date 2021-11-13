using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorPlanetas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("continuar", 1) == 1)
        {
            //cargador de inventario
        }
    }

}
