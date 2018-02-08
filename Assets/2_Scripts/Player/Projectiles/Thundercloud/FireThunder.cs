using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FireThunder : MonoBehaviour
{
    public GameObject ThunderPrefab;
    private GameObject AmmoType, AmmoRef;
    public Transform bulletSpawn;
    private int CastCost;

    private ManaPool manapoolRef;
    private CooldownManager CD_Ref;


    // Use this for initialization
    void Start ()
    {
        AmmoType = ThunderPrefab;	
        manapoolRef = GameObject.Find("Mana Manager").GetComponent<ManaPool>();
        CD_Ref = GameObject.Find("Spells").GetComponent<CooldownManager>();
        CastCost = ThunderPrefab.GetComponent<SpellBaseClass>().ManaCost;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (manapoolRef.CurrentMana >= CastCost)
            {
                if (CD_Ref.ThunderCasted == false)
                {
                    Analytics.CustomEvent("Thunder Strike Usage");

                    manapoolRef.CurrentMana -= CastCost;
                    Fire();
                }
            }
            else
            {
                Analytics.CustomEvent("Ran out of Mana");
                //Out of Mana!
            }
            
        }
    }

    void Fire()
    {

        CD_Ref.ThunderCasted = true;

        //Create the Bullet from the Bullet prefab
        GameObject bullet = Instantiate(AmmoType, bulletSpawn.position, bulletSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * AmmoType.GetComponent<SpellBaseClass>().MoveSpeed;

        //Destroy the bullet after 2 seconds.
        Destroy(bullet, AmmoType.GetComponent<SpellBaseClass>().ExpirationTime);
    }
}
