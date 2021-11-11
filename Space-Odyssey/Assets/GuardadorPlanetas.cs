using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadorPlanetas : MonoBehaviour
{
    public void VuelvoAlMenu()
    {
        PlayerPrefs.SetInt("scene", 2);
    }

    public void VuelvoAlMenuEarth()
    {
        PlayerPrefs.SetInt("scene", 3);
    }
    public void VuelvoAlMenuAlolea()
    {
        PlayerPrefs.SetInt("scene", 4);
    }
    public void VuelvoAlMenuEgipt()
    {
        PlayerPrefs.SetInt("scene", 5);
    }
    public void VuelvoAlMenuIce()
    {
        PlayerPrefs.SetInt("scene", 6);
    }
    public void VuelvoAlMenuOrange()
    {
        PlayerPrefs.SetInt("scene", 7);
    }
}
