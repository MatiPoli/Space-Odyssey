using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{

	[SerializeField] private Vector3 _rotation;
	[SerializeField] private float _speed = 50.0f;
	//public float xAngle, yAngle, zAngle;

/*	
    void Awake()
    {
        //cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
        this.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        //cube1.GetComponent<Renderer>().material.color = Color.red;
        //cube1.name = "Self";
    }

    void Update()
    {
        this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    }

*/    // Start is called before the first frame update
    void Update()
    {	
        _rotation = Vector3.up;

        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }

}
