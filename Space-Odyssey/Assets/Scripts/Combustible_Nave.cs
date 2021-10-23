using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combustible_Nave : MonoBehaviour
{
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update(){
        
    if (Input.GetKey("w")){
        GetComponent<Image>().fillAmount -= 0.00001f; 

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
}
