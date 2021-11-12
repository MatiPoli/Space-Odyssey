using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Inventario : MonoBehaviour
{

    public bool craftEnabled;
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;
    private GameObject aux;
    public bool inventotyEnabled;


    public bool prendido()
    {
        return inventotyEnabled;
    }
    void Start()
    {
        allSlots = slotHolder.transform.childCount;

        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++){
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if(slot[i].GetComponent<Slot>().item == null){
                slot[i].GetComponent<Slot>().empty = true;
            }
        }

    }


    void Update()
    {
        if(Input.GetKeyDown("i"))
        {   
            inventotyEnabled =! inventotyEnabled;
            if(inventotyEnabled)
            {
                inventory.SetActive(true);
                Debug.Log(craftEnabled);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                inventory.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        } 

    }

    /* private void OnTriggerEnter(Collider other){
        if(other.tag=="Item"){
            GameObject itemPickUp = other.gameObject;

            Item item = itemPickUp.GetComponent<Item>();

            AddItem(itemPickUp, item.ID, item.type, item.descripcion, item.icon);

        }

    } */

    //Nueva funcion para que no haga falta usar el isTrigger y poder usar el script Objetos
     private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp,item.ID,item.type,item.descripcion,item.icon);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string iteamDescription, Sprite itemIcon){
        
        for(int i = 0; i < allSlots; i++){
            if(slot[i].GetComponent<Slot>().ID == itemID){
                slot[i].GetComponent<Slot>().cantidad += 1;
                string c = slot[i].GetComponent<Slot>().cantidad + "";
              //  slot[i].transform.GetChild(2).GetComponent<Texto>().Text = c;
                //aux = slot[i].transform.GetChild(2).gameObject;
                //aux.GetComponent<Text>().text = c;
                Debug.Log("Se ha cambiado la cantidad a mostrar");
                itemObject.SetActive(false);
                break;
            }
            if (slot[i].GetComponent<Slot>().empty){
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().descripcion = iteamDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot [i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().cantidad = 1;
                slot[i].GetComponent<Slot>().empty = false;
                break;
            }

            
           // public void RestarItemUsadio(GameObject itemObject, int itemID, string itemType, string iteamDescription, Sprite itemIcon)
            
        }
        


    }

}
