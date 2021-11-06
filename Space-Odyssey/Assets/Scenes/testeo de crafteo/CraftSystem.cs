using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CraftSystem : MonoBehaviour
{

    public Items[] itemsCraft;
    public Transform CraftPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void Craft (int a){
    for(int i=0; i < itemsCraft.Length; i++){
        if(itemsCraft[i].ID == a){
        Instantiate(itemsCraft[i].prefab, CraftPos.position, CraftPos.rotation, null);
            print(itemsCraft[i].name + " Crafteado");

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

    public GameObject prefab;

}

}
