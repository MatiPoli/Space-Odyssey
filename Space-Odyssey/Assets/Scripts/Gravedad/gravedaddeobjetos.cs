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
    		rb.constraints = RigidbodyConstraints.FreezeAll;
    		rb.mass=1000;
    	}
    }

	void Start()
	{
		
	}
}
