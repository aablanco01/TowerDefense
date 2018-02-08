using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SpellsUpgrade : UpgradeSystem
{
    //Upgrades Spells

    //References to the actual spells
    public GameObject MagicMissilePrefab, ThunderPrefab, EarthSpikePrefab;
    private CooldownManager spellCD_Ref;
    private SpellManager spellManager_Ref;
    private SpellBaseClass MagicMissileSpell, ThunderSpell, EarthSpikeSpell;

    //Magic Missile Components
    public enum MagicMissileUpgradeLevel { NULL, LEVELONE, LEVELTWO, LEVELTHREE};
    public MagicMissileUpgradeLevel MMCurrentLevel;
    public int MagicMissileIGoldCost, MagicMissileIIGoldCost, MagicMissileIIIGoldCost;
    public int MagicMissileIManaCost, MagicMissileIIManaCost, MagicMissileIIIManaCost;
    public int MagicMissileIDamage, MagicMissileIIDamage, MagicMissileIIIDamage;
    public float MagicMissileICooldown, MagicMissileIICooldown, MagicMissileIIICooldown;

    //Thunder Componenets
    public enum ThunderUpgradeLevel { NULL, LEVELONE, LEVELTWO, LEVELTHREE};
    public ThunderUpgradeLevel TCurrentLevel;
    public int ThunderIGoldCost, ThunderIIGoldCost, ThunderIIIGoldCost;
    public int ThunderIManaCost, ThunderIIManaCost, ThunderIIIManaCost;
    public int ThunderIDamage, ThunderIIDamage, ThunderIIIDamage;
    public float ThunderICooldown, ThunderIICooldown, ThunderIIICooldown;

    //Earth Spike Componenets
    public enum EarthSpikeUpgradeLevel { NULL, LEVELONE, LEVELTWO, LEVELTHREE};
    public EarthSpikeUpgradeLevel ESCurrentLevel;
    public int EarthSpikeIGoldCost, EarthSpikeIIGoldCost, EarthSpikeIIIGoldCost;
    public int EarthSpikeIManaCost, EarthSpikeIIManaCost, EarthSpikeIIIManaCost;
    public int EarthSpikeIDamage, EarthSpikeIIDamage, EarthSpikeIIIDamage;
    public float EarthSpikeICooldown, EarthSpikeIICooldown, EarthSpikeIIICooldown;


    //Icons for unlocking spells
    private GameObject MagicMissileIcon, ThunderIcon, EarthSpikeIcon;
    private bool MMisBought;
    private GameObject StartButton;

    // Use this for initialization
    void Start ()
    {
        //Collect References
        spellCD_Ref = GameObject.Find("Spells").GetComponent<CooldownManager>();
        spellManager_Ref = GameObject.Find("Spells").GetComponent<SpellManager>();
        MagicMissileSpell = MagicMissilePrefab.GetComponent<SpellBaseClass>();
        ThunderSpell = ThunderPrefab.GetComponent<SpellBaseClass>();
        EarthSpikeSpell = EarthSpikePrefab.GetComponent<SpellBaseClass>();

        MagicMissileGoldText.text = MagicMissileIGoldCost + "g";
        ThunderStrikeGoldText.text = ThunderIGoldCost + "g";
        EarthSpikeGoldText.text = EarthSpikeIGoldCost + "g";

        MagicMissileIcon = GameObject.Find("Magic Missile Icon");
        MagicMissileIcon.SetActive(false);
        ThunderIcon = GameObject.Find("Thunder Icon");
        ThunderIcon.SetActive(false);
        EarthSpikeIcon = GameObject.Find("Earth Spike Icon");
        EarthSpikeIcon.SetActive(false);

        StartButton = GameObject.Find("Next Wave Button");
        StartButton.SetActive(false);
        MagicMissileUpgrade();

    }

    private void Update()
    {
        if (MMisBought == true)
        {
            StartButton.SetActive(true);
        }
    }

    public void MagicMissileUpgrade()
    {
        if (MMCurrentLevel == MagicMissileUpgradeLevel.NULL)
        {
            if (goldRef.CurrentGold >= MagicMissileIGoldCost)
            {
                Analytics.CustomEvent("Magic Missile Upgrade 1");


                spellManager_Ref.MMUnlocked = true;
                goldRef.CurrentGold -= MagicMissileIGoldCost;
                MMCurrentLevel = MagicMissileUpgradeLevel.LEVELONE;
                MMUpgradeValues(MagicMissileIDamage, MagicMissileIManaCost, MagicMissileICooldown);
                MagicMissileGoldText.text = MagicMissileIIGoldCost + "g";
                MagicMissileUpgradeImage1.color = UpgradeColor;
                MagicMissileText.text = "Magic Missile";
                MagicMissileIcon.SetActive(true);
                MMisBought = true;
                // spellManager_Ref.MagicMissile();

            }
        }
        else if (MMCurrentLevel == MagicMissileUpgradeLevel.LEVELONE)
        {
            if (goldRef.CurrentGold >= MagicMissileIIGoldCost)
            {
                Analytics.CustomEvent("Magic Missile Upgrade 2");


                spellManager_Ref.MMUnlocked = true;
                goldRef.CurrentGold -= MagicMissileIIGoldCost;
                MMCurrentLevel = MagicMissileUpgradeLevel.LEVELTWO;
                MMUpgradeValues(MagicMissileIIDamage, MagicMissileIIManaCost, MagicMissileIICooldown);
                MagicMissileGoldText.text = MagicMissileIIIGoldCost + "g";
                MagicMissileUpgradeImage2.color = UpgradeColor;
                MagicMissileText.text = "Magic Missile";
            }
        }
        else if (MMCurrentLevel == MagicMissileUpgradeLevel.LEVELTWO)
        {
            if (goldRef.CurrentGold >= MagicMissileIIIGoldCost)
            {
                Analytics.CustomEvent("Magic Missile Upgrade 3");

                spellManager_Ref.MMUnlocked = true;
                goldRef.CurrentGold -= MagicMissileIIIGoldCost;
                MMCurrentLevel = MagicMissileUpgradeLevel.LEVELTHREE;
                MMUpgradeValues(MagicMissileIIIDamage, MagicMissileIIIManaCost, MagicMissileIIICooldown);
                MagicMissileGoldText.text = "Maxed Out";
                MagicMissileUpgradeImage3.color = UpgradeColor;
                MagicMissileText.text = "Magic Missile";
            }
        }
        else if (MMCurrentLevel == MagicMissileUpgradeLevel.LEVELTHREE)
        {
            //Maxed out!
        }
    }

    public void ThunderUpgrade()
    {
        if (TCurrentLevel == ThunderUpgradeLevel.NULL)
        {
            if (goldRef.CurrentGold >= ThunderIGoldCost)
            {
                Analytics.CustomEvent("Thunder Strike Upgrade 1");


                spellManager_Ref.ThunderUnlocked = true;
                goldRef.CurrentGold -= ThunderIGoldCost;
                TCurrentLevel = ThunderUpgradeLevel.LEVELONE;
                ThunderUpgradeValues(ThunderIDamage, ThunderIManaCost, ThunderICooldown);
                ThunderStrikeGoldText.text = ThunderIIGoldCost + "g";
                ThunderStrikeUpgradeImage1.color = UpgradeColor;
                ThunderStrikeText.text = "Thunder Strike";
                ThunderIcon.SetActive(true);
            }
        }
        else if (TCurrentLevel == ThunderUpgradeLevel.LEVELONE)
        {
            if (goldRef.CurrentGold >= ThunderIGoldCost)
            {
                Analytics.CustomEvent("Thunder Strike Upgrade 2");

                spellManager_Ref.ThunderUnlocked = true;
                goldRef.CurrentGold -= ThunderIIGoldCost;
                TCurrentLevel = ThunderUpgradeLevel.LEVELTWO;
                ThunderUpgradeValues(ThunderIIDamage, ThunderIIManaCost, ThunderIICooldown);
                ThunderStrikeGoldText.text = ThunderIIIGoldCost + "g";
                ThunderStrikeUpgradeImage2.color = UpgradeColor;
                ThunderStrikeText.text = "Thunder Strike";
            }
        }
        else if (TCurrentLevel == ThunderUpgradeLevel.LEVELTWO)
        {
            if (goldRef.CurrentGold >= ThunderIGoldCost)
            {
                Analytics.CustomEvent("Thunder Strike Upgrade 3");

                spellManager_Ref.ThunderUnlocked = true;
                goldRef.CurrentGold -= ThunderIIIGoldCost;
                TCurrentLevel = ThunderUpgradeLevel.LEVELTHREE;
                ThunderUpgradeValues(ThunderIIIDamage, ThunderIIIManaCost, ThunderIIICooldown);
                ThunderStrikeGoldText.text = "Maxed Out";
                ThunderStrikeUpgradeImage3.color = UpgradeColor;
                ThunderStrikeText.text = "Thunder Strike";
            }
        }
        else if (TCurrentLevel == ThunderUpgradeLevel.LEVELTHREE)
        {
            //Maxed out!
        }
    }

    public void EarthSpikeUpgrade()
    {
        if (ESCurrentLevel == EarthSpikeUpgradeLevel.NULL)
        {
            if (goldRef.CurrentGold >= EarthSpikeIGoldCost)
            {
                Analytics.CustomEvent("Earth Spike Upgrade 1");

                spellManager_Ref.EarthSpikeUnlocked = true;
                goldRef.CurrentGold -= EarthSpikeIGoldCost;
                ESCurrentLevel = EarthSpikeUpgradeLevel.LEVELONE;
                EarthSpikeUpgradeValues(EarthSpikeIDamage, EarthSpikeIManaCost, EarthSpikeICooldown);
                EarthSpikeGoldText.text = EarthSpikeIIGoldCost + "g";
                EarthSpikeUpgradeImage1.color = UpgradeColor;
                EarthSpikeText.text = "Earth Spike";
                EarthSpikeIcon.SetActive(true);
            }
        }
        else if (ESCurrentLevel == EarthSpikeUpgradeLevel.LEVELONE)
        {
            if (goldRef.CurrentGold >= EarthSpikeIIGoldCost)
            {
                Analytics.CustomEvent("Earth Spike Upgrade 2");

                spellManager_Ref.EarthSpikeUnlocked = true;
                goldRef.CurrentGold -= EarthSpikeIIGoldCost;
                ESCurrentLevel = EarthSpikeUpgradeLevel.LEVELTWO;
                EarthSpikeUpgradeValues(EarthSpikeIIDamage, EarthSpikeIIManaCost, EarthSpikeIICooldown);
                EarthSpikeGoldText.text = EarthSpikeIIIGoldCost + "g";
                EarthSpikeUpgradeImage2.color = UpgradeColor;
                EarthSpikeText.text = "Earth Spike";
            }
        }
        else if (ESCurrentLevel == EarthSpikeUpgradeLevel.LEVELTWO)
        {
            if (goldRef.CurrentGold >= EarthSpikeIGoldCost)
            {
                Analytics.CustomEvent("Earth Spike Upgrade 3");

                spellManager_Ref.EarthSpikeUnlocked = true;
                goldRef.CurrentGold -= EarthSpikeIIIGoldCost;
                ESCurrentLevel = EarthSpikeUpgradeLevel.LEVELTHREE;
                EarthSpikeUpgradeValues(EarthSpikeIIIDamage, EarthSpikeIIIManaCost, EarthSpikeIIICooldown);
                EarthSpikeGoldText.text = "Maxed Out";
                EarthSpikeUpgradeImage3.color = UpgradeColor;
                EarthSpikeText.text = "Earth Spike";
            }
        }
        else if (ESCurrentLevel == EarthSpikeUpgradeLevel.LEVELTHREE)
        {
            //Maxed out!
        }
    }

    void MMUpgradeValues(int Damage, int ManaCost, float CDValue)
    {
        MagicMissileSpell.SpellDamage = Damage;
        MagicMissileSpell.ManaCost = ManaCost;
        spellCD_Ref.MMCoolDownRate = CDValue;
    }

    void ThunderUpgradeValues(int Damage, int ManaCost, float CDValue)
    {
        ThunderSpell.SpellDamage = Damage;
        ThunderSpell.ManaCost = ManaCost;
        spellCD_Ref.ThunderCoolDownRate = CDValue;
    }

    void EarthSpikeUpgradeValues(int Damage, int ManaCost, float CDValue)
    {
        EarthSpikeSpell.SpellDamage = Damage;
        EarthSpikeSpell.ManaCost = ManaCost;
        spellCD_Ref.ESCoolDownRate = CDValue;
    }





}
