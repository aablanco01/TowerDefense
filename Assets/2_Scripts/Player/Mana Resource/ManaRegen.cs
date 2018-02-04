using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegen : MonoBehaviour
{
    ManaPool manapoolRef;
    private int MissingMana;
    private bool Started = false;

	// Use this for initialization
	void Start ()
    {
        manapoolRef = this.gameObject.GetComponent<ManaPool>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (manapoolRef.CurrentMana < manapoolRef.MaxManaPool)
        {
            if (Started == false)
            {
                print("Reached inside the if statement");
                Started = true;
                print("Started is set to true");
                StartCoroutine("RegenMana");
            }
        }
        else
        {
            manapoolRef.CurrentMana = manapoolRef.MaxManaPool;
            Started = false;
        }
	}

    IEnumerator RegenMana()
    {
        while (manapoolRef.CurrentMana < manapoolRef.MaxManaPool)
        {
            print("Reached start of Coroutine");
            manapoolRef.CurrentMana += manapoolRef.ManaRegenRate;
            print("Added mana");
            yield return new WaitForSeconds(manapoolRef.ManaRegenDelay);
        }   
    }
}
