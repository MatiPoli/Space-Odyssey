using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Minable : MonoBehaviour
{
    public GameObject myPrefab;
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
        GameObject instantiatedObject = Instantiate(myPrefab, this.transform.position, this.transform.rotation, null);
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        float maxDistance = 10;
        DestroyGameObject();
    }
}