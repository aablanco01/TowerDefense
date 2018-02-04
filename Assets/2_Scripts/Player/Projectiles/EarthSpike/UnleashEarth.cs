using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnleashEarth : MonoBehaviour
{
    public GameObject SpikePrefab;
    public float RetreatToEarth;
    private int CostCast;
    private bool IsCast;

    HorizontalMovement EarthMovement;
    ManaPool manapoolRef;



	// Use this for initialization
	void Start ()
    {
        SpikePrefab.SetActive(false);
        EarthMovement = this.gameObject.GetComponent<HorizontalMovement>();
        manapoolRef = GameObject.Find("Mana Manager").GetComponent<ManaPool>();
        CostCast = SpikePrefab.GetComponent<SpellBaseClass>().ManaCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (manapoolRef.CurrentMana >= CostCast)
            {
                if (IsCast == false)
                {
                    manapoolRef.CurrentMana -= CostCast;
                    IsCast = true;
                    StartCoroutine("ShowEarth");
                }
            }
            else
            {
                //Out of Mana!
            }

            
        }
    }

    IEnumerator ShowEarth()
    {
        SpikePrefab.SetActive(true);
        EarthMovement.enabled = false;
        yield return new WaitForSeconds(RetreatToEarth);
        SpikePrefab.SetActive(false);
        EarthMovement.enabled = true;
        IsCast = false;
    }
}
