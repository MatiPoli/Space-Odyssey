using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarMenu : MonoBehaviour
{
    static float y=0;
    public float speed = 5f;

    void Start()
    {
        this.transform.rotation = new Quaternion(this.transform.rotation.x, y, this.transform.rotation.y,this.transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
        y = this.transform.rotation.y;
    }
}
