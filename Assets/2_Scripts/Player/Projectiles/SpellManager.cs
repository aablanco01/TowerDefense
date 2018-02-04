using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public GameObject MagicMissle, ThunderCloud, EarthSpot;

    public enum Spells {NULL,MAGICMISSLE,THUNDER,QUAKE};
    public Spells CurrentSpell;
    public bool MMUnlocked, ThunderUnlocked, EarthSpikeUnlocked;

    public bool CanSpellsbeUsed;

	// Use this for initialization
	void Start ()
    {
        //CurrentSpell = Spells.MAGICMISSLE;
		
	}
	
	// Update is called once per frame
	void Update ()
    {

            SetSpell();
            SwitchSpellsByNumbers();

        
        
	}

    public void SetSpell()
    {
        switch (CurrentSpell)
        {
            case Spells.NULL:
                NullState();
                break;
            case Spells.MAGICMISSLE:
                MagicMissile();
                break;
            case Spells.THUNDER:
                Thunder();
                break;
            case Spells.QUAKE:
                EarthSpike();
                break;
        }
    }

    public void SwitchSpellsByNumbers()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentSpell = Spells.MAGICMISSLE;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentSpell = Spells.THUNDER;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentSpell = Spells.QUAKE;
        }
    }

    public void MagicMissile()
    {
        if (MMUnlocked == true)
        {
            CurrentSpell = Spells.MAGICMISSLE;
            MagicMissle.SetActive(true);
            ThunderCloud.SetActive(false);
            EarthSpot.SetActive(false);
        }
    }

    public void Thunder()
    {
        if (ThunderUnlocked == true)
        {
            CurrentSpell = Spells.THUNDER;
            MagicMissle.SetActive(false);
            ThunderCloud.SetActive(true);
            EarthSpot.SetActive(false);
        }
    }

    public void EarthSpike()
    {
        if (EarthSpikeUnlocked == true)
        {
            CurrentSpell = Spells.QUAKE;
            MagicMissle.SetActive(false);
            ThunderCloud.SetActive(false);
            EarthSpot.SetActive(true);
        }
    }

    public void NullState()
    {
        MagicMissle.SetActive(false);
        ThunderCloud.SetActive(false);
        EarthSpot.SetActive(false);
    }


}
