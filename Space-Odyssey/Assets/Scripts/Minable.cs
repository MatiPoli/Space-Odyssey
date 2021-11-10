using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Minable : MonoBehaviour
{
    private Renderer render;
    public Rigidbody rb;
    public Rigidbody Branch_01;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        render = gameObject.GetComponent<Renderer>();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);

        Destroy(this);

        Destroy(rb);
    }

    void Update()
    {
        float maxDistance = 10;

        if (render.isVisible)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("M");
                DestroyGameObject();
            }

        }

    }
}