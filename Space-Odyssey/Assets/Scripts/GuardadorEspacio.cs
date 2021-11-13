using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadorEspacio : MonoBehaviour
{ 
    public GameObject Nave;
    private float angle;

    // Update is called once per frame
    public void VuelvoAlMenu()
    {
        PlayerPrefs.SetInt("scene", 1);
        PlayerPrefs.SetFloat("navex", Nave.transform.position.x);
        PlayerPrefs.SetFloat("navez", Nave.transform.position.z);
        PlayerPrefs.SetFloat("navey", Nave.transform.position.y);
        PlayerPrefs.SetFloat("naver", Nave.transform.localEulerAngles.y);
    }
}
