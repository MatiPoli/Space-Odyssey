using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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

    public Transform slotIconGameObject;

    public TextMeshProUGUI uiText;

    private void Start()
    {
        slotIconGameObject = transform.GetChild(0);
    }

    public void UpdateSlot(){
        slotIconGameObject.GetComponent<Image>().sprite = icon;
        if (cantidad > 0) {
            uiText.SetText(cantidad.ToString());
        } else {
            uiText.SetText("");
        }
    }


    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();

    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();

    }



}
