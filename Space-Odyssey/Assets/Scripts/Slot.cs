using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string descripcion;

    public bool empty;
    public Sprite icon;

    public Transform slotIcongameObject;


    /*private void Start()
    {
        slotIcongameObject = transform.G
    }

    */

    public void UpdateSlot()
    {

        this.GetComponent<Image>().sprite = icon;

    }
}
