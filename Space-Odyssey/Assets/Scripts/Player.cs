using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject planet;
    const float G = 6000f;
    public float speed = 5f;
    public float sensibility = 10f;
    Vector3 rotationinput = Vector3.zero;
    private float cameraVerticalAngle;
    public Camera playerCamera;
    public Light flashLight;
    Rigidbody rb;
    Transform tr;
    bool grounded = false;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        flashLight.enabled = false;
    }

    private void Update() {
        Planet planet = FindObjectOfType<Planet>();
        Move(planet);
        Look();
        TriggerFlashLight();
        Attract(planet);
    }

    void Attract(Planet planet) {
        Vector3 dir = rb.position - planet.rb.position;
        float dist = dir.magnitude;

        float forceMagnitude = G * (rb.mass * planet.rb.mass) / Mathf.Pow(dist, 2);
        Vector3 force = forceMagnitude * dir.normalized * Time.deltaTime * 100000f;

        rb.AddForce(-force);
        tr.rotation = Quaternion.FromToRotation(tr.up, force) * tr.rotation;
    }

    void Move(Planet planet) {
        if(Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            Vector3 dir = rb.position - planet.rb.position;
            rb.AddForce(dir.normalized * 1000f);
        }
    }

    private void Look() {
        rotationinput.x = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

        cameraVerticalAngle = cameraVerticalAngle + rotationinput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);
    }

    private void TriggerFlashLight() {
        if (Input.GetKeyDown(KeyCode.L)) {
            if (flashLight.enabled) {
                flashLight.enabled = false;
            } else {
                flashLight.enabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject == planet)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject == planet)
        {
            grounded = false;
        }
    }
}
