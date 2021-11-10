using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravedad : MonoBehaviour
{
    public Atractor atractor;
    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }
    void FixedUpdate()
    {
        atractor.atraer(this.gameObject);
    }

}
