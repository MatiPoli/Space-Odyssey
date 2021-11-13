using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistEntreObj : MonoBehaviour
{
    [Header("Objeto")]
    public GameObject object1;

    public float calcularDistancia(){
    	return (object1.transform.position-this.transform.position).magnitude;
    }
}
