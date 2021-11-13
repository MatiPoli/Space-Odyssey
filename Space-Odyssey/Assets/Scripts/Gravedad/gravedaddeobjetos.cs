using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class gravedaddeobjetos : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Planeta;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }
    
    void OnCollisionEnter(Collision col)
    {
    	if (col.gameObject==Planeta)
    	{
    		rb.constraints = RigidbodyConstraints.FreezeAll;
    		rb.mass=1000;
    	}
    }
}
