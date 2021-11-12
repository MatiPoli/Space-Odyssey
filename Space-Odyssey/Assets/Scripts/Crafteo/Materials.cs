using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class Materials : MonoBehaviour
{
    public static Materials shd; void Awake (){if (shd==null) {shd = this;}}

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
    public int Comida; // Crafteo de comida a base de Planta                                   |
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

    }
}
