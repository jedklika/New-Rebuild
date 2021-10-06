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
        if (Input.GetMouseButtonDown(1) && timeBtwAttack >= 5)
        {
            timeBtwAttack = 0;
            Debug.Log("melee");
            Debug.Log(timeBtwAttack);
        }
        else if (Input.GetMouseButtonDown(1) && timeBtwAttack < 5)
        {
            Debug.Log("too soon");
            timeBtwAttack = 0;
            Debug.Log(timeBtwAttack);
        }
    }
}
