using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravedaddeobjetos : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Planeta;
    void OnCollisionEnter(Collision col)
    {
    	if (col.gameObject==Planeta)
    	{
    		rb = GetComponent<Rigidbody>();
    		rb.mass=10000;
    	}
    }

	void Start()
	{
		
	}
}
