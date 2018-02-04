using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    public bool MMCasted, ThunderCasted, ESCasted;
    public float MMCoolDownRate, ThunderCoolDownRate, ESCoolDownRate;

    private bool AlreadyCD1, AlreadyCD2, AlreadyCD3;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (MMCasted == true)
        {
            if(AlreadyCD1 == false)
            {
                AlreadyCD1 = true;
                StartCoroutine(MagicMissileCoolDown());
            }
            
        }
        else if (ThunderCasted == true)
        {
            if (AlreadyCD2 == false)
            {
                AlreadyCD2 = true;
                StartCoroutine(ThunderCloudCoolDown());
            }
        }
        else if (ESCasted == true)
        {
            if (AlreadyCD3 == false)
            {
                AlreadyCD3 = true;
                StartCoroutine(EarthSpikeCoolDown());
            }
        }
	}

    IEnumerator MagicMissileCoolDown()
    {
        yield return new WaitForSeconds(MMCoolDownRate);
        MMCasted = false;
        AlreadyCD1 = false;
    }

    IEnumerator ThunderCloudCoolDown()
    {
        yield return new WaitForSeconds(ThunderCoolDownRate);
        ThunderCasted = false;
        AlreadyCD2 = false;
    }

    IEnumerator EarthSpikeCoolDown()
    {
        yield return new WaitForSeconds(ESCoolDownRate);
        ESCasted = false;
        AlreadyCD3 = false;
    }
}
