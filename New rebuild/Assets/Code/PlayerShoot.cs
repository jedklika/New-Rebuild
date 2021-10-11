using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour

{
    public GameObject bullet; // bullet thing will have forward movement in its seperate script
    public float bulletSpeed;
    Vector3 myScreenPos;  // screen position of player
    public float timeBtwAttack;
    public float startTimeBtwAttack;

    void Start()
    {
        myScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
    }
    void Update()
    {
        if(Time.time > startTimeBtwAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bulletShoot = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
                Vector3 direction = (Input.mousePosition - myScreenPos).normalized;
                bulletShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * bulletSpeed;
                startTimeBtwAttack = Time.time + timeBtwAttack;
            }
        }
    }
}