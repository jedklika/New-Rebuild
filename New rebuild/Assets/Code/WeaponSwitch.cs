using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //public bulletTime bulletType;
    public PlayerShoot GunType;
    public int gun;
    GameManger GM;
    // Start is called before the first frame update
    void Start()
    {
        //bulletType = FindObjectOfType<bulletTime>();
        GunType = FindObjectOfType<PlayerShoot>();
        gun = 1;
        Debug.Log("Gun is pistol");
        GM = FindObjectOfType<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && gun != 1)
            {
                Debug.Log("Pistol");
                GunType.bulletSpeed = 3;
                GunType.timeBtwAttack = 1;
                GM.Playerdamage = 1;
                gun = 1;
                GM.Weapon.text = "Pistol"; 
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && gun != 2)
            {
                Debug.Log("Shotgun");
                GunType.bulletSpeed = 2;
                GunType.timeBtwAttack = 3;
                GM.Playerdamage = 2;
                gun = 2;
                GM.Weapon.text = "Shotgun";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && gun != 3)
            {
                Debug.Log("Rifle");
                GunType.bulletSpeed = 3;
                GunType.timeBtwAttack = .5f;
                gun = 3;
                GM.Playerdamage = 1.5f;
                GM.Weapon.text = "Rifle";
            }
        }

    }
}
