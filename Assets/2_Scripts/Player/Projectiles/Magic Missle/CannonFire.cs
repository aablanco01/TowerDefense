using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public GameObject MagicMissilePrefab;
    private GameObject AmmoType, AmmoRef;
    public Transform bulletSpawn;

    private int CastCost;

    private ManaPool manapoolRef;
    private CooldownManager CD_Ref;


    private void Start()
    {
        AmmoType = MagicMissilePrefab;
        manapoolRef = GameObject.Find("Mana Manager").GetComponent<ManaPool>();
        CD_Ref = GameObject.Find("Spells").GetComponent<CooldownManager>();
        CastCost = MagicMissilePrefab.GetComponent<SpellBaseClass>().ManaCost;
    }


    // Update is called once per frame
    void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (manapoolRef.CurrentMana >= CastCost)
            {
                if (CD_Ref.MMCasted == false)
                {
                    manapoolRef.CurrentMana -= CastCost;
                    Fire();
                }
            }
            else
            {
                //Out of Mana!
            }

        }
	}


    void Fire()
    {
        CD_Ref.MMCasted = true;

        GameObject bullet = Instantiate(AmmoType, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * AmmoType.GetComponent<SpellBaseClass>().MoveSpeed;

        Destroy(bullet, AmmoType.GetComponent<SpellBaseClass>().ExpirationTime);
    }
}
