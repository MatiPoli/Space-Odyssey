using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDeNave : MonoBehaviour
{
    public Materials materialesdePlayer;
    //public Bool ParaGanar; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Se ha abierto un portal a una nueva dimension ");
        if (other.gameObject.CompareTag("FinalBoost"))
        {
            materialesdePlayer.PowerUp_de_nave = true; 
            PlayerPrefs.SetInt("powerup", 1);
            Debug.Log("Se ha abierto un portal a una nueva dimension ");
        }
    }

}
