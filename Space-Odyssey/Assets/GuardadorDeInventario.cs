using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadorDeInventario : MonoBehaviour
{
    private GameObject slot;
    private int i;

    void Start()
    {
        if(PlayerPrefs.GetInt("inic3", 0)==1)
        {
            Debug.Log("borrado");
            BorrarInventario();
            PlayerPrefs.SetFloat("inic3", 0);
        }
        else
        {
            CargarInventario();
        }
    }
    private void BorrarInventario()
    {
        for(i=0;i<9;i++)
        {
            PlayerPrefs.SetInt("sloti"+ i, 0);
            PlayerPrefs.SetInt("slotc"+ i, 0);
        }
    }

    private void CargarInventario()
    {
        Debug.Log("Cargado");
        for(i=0;i<9;i++)
        {
            slot = transform.GetChild(i).gameObject;
            slot.GetComponent<Slot>().ID = PlayerPrefs.GetInt("sloti"+ i, 0);
            slot.GetComponent<Slot>().cantidad = PlayerPrefs.GetInt("slotc"+ i, 0);
        }
    }
    // Update is called once per frame
    void OnDestroy()
    {
        for(i=0;i<9;i++)
        {
            slot = transform.GetChild(i).gameObject;
            PlayerPrefs.SetInt("sloti"+ i, slot.GetComponent<Slot>().ID);
            PlayerPrefs.SetInt("slotc"+ i, slot.GetComponent<Slot>().cantidad);
        }
    }
}
