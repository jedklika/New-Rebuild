using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    void Update()
    {
        if(Time.time > startTimeBtwAttack)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("melee");
                startTimeBtwAttack = Time.time + timeBtwAttack;
            }
        }

    }
}
