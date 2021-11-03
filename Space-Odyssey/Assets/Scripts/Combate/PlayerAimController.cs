using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAimController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera main_camera;
    [SerializeField]
    private int priorityBoostCam=10;
    [SerializeField]
    private GameObject crosshair;

    bool apuntando=false;

    // Start is called before the first frame update
    void Start()
    {
        crosshair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && !apuntando)
        {
            apuntando = true;

            main_camera.Priority -= priorityBoostCam;

            //Allow time for the camera to blend before enabling the UI
            StartCoroutine(ShowCrosshair());
        }
        else if(!Input.GetMouseButton(1) && apuntando)
        {
            apuntando = false;
            main_camera.Priority += priorityBoostCam;
            crosshair.SetActive(false);
        }
        
    }

    IEnumerator ShowCrosshair()
    {
        yield return new WaitForSeconds(0.15f);
        crosshair.SetActive(enabled);
    }
}
