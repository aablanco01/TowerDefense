using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBaseClass : MonoBehaviour
{
    public float MoveSpeed;
    public int SpellDamage;
    public float ExpirationTime;

    EnemyStats enemyRef;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyStats>())
        {
            print("Identified as enemy unit!");
            enemyRef = other.gameObject.GetComponent<EnemyStats>();
            print("About to deal damage!");
            enemyRef.TakeDamage(SpellDamage);
            print("Damage dealt!");
            Destroy(this.gameObject);
        } 
    }

}
