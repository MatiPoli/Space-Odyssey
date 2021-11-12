using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class Materials : MonoBehaviour
{
    public static Materials shd; void Awake (){if (shd==null) {shd = this;}}
    public GameObject SlotHolder;
    private GameObject slot;
    private int i;

    public bool PowerUp_de_nave;

    public int Rock;
    public int Wood;
    public int Steel;
    //BORRAR LO DE ARRIBA !!!!!
//---------------------------------------------------------------------------------------------+
    public int Water;   //Obejeto Base                                                         |
    public int Plant;   //Obejeto Base                                                         |
    public int Iron;    //Obejeto Base Objeto minable                                          |
    public int Copper;  //Obejeto Base Objeto minable                                          |
    public int Titanium;//Obejeto Base Objeto minable                                          |
    public int Plata;   //Obejeto Base Objeto minable                                          |
    public int Petroleum; //Objeto Rojo, Objeto minable                                        |
                      //                                                                       |
//---------------------------------------------------------------------------------------------+
//                                                                                             |
    public int Food; // Crafteo de comida a base de Planta                                   |
    public int PaqueteDeAguaFiltrada; //Crafteo de Agua Potable de comida a base de Agua       |
    public int Gasolina; // Crafteo a base de Petroleo (Blanco y gordo)                        |
    public int Municion; // Crafteo a base de Hierro                                           |
//---------------------------------------------------------------------------------------------+
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(i=0;i<18;i++)
        {
            slot = SlotHolder.transform.GetChild(i).gameObject;
            if(slot.GetComponent<Slot>().ID == 1)
            {
                Water = slot.GetComponent<Slot>().cantidad; 
            }
            if(slot.GetComponent<Slot>().ID == 2)
            {
                Plant = slot.GetComponent<Slot>().cantidad; 
            }
            if(slot.GetComponent<Slot>().ID == 3)
            {
                Iron = slot.GetComponent<Slot>().cantidad; 
            }
            if(slot.GetComponent<Slot>().ID == 4)
            {
                Copper = slot.GetComponent<Slot>().cantidad; 
            }
            if(slot.GetComponent<Slot>().ID == 5)
            {
                Titanium = slot.GetComponent<Slot>().cantidad;
            if(slot.GetComponent<Slot>().ID == 15)
            {
                Debug.Log("holaaa");
                Plata = slot.GetComponent<Slot>().cantidad; 
            }
            if(slot.GetComponent<Slot>().ID == 7)
            {
                Petroleum = slot.GetComponent<Slot>().cantidad; 
            }
            if(slot.GetComponent<Slot>().ID == 8)
            {
                Gasolina = slot.GetComponent<Slot>().cantidad; 
            }
            
        }        
    }

}
}
