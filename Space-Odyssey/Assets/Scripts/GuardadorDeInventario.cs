using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuardadorDeInventario : MonoBehaviour
{
    private GameObject slot;
    public GameObject lista;
    private GameObject aux;
    private GameObject aux2;
    private int i;
    private int c;
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
        for(i=0;i<18;i++)
        {
            PlayerPrefs.SetInt("sloti"+ i, 0);
            PlayerPrefs.SetInt("slotc"+ i, 0);
        }
    }

    private void CargarInventario()
    {
        Debug.Log("Cargado");
        for(i=0;i<18;i++)
        {
            slot = transform.GetChild(i).gameObject;
            slot.GetComponent<Slot>().ID = PlayerPrefs.GetInt("sloti"+ i, 0);

            slot.GetComponent<Slot>().cantidad = PlayerPrefs.GetInt("slotc"+ i, 0);
            for(c=0;c<10;c++)
            {
                aux = lista.transform.GetChild(c).gameObject;
                if(aux.GetComponent<Item>().ID == PlayerPrefs.GetInt("sloti"+ i, 0))
                {
                    slot.GetComponent<Slot>().empty = false;
                    slot.GetComponent<Slot>().item = aux;
                    slot.GetComponent<Slot>().type = aux.GetComponent<Item>().type;
                    slot.GetComponent<Slot>().descripcion = aux.GetComponent<Item>().descripcion;
                    slot.GetComponent<Slot>().icon = aux.GetComponent<Item>().icon;
                    aux2 = slot.transform.GetChild(0).gameObject;
                    aux2.GetComponent<Image>().sprite = slot.GetComponent<Slot>().icon;
                }
            }
        }
    }
    // Update is called once per frame
    void OnDestroy()
    {
        for(i=0;i<18;i++)
        {
            slot = transform.GetChild(i).gameObject;
            PlayerPrefs.SetInt("sloti"+ i, slot.GetComponent<Slot>().ID);
            PlayerPrefs.SetInt("slotc"+ i, slot.GetComponent<Slot>().cantidad);
        }
    }
}
