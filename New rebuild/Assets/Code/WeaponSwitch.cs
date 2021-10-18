using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    //public bulletTime bulletType;
    public PlayerShoot GunType;
    public int gun;
    public float timeBtwSwitch;
    public float startTimeBtwSwitch;
    // Start is called before the first frame update
    void Start()
    {
        //bulletType = FindObjectOfType<bulletTime>();
        GunType = FindObjectOfType<PlayerShoot>();
        gun = 1;
        Debug.Log("Gun is pistol");
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1) && gun != 1 && Time.time > startTimeBtwSwitch)
            {
                Debug.Log("Pistol");
                //bulletType.lifeTime = 5;
                //bulletType.SR.color = Color.red;
                GunType.bulletSpeed = 3;
                GunType.timeBtwAttack = 1;
                gun = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && gun != 2 && Time.time > startTimeBtwSwitch)
            {
                Debug.Log("Shotgun");
                //bulletType.lifeTime = 2;
                //bulletType.SR.color = Color.green;
                GunType.bulletSpeed = 2;
                GunType.timeBtwAttack = 3;
                gun = 2;
                timeBtwSwitch = 5;
                startTimeBtwSwitch = Time.time + timeBtwSwitch;
        }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && gun != 3 && Time.time > startTimeBtwSwitch)
            {
                Debug.Log("Rifle");
                //bulletType.lifeTime = 5;
                //bulletType.SR.color = Color.cyan;
                GunType.bulletSpeed = 3;
                GunType.timeBtwAttack = .2f;
                gun = 3;
                timeBtwSwitch = 5;
                startTimeBtwSwitch = Time.time + timeBtwSwitch;
        }
    }
}
