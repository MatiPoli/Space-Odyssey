using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadorHavay : MonoBehaviour
{

    public void VuelvoAlMenu()
    {
        PlayerPrefs.SetInt("scene", 2);
    }
}
