using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public GameObject CraftZone;
    public bool inventoryEnabled;
    public bool CraftZoneEnabled;
    public Items[] itemsCraft;
    public Transform CraftPos;
    // public Sprite icon;

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
    for(int i=0; i < itemsCraft.Length; i++){
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
}
}
}




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
