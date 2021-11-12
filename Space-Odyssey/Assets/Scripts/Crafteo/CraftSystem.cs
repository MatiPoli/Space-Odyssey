using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public Sprite background;
    public GameObject inventario;
    public GameObject CraftZone;
    public bool inventoryEnabled;
    public bool CraftZoneEnabled;
    public Items[] itemsCraft;
    public Transform CraftPos;
    // public Sprite icon;

    private GameObject aux;
    private GameObject slot;
    private int i;
    private int c;
    public bool prendido()
    {
        return CraftZoneEnabled;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c"))
        {
            Debug.Log(GetComponent<Inventario>().prendido());
            if(!GetComponent<Inventario>().inventotyEnabled)
            {
                CraftZoneEnabled =! CraftZoneEnabled;
                if (CraftZoneEnabled)
                {
                    CraftZone.SetActive(true);
                    GetComponent<Inventario>().craftEnabled = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    CraftZone.SetActive(false);
                    GetComponent<Inventario>().craftEnabled = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
        if(CraftZoneEnabled)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

public void Craft (int a){

    for(int i=0; i < itemsCraft.Length; i++)
    {
        if(itemsCraft[i].ID == a && Materials.shd.Water >= itemsCraft[i].RequiredWater && Materials.shd.Plant >= itemsCraft[i].RequiredPlant && Materials.shd.Iron >= itemsCraft[i].RequiredIron && Materials.shd.Copper >= itemsCraft[i].RequiredCopper && Materials.shd.Titanium >= itemsCraft[i].RequiredTitanium && Materials.shd.Plata >= itemsCraft[i].RequiredPlata && Materials.shd.Petroleum >= itemsCraft[i].RequiredPetroleum && Materials.shd.Food >= itemsCraft[i].RequiredFood && Materials.shd.Gasolina >= itemsCraft[i].RequiredGasolina){
        {
            Instantiate(itemsCraft[i].prefab, CraftPos.position, CraftPos.rotation, null);
            for (c=0;c<18;c++)
            {
                slot = inventario.transform.GetChild(c).gameObject;
                    /*if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredWater || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredPlant || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredIron || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredCopper || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredTitanium || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredPlata || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredPetroleum || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredFood || slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredGasolina)
                    {
                        Instantiate(itemsCraft[i].prefab, CraftPos.position, CraftPos.rotation, null);
                        itemsCraft[i].ID == slot.GetComponent<Slot>().cantidad -= 
                    }
                    */
                    Debug.Log("he entrado");
                    Debug.Log(slot.GetComponent<Slot>().ID);
                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredWater && slot.GetComponent<Slot>().ID == 1)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredWater;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Water = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredPlant && slot.GetComponent<Slot>().ID == 2)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredPlant;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Plant = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredIron && slot.GetComponent<Slot>().ID == 3)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredIron;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Iron = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredCopper && slot.GetComponent<Slot>().ID == 4)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredCopper;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Copper = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredTitanium && slot.GetComponent<Slot>().ID == 5)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredTitanium;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Titanium = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredPlata && slot.GetComponent<Slot>().ID == 6)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredPlata;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Plata = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredFood && slot.GetComponent<Slot>().ID == 8)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredFood;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Food = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredPetroleum && slot.GetComponent<Slot>().ID == 7)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredPetroleum;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Petroleum = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

                    if(slot.GetComponent<Slot>().cantidad >= itemsCraft[i].RequiredGasolina && slot.GetComponent<Slot>().ID == 9)
                    {
                        slot.GetComponent<Slot>().cantidad -= itemsCraft[i].RequiredGasolina;
                        if(slot.GetComponent<Slot>().cantidad==0)
                        {
                            GetComponent<Materials>().Gasolina = 0;
                            slot.GetComponent<Slot>().ID = 0;
                            slot.GetComponent<Slot>().item = null;
                            slot.GetComponent<Slot>().type = "";
                            slot.GetComponent<Slot>().descripcion = "";
                            slot.GetComponent<Slot>().icon = null;
                            slot.GetComponent<Slot>().empty = true;
                            aux = slot.transform.GetChild(0).gameObject;
                            aux.GetComponent<Image>().sprite = background;
                        }
                    }

            }
            break;
        }
    }
}}
    /*for(int i=0; i < itemsCraft.Length; i++){
        if(itemsCraft[i].ID == a && Materials.shd.Water >= itemsCraft[i].RequiredWater && Materials.shd.Plant >= itemsCraft[i].RequiredPlant && Materials.shd.Iron >= itemsCraft[i].RequiredIron && Materials.shd.Copper >= itemsCraft[i].RequiredCopper && Materials.shd.Titanium >= itemsCraft[i].RequiredTitanium && Materials.shd.Plata >= itemsCraft[i].RequiredPlata && Materials.shd.Petroleum >= itemsCraft[i].RequiredPetroleum && Materials.shd.Food >= itemsCraft[i].RequiredFood && Materials.shd.Gasolina >= itemsCraft[i].RequiredGasolina){
        Instantiate(itemsCraft[i].prefab, CraftPos.position, CraftPos.rotation, null);
            print(itemsCraft[i].name + " Crafteado");

            Materials.shd.Water -= itemsCraft[i].RequiredWater;
            Materials.shd.Plant -= itemsCraft[i].RequiredPlant;
            Materials.shd.Iron -= itemsCraft[i].RequiredIron;
            Materials.shd.Copper -= itemsCraft[i].RequiredCopper;
            Materials.shd.Titanium -= itemsCraft[i].RequiredTitanium;
            Materials.shd.Plata -= itemsCraft[i].RequiredPlata;
            Materials.shd.Petroleum -= itemsCraft[i].RequiredPetroleum;
            Materials.shd.Food -= itemsCraft[i].RequiredFood;
            Materials.shd.Gasolina -= itemsCraft[i].RequiredGasolina;
            Debug.Log("resta");
*/






[Serializable]
public class Items{
    public string name;
    public int ID;
    [TextArea(10,5)]
    public string description;

    public int RequiredWater;
    public int RequiredPlant;
    public int RequiredIron;
    public int RequiredCopper;
    public int RequiredTitanium;
    public int RequiredPlata;
    public int RequiredPetroleum;
    public int RequiredFood;
    public int RequiredGasolina;


    public GameObject prefab;

}

}
