using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    private GameObject InfoObject;
    private Text DescriptionTitle, DescriptionText, CurrentLevelTitle, CurrentLevelText, NextLevelTitle, NextLevelText;
    private SpellsUpgrade spellsUpgrade_Ref;
    private ManaUpgrade manaUpgrade_Ref;
    private TowerUpgrade towerUpgrade_Ref;

    // Use this for initialization
    void Start()
    {
        //UI Set Up
        InfoObject = GameObject.Find("Upgrade Info Object");
        DescriptionTitle = GameObject.Find("Description Title").GetComponent<Text>();
        DescriptionText = GameObject.Find("Description Text").GetComponent<Text>();
        CurrentLevelTitle = GameObject.Find("Current Level Title").GetComponent<Text>();
        CurrentLevelText = GameObject.Find("Current Level Text").GetComponent<Text>();
        NextLevelTitle = GameObject.Find("Next Level Title").GetComponent<Text>();
        NextLevelText = GameObject.Find("Next Level Text").GetComponent<Text>();

        //Info for Upgrades
        spellsUpgrade_Ref = GameObject.Find("Upgrade System").GetComponent<SpellsUpgrade>();
        manaUpgrade_Ref = GameObject.Find("Upgrade System").GetComponent<ManaUpgrade>();
        towerUpgrade_Ref = GameObject.Find("Upgrade System").GetComponent<TowerUpgrade>();

        InfoObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }






    public void ShowInfo()
    {
        InfoObject.SetActive(true);
    }

    public void CloseInfo()
    {
        InfoObject.SetActive(false);
    }

    void SpellCurrentLevelWriteOut(int Damage, int Mana, float CD)
    {
        CurrentLevelText.text = "Damage: " + Damage + " / Mana Cost: " + Mana +
                " / Cooldown Speed: " + CD + ".";
    }

    void SpellNextLevelWriteOut(int Damage, int Mana, float CD)
    {
        NextLevelText.text = "Damage: " + Damage + " / Mana Cost: " + Mana +
                " / Cooldown Speed: " + CD + ".";
    }


    public void MagicMissileInformation()
    {
        DescriptionText.text = "Magic Missile is a spell that fires from the top of your tower and aims at an enemy from an angle. Fire a shot " +
            "to damage the enemy.";

        if (spellsUpgrade_Ref.MMCurrentLevel == SpellsUpgrade.MagicMissileUpgradeLevel.NULL)
        {
            CurrentLevelText.text = "Locked!";
            SpellNextLevelWriteOut(spellsUpgrade_Ref.MagicMissileIDamage, spellsUpgrade_Ref.MagicMissileIManaCost, spellsUpgrade_Ref.MagicMissileICooldown);
        }
        else if (spellsUpgrade_Ref.MMCurrentLevel == SpellsUpgrade.MagicMissileUpgradeLevel.LEVELONE)
        {
            
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.MagicMissileIDamage, spellsUpgrade_Ref.MagicMissileIManaCost, spellsUpgrade_Ref.MagicMissileICooldown);
            SpellNextLevelWriteOut(spellsUpgrade_Ref.MagicMissileIIDamage, spellsUpgrade_Ref.MagicMissileIIManaCost, spellsUpgrade_Ref.MagicMissileIICooldown);
        }
        else if (spellsUpgrade_Ref.MMCurrentLevel == SpellsUpgrade.MagicMissileUpgradeLevel.LEVELTWO)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.MagicMissileIIDamage, spellsUpgrade_Ref.MagicMissileIIManaCost, spellsUpgrade_Ref.MagicMissileIICooldown);
            SpellNextLevelWriteOut(spellsUpgrade_Ref.MagicMissileIIIDamage, spellsUpgrade_Ref.MagicMissileIIIManaCost, spellsUpgrade_Ref.MagicMissileIIICooldown);
        }
        else if (spellsUpgrade_Ref.MMCurrentLevel == SpellsUpgrade.MagicMissileUpgradeLevel.LEVELTHREE)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.MagicMissileIIIDamage, spellsUpgrade_Ref.MagicMissileIIIManaCost, spellsUpgrade_Ref.MagicMissileIIICooldown);
            NextLevelText.text = "Maxed out!";
        }
    }

    public void ThunderStrikeInformation()
    {
        DescriptionText.text = "Thunder Strike is a spell that fires from the sky and strikes the first enemy it hits.";

        if (spellsUpgrade_Ref.TCurrentLevel == SpellsUpgrade.ThunderUpgradeLevel.NULL)
        {
            CurrentLevelText.text = "Locked!";
            SpellNextLevelWriteOut(spellsUpgrade_Ref.ThunderIDamage, spellsUpgrade_Ref.ThunderIManaCost, spellsUpgrade_Ref.ThunderICooldown);
        }
        else if (spellsUpgrade_Ref.TCurrentLevel == SpellsUpgrade.ThunderUpgradeLevel.LEVELONE)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.ThunderIDamage, spellsUpgrade_Ref.ThunderIManaCost, spellsUpgrade_Ref.ThunderICooldown);
            SpellNextLevelWriteOut(spellsUpgrade_Ref.ThunderIIDamage, spellsUpgrade_Ref.ThunderIIManaCost, spellsUpgrade_Ref.ThunderIICooldown);
        }
        else if (spellsUpgrade_Ref.TCurrentLevel == SpellsUpgrade.ThunderUpgradeLevel.LEVELTWO)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.ThunderIIDamage, spellsUpgrade_Ref.ThunderIIManaCost, spellsUpgrade_Ref.ThunderIICooldown);
            SpellNextLevelWriteOut(spellsUpgrade_Ref.ThunderIIIDamage, spellsUpgrade_Ref.ThunderIIIManaCost, spellsUpgrade_Ref.ThunderIIICooldown);
        }
        else if (spellsUpgrade_Ref.TCurrentLevel == SpellsUpgrade.ThunderUpgradeLevel.LEVELTHREE)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.ThunderIIIDamage, spellsUpgrade_Ref.ThunderIIIManaCost, spellsUpgrade_Ref.ThunderIIICooldown);
            NextLevelText.text = "Maxed out!";
        }
    }

    public void EarthSpikeInformation()
    {
        DescriptionText.text = "Earth Spike is a spell that strikes enemies from the ground and can hit multiple units at once.";

        if (spellsUpgrade_Ref.ESCurrentLevel == SpellsUpgrade.EarthSpikeUpgradeLevel.NULL)
        {
            CurrentLevelText.text = "Locked!";
            SpellNextLevelWriteOut(spellsUpgrade_Ref.EarthSpikeIDamage, spellsUpgrade_Ref.EarthSpikeIManaCost, spellsUpgrade_Ref.EarthSpikeICooldown);
        }
        else if (spellsUpgrade_Ref.ESCurrentLevel == SpellsUpgrade.EarthSpikeUpgradeLevel.LEVELONE)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.EarthSpikeIDamage, spellsUpgrade_Ref.EarthSpikeIManaCost, spellsUpgrade_Ref.EarthSpikeICooldown);
            SpellNextLevelWriteOut(spellsUpgrade_Ref.EarthSpikeIIDamage, spellsUpgrade_Ref.EarthSpikeIIManaCost, spellsUpgrade_Ref.EarthSpikeIICooldown);
        }
        else if (spellsUpgrade_Ref.ESCurrentLevel == SpellsUpgrade.EarthSpikeUpgradeLevel.LEVELTWO)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.EarthSpikeIIDamage, spellsUpgrade_Ref.EarthSpikeIIManaCost, spellsUpgrade_Ref.EarthSpikeIICooldown);
            SpellNextLevelWriteOut(spellsUpgrade_Ref.EarthSpikeIIIDamage, spellsUpgrade_Ref.EarthSpikeIIIManaCost, spellsUpgrade_Ref.EarthSpikeIIICooldown);
        }
        else if (spellsUpgrade_Ref.ESCurrentLevel == SpellsUpgrade.EarthSpikeUpgradeLevel.LEVELTHREE)
        {
            SpellCurrentLevelWriteOut(spellsUpgrade_Ref.EarthSpikeIIIDamage, spellsUpgrade_Ref.EarthSpikeIIIManaCost, spellsUpgrade_Ref.EarthSpikeIIICooldown);
            NextLevelText.text = "Maxed out!";
        }
    }

    public void ManaPoolInformation()
    {
        DescriptionText.text = "Increases your max mana pool.";

        if (manaUpgrade_Ref.CurrentPool == ManaUpgrade.ManaPoolLevel.NULL)
        {
            CurrentLevelText.text = "Locked!";
            NextLevelText.text = "Increases your mana pool by " + manaUpgrade_Ref.ManaPoolIncreaseI + ".";
        }
        else if (manaUpgrade_Ref.CurrentPool == ManaUpgrade.ManaPoolLevel.LEVELONE)
        {
            CurrentLevelText.text = "Your mana pool was increased by " + manaUpgrade_Ref.ManaPoolIncreaseI + ".";
            NextLevelText.text = "Increases your mana pool by " + manaUpgrade_Ref.ManaPoolIncreaseII + ".";
        }
        else if (manaUpgrade_Ref.CurrentPool == ManaUpgrade.ManaPoolLevel.LEVELTWO)
        {
            CurrentLevelText.text = "Your mana pool was increased by " + manaUpgrade_Ref.ManaPoolIncreaseII + ".";
            NextLevelText.text = "Increases your mana pool by " + manaUpgrade_Ref.ManaPoolIncreaseIII + ".";
        }
        else if (manaUpgrade_Ref.CurrentPool == ManaUpgrade.ManaPoolLevel.LEVELTHREE)
        {
            CurrentLevelText.text = "Your mana pool was increased by " + manaUpgrade_Ref.ManaPoolIncreaseIII + ".";
            NextLevelText.text = "Maxed out!";
        }
    }

    public void ManaRegenInformation()
    {
        DescriptionText.text = "Increases how much mana you recover per second.";

        if (manaUpgrade_Ref.CurrentRegenLevel == ManaUpgrade.ManaRegenLevel.NULL)
        {
            CurrentLevelText.text = "Locked!";
            NextLevelText.text = "Gain " + manaUpgrade_Ref.ManaRegenI + " mana per second.";
        }
        else if (manaUpgrade_Ref.CurrentRegenLevel == ManaUpgrade.ManaRegenLevel.LEVELONE)
        {
            CurrentLevelText.text = "You currently gain " + manaUpgrade_Ref.ManaRegenI + " mana per second.";
            NextLevelText.text = "Gain " + manaUpgrade_Ref.ManaRegenII + " mana per second.";
        }
        else if (manaUpgrade_Ref.CurrentRegenLevel == ManaUpgrade.ManaRegenLevel.LEVELTWO)
        {
            CurrentLevelText.text = "You currently gain " + manaUpgrade_Ref.ManaRegenII + " mana per second.";
            NextLevelText.text = "Gain " + manaUpgrade_Ref.ManaRegenIII + " mana per second.";
        }
        else if (manaUpgrade_Ref.CurrentRegenLevel == ManaUpgrade.ManaRegenLevel.LEVELTHREE)
        {
            CurrentLevelText.text = "You currently gain " + manaUpgrade_Ref.ManaRegenIII + " mana per second.";
            NextLevelText.text = "Maxed out!";
        }
    }

    public void TowerArmorInformation()
    {
        DescriptionText.text = "Increases the max health points your Tower has.";

        if (towerUpgrade_Ref.CurrentLevel == TowerUpgrade.TowerArmorLevels.NULL)
        {
            CurrentLevelText.text = "Locked!";
            NextLevelText.text = "Increase your max health by " + towerUpgrade_Ref.TowerHPIncreaseI + " points.";
        }
        else if (towerUpgrade_Ref.CurrentLevel == TowerUpgrade.TowerArmorLevels.LEVELONE)
        {
            CurrentLevelText.text = "Your max health is increased by " + towerUpgrade_Ref.TowerHPIncreaseI + ".";
            NextLevelText.text = "Increase your max health by " + towerUpgrade_Ref.TowerHPIncreaseII + " points.";
        }
        else if (towerUpgrade_Ref.CurrentLevel == TowerUpgrade.TowerArmorLevels.LEVELTWO)
        {
            CurrentLevelText.text = "Your max health is increased by " + towerUpgrade_Ref.TowerHPIncreaseII + ".";
            NextLevelText.text = "Increase your max health by " + towerUpgrade_Ref.TowerHPIncreaseIII + " points.";
        }
        else if (towerUpgrade_Ref.CurrentLevel == TowerUpgrade.TowerArmorLevels.LEVELTHREE)
        {
            CurrentLevelText.text = "Your max health is increased by " + towerUpgrade_Ref.TowerHPIncreaseIII + ".";
            NextLevelText.text = "Maxed out!";
        }
    }

    public void TowerRestoreInformation()
    {
        DescriptionText.text = "Restores some health to your Tower. Unlimited uses.";
        CurrentLevelText.text = "Restores " + towerUpgrade_Ref.TowerHealthRestore + " health to your tower.";
        NextLevelText.text = "";
    }
}
