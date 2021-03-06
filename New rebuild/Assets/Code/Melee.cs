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
    public float damage;

    void Update()
    {
        if(Time.time > startTimeBtwAttack)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);

                }
                startTimeBtwAttack = Time.time + timeBtwAttack;
            }
        }

    }
}
