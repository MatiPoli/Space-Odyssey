using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atractor : MonoBehaviour
{
    public float G = 100;

    // Start is called before the first frame update
    public void atraer(GameObject body)
    {
        Vector3 gravity = (transform.position- body.transform.position).normalized;

        body.GetComponent<Rigidbody>().AddForce(gravity * G);

        rotate(body);
    }

    public void rotate(GameObject body)
    {
        Vector3 gravity = (transform.position - body.transform.position).normalized;

        Quaternion orientason = Quaternion.FromToRotation(-body.transform.up, gravity) * body.transform.rotation;

        body.transform.rotation = orientason;
    }
}
