using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string info;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;
    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    public GameObject weaponManager;
    [HideInInspector]
    public GameObject weapon;
    [HideInInspector]
    public bool playersWeapon;

    private void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");

        if (!playersWeapon) // playerweapon == false
        {
            int allWeapons = weaponManager.transform.childCount;

            for (int i = 0; i < allWeapons; i++)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }
    private void Update()
    {  
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                equipped = !equipped;
                gameObject.SetActive(equipped);
            }
        }
    }

    public void ItemUsage()
    {
        if (type == "weapon")
        {
            switch (info)
            {
                case "AK-47":
                    weapon.SetActive(true);
                    weapon.GetComponent<Item>().equipped = true;
                    // TODO: Añadir distintos stats del arma correspondiente
                    break;
                case "UMP-45":
                    weapon.SetActive(true);
                    weapon.GetComponent<Item>().equipped = true;
                    // TODO: Añadir distintos stats del arma correspondiente
                    break;
                default:
                    break;
            }
        }
        if (type == "powerUp")
        {
            switch (info)
            {
                default:
                    break;
            }
        }
    }

}
