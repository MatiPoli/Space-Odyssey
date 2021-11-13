using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuuardadorEspacio2 : MonoBehaviour
{
    public GameObject Nave;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("continuar", 1) == 1)
        {
            PlayerPrefs.SetInt("continuar", 0);
            Nave.transform.position = new Vector3(PlayerPrefs.GetFloat("navex",0),PlayerPrefs.GetFloat("navey",0),PlayerPrefs.GetFloat("navez",0));
            Debug.Log(PlayerPrefs.GetFloat("naver",0));
            //Nave.transform.Rotate(new Vector3(0, (PlayerPrefs.GetFloat("naver",0)) , 0));
            Nave.transform.rotation = Quaternion.Euler(new Vector3(0, (PlayerPrefs.GetFloat("naver",0)) , 0));


        }
    }

}
