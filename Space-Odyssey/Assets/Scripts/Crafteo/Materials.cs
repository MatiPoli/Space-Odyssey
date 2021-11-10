using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    public static Materials shd; void Awake (){if (shd==null) {shd = this;}}

    public int Rock;
    public int Wood;
    public int Steel;
    //BORRAR LO DE ARRIBA !!!!!

    public int Water;
    public int Plant;
    public int Iron;
    public int Petroleum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
