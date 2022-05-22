using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemies : MonoBehaviour
{
    public float Damage = 20;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            var damageTaker = other.GetComponent<EnemyTakeDamage>();
            if (damageTaker != null)
            {
                damageTaker.TakeDamage(Damage);
            }
        }
    }
}
