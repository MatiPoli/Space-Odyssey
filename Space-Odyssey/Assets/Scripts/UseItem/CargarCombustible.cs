using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarCombustible : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Mecha"))
        {
            PlayerPrefs.SetFloat("gaso", 1f);
            Debug.Log("Que hace maestro, cargame 100 de super");
        }
    }

}
