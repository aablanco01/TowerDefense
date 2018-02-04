using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDamage : MonoBehaviour
{
    public int SpellDamage;

    EnemyStats enemyRef;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //If an enemy is within the ball of earth's trigger when it rises, they'll lose Damage amount of HP.

        if (other.gameObject.GetComponent<EnemyStats>())
        {
            print("Identified as enemy unit!");
            enemyRef = other.gameObject.GetComponent<EnemyStats>();
            print("About to deal damage!");
            enemyRef.TakeDamage(SpellDamage);
            print("Damage dealt!");
        }
    }
}
