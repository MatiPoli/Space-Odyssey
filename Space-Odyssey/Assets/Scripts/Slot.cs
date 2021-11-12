using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public int cantidad;
    public string type;
    public string descripcion;
    public Text texto;
    public bool empty;
    public Sprite icon;

    public GameObject slotIconGameObject;

    private void Start()
    {

    }

    public void UpdateSlot(){
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }


    public void UseItem()
    {
        if(item != null)
        {item.GetComponent<Item>().ItemUsage();}
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();

    }

   // public void RestarItemUsado()



}
