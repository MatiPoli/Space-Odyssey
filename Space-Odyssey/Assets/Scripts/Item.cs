using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{

    public int ID;
    public string type;
    public string descripcion;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool equiped;


    [HideInInspector]
    public GameObject weapon;

    [HideInInspector]
    public GameObject weaponManager;

    public bool playersWeapon;

    private void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");

        if(!playersWeapon)
        {
            int allweapons = weaponManager.transform.childCount;
            for(int i= 0; i< allweapons ; i++)
            {
                if(weaponManager.transform.GetChild(i).GetComponent<Item>().ID==ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
 
                }
            }

        }

    }

    private void Update()
    {
        if (equiped)
        {
            if (Input.GetKeyDown("e"))
            {
                equiped = false;
            }

            if (equiped == false)
            {

            gameObject.SetActive(false);

            }

        }
    }

    public void ItemUsage()
    {

        if (type=="Weapon")
        {
            weapon.SetActive(true);

            weapon.GetComponent<Item>().equiped = true;
        }


    }



}