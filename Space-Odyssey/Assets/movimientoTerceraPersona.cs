using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoTerceraPersona : MonoBehaviour
{
    public CharacterController controller;
    public float velocidad = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hori, 0, verti).normalized;
        
        if(dir.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z)*Mathf.Rad2Deg+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * velocidad * Time.deltaTime);
        }
    }
}
