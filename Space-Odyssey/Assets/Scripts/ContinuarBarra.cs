using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinuarBarra : MonoBehaviour
{
    public void Start()
    {
        if(PlayerPrefs.GetInt("Muerto", 1) == 1)
        {
            this.GetComponent<Image>().color = new Color32(115,115,115,148);
            this.GetComponent<Button>().enabled = false;
        }
        else
        {
            this.GetComponent<Image>().color = new Color32(255,255,255,255);
            this.GetComponent<Button>().enabled = true;
        }
    }
}
