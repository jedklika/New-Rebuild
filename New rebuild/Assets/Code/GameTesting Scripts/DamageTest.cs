using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HeartHealthVisual player = GetComponent<Collider2D>().GetComponent<HeartHealthVisual>();
        if (player != null)
        {
            //We hit the player
            //Vector3 knockbackDir = (player.GetPosition()) - transform.position).normalized;
            player.DamageKnockback(damageAmount);
           
        }
    }
}
