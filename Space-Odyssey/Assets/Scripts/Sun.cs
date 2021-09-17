using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Transform tr;
    public Vector3 rotationSpeed;
    public Vector3 initialRotation;

    private void Awake() {
        tr.Rotate(initialRotation);
    }

    private void FixedUpdate() {
        Rotate();
    }

    void Rotate() {
        tr.Rotate(rotationSpeed);
    }
}
