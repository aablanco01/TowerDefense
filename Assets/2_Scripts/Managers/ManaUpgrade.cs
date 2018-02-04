using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUpgrade : UpgradeSystem
{
    private ManaPool manapoolRef;
    private ManaRegen manaregenRef;

    //Variables for Mana Regen Upgrade
    public enum ManaRegenLevel {NULL, LEVELONE, LEVELTWO, LEVELTHREE };
    public ManaRegenLevel CurrentRegenLevel;
    public int ManaRegenIGoldCost, ManaRegenIIGoldCost, ManaRegenIIIGoldCost;
    public int ManaRegenI, ManaRegenII, ManaRegenIII;

    //Variables for Mana Pool Upgrade
    public enum ManaPoolLevel {NULL, LEVELONE, LEVELTWO, LEVELTHREE };
    public ManaPoolLevel CurrentPool;
    public int ManaPoolGoldCostI, ManaPoolGoldCostII, ManaPoolGoldCostIII;
    public int ManaPoolIncreaseI, ManaPoolIncreaseII, ManaPoolIncreaseIII;

	// Use this for initialization
	void Start ()
    {
        manapoolRef = GameObject.Find("Mana Manager").GetComponent<ManaPool>();
        manaregenRef = GameObject.Find("Mana Manager").GetComponent<ManaRegen>();

        ManaPoolGoldText.text = ManaPoolGoldCostI + "g";
        ManaRegenGoldText.text = ManaRegenIGoldCost + "g";

    }

    public void UpgradeManaRegen()
    {
        if (CurrentRegenLevel == ManaRegenLevel.NULL)
        {
            if (goldRef.CurrentGold >= ManaRegenIGoldCost)
            {
                goldRef.CurrentGold -= ManaRegenIGoldCost;
                manapoolRef.ManaRegenRate = ManaRegenI;
                CurrentRegenLevel = ManaRegenLevel.LEVELONE;
                ManaRegenGoldText.text = ManaRegenIIGoldCost + "g";
                ManaRegenText.text = "Mana Regen";
                ManaRegenUpgradeImage1.color = UpgradeColor;
            }
        }
        else if (CurrentRegenLevel == ManaRegenLevel.LEVELONE)
        {
            if (goldRef.CurrentGold >= ManaRegenIIGoldCost)
            {
                goldRef.CurrentGold -= ManaRegenIIGoldCost;
                manapoolRef.ManaRegenRate = ManaRegenII;
                CurrentRegenLevel = ManaRegenLevel.LEVELTWO;
                ManaRegenGoldText.text = ManaRegenIIIGoldCost + "g";
                ManaRegenText.text = "Mana Regen";
                ManaRegenUpgradeImage2.color = UpgradeColor;
            }
        }
        else if (CurrentRegenLevel == ManaRegenLevel.LEVELTWO)
        {
            if (goldRef.CurrentGold >= ManaRegenIIIGoldCost)
            {
                goldRef.CurrentGold -= ManaRegenIIIGoldCost;
                manapoolRef.ManaRegenRate = ManaRegenIII;
                CurrentRegenLevel = ManaRegenLevel.LEVELTHREE;
                ManaRegenGoldText.text = "Maxed Out";
                ManaRegenText.text = "Mana Regen";
                ManaRegenUpgradeImage3.color = UpgradeColor;
            }
        }
        else if (CurrentRegenLevel == ManaRegenLevel.LEVELTHREE)
        {
            //Maxed out!
        }
    }

    public void UpgradeManaPool()
    {
        if (CurrentPool == ManaPoolLevel.NULL)
        {
            if (goldRef.CurrentGold >= ManaPoolGoldCostI)
            {
                goldRef.CurrentGold -= ManaPoolGoldCostI;
                manapoolRef.MaxManaPool += ManaPoolIncreaseI;
                manapoolRef.CurrentMana = manapoolRef.MaxManaPool;
                CurrentPool = ManaPoolLevel.LEVELONE;
                ManaPoolGoldText.text = ManaPoolGoldCostII + "g";
                ManaPoolText.text = "Mana Pool Increase";
                ManaPoolUpgradeImage1.color = UpgradeColor;
            }
        }
        else if (CurrentPool == ManaPoolLevel.LEVELONE)
        {
            if (goldRef.CurrentGold >= ManaPoolGoldCostII)
            {
                goldRef.CurrentGold -= ManaPoolGoldCostII;
                manapoolRef.MaxManaPool += ManaPoolIncreaseII;
                manapoolRef.CurrentMana = manapoolRef.MaxManaPool;
                CurrentPool = ManaPoolLevel.LEVELTWO;
                ManaPoolGoldText.text = ManaPoolGoldCostIII + "g";
                ManaPoolText.text = "Mana Pool Increase";
                ManaPoolUpgradeImage2.color = UpgradeColor;
            }
        }
        else if (CurrentPool == ManaPoolLevel.LEVELTWO)
        {
            if (goldRef.CurrentGold >= ManaPoolGoldCostIII)
            {
                goldRef.CurrentGold -= ManaPoolGoldCostIII;
                manapoolRef.MaxManaPool += ManaPoolIncreaseIII;
                manapoolRef.CurrentMana = manapoolRef.MaxManaPool;
                CurrentPool = ManaPoolLevel.LEVELTHREE;
                ManaPoolGoldText.text = "Maxed Out";
                ManaPoolText.text = "Mana Pool Increase";
                ManaPoolUpgradeImage3.color = UpgradeColor;
            }
        }
        else if (CurrentPool == ManaPoolLevel.LEVELTHREE)
        {

        }
    }
}
