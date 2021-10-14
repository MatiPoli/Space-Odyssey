﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atractor : MonoBehaviour
{
    public float G = 100000;

    // Start is called before the first frame update
    public void atraer(GameObject body)
    {
        Vector3 gravity = -(body.transform.position - transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(gravity * G);

        Quaternion orientason = Quaternion.FromToRotation(-body.transform.up, gravity) * body.transform.rotation;

        body.transform.rotation = Quaternion.Slerp(body.transform.rotation, orientason, 50 * Time.deltaTime);
    }
}