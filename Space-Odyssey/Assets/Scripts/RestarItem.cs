using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestarItem : MonoBehaviour
{
    public Slot localslot;

    public Sprite background;
    private GameObject aux;
    // Start is called before the first frame update
    public void Restar(Slot localslot)
    {
        localslot.cantidad = localslot.cantidad - 1;
        if(localslot.cantidad==0)
        {

            localslot.ID = 0;
            localslot.item = null;
            localslot.type = "";
            localslot.descripcion = "";
            localslot.icon = null;
            localslot.empty = true;
            aux = localslot.transform.GetChild(0).gameObject;
            aux.GetComponent<Image>().sprite = background;
        }
        // Debug.Log(GetComponent<Slot>().cantidad);
    }


}

