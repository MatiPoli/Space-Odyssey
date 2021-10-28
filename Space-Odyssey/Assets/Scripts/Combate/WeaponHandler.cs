using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public PlayerCombat[] armas;
    int enabled_weapon = 0;

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

    void Start()
    {
        foreach (PlayerCombat arma in armas)
            arma.enabled = false;
        armas[enabled_weapon].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<keyCodes.Length && i<armas.Length;i++)
            if(Input.GetKeyDown(keyCodes[i]))
            {
                armas[enabled_weapon].enabled = false;
                armas[i].enabled = true;
                enabled_weapon = i;
                break;
            }
    }
}
