using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public GameObject CraftZone;

    private bool CraftZoneEnabled;
    public Items[] itemsCraft;
    public Transform CraftPos;
    // public Sprite icon;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")){
            CraftZoneEnabled =! CraftZoneEnabled; 
        }

        if (CraftZoneEnabled){
            CraftZone.SetActive(true);
        }
        else{
            CraftZone.SetActive(false);
        }
    }

public void Craft (int a){
    for(int i=0; i < itemsCraft.Length; i++){
        if(itemsCraft[i].ID == a && Materials.shd.Wood >= itemsCraft[i].RequiredWood && Materials.shd.Steel >= itemsCraft[i].RequiredSteel && Materials.shd.Rock >= itemsCraft[i].RequiredRock /* BORRAR LO ANTERIOR PLS */ && Materials.shd.Water >= itemsCraft[i].RequiredWater && Materials.shd.Plant >= itemsCraft[i].RequiredPlant && Materials.shd.Iron >= itemsCraft[i].RequiredIron && Materials.shd.Petroleum >= itemsCraft[i].RequiredPetroleum){
        Instantiate(itemsCraft[i].prefab, CraftPos.position, CraftPos.rotation, null);
            print(itemsCraft[i].name + " Crafteado");

            Materials.shd.Wood -= itemsCraft[i].RequiredWood;
            Materials.shd.Steel -= itemsCraft[i].RequiredSteel;
            Materials.shd.Rock -= itemsCraft[i].RequiredRock;

            //BORRAR LO DE ARRIBAA

            Materials.shd.Water -= itemsCraft[i].RequiredWater;
            Materials.shd.Plant -= itemsCraft[i].RequiredPlant;
            Materials.shd.Petroleum -= itemsCraft[i].RequiredPetroleum;
            Materials.shd.Iron -= itemsCraft[i].RequiredIron;

        }
    }
}




[Serializable]
public class Items{
    public string name;
    public int ID;
    [TextArea(10,5)]
    public string description;

    public int RequiredWood;
    public int RequiredSteel;
    public int RequiredRock;

    public int RequiredWater;
    public int RequiredPlant;
    public int RequiredPetroleum;
    public int RequiredIron;

    public GameObject prefab;

}

}
