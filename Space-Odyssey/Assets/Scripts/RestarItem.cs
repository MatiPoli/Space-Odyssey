using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestarItem : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restar()
    {
        GetComponent<Slot>().cantidad = GetComponent<Slot>().cantidad - 1;
        Debug.Log(GetComponent<Slot>().cantidad);
    }
}

