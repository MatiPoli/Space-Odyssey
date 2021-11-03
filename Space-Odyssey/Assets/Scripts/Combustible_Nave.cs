using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combustible_Nave : MonoBehaviour
{
    public string gasolinaPrefsName = "gaso";


    private void Awake()
    {
        LoadData();
        if (GetComponent<Image>().fillAmount == 0)
            GetComponent<Image>().fillAmount = 1;
    }

    public void resetAll()
    {
        GetComponent<Image>().fillAmount = 1;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update(){

    if (Input.GetKey("w")){
        GetComponent<Image>().fillAmount -= 0.01f; 

    }

    if( GetComponent<Image>().fillAmount < 0.5f){
        GetComponent<Image>().color = new Color32(156,95,0,255);
    }

    if( GetComponent<Image>().fillAmount < 0.25f){
        GetComponent<Image>().color = new Color32(156,28,0,255);
    }

    if( GetComponent<Image>().fillAmount == 0){
        SceneManager.LoadScene (sceneName:"Game Over");
    }



    }

    private void SaveData()
    {
    PlayerPrefs.SetFloat(gasolinaPrefsName, GetComponent<Image>().fillAmount);
    }
    private void LoadData()
    {
    GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat(gasolinaPrefsName, 1);

    }

    private void OnDestroy()
    {
        SaveData();
    }


}
