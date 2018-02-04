using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : UpgradeSystem
{
    TowerStats towerRef;


    public int TowerHealthRestore;
    public int TowerRestoreGoldCost;
    public enum TowerArmorLevels {NULL, LEVELONE, LEVELTWO, LEVELTHREE }
    public TowerArmorLevels CurrentLevel;
    public int TowerArmorGoldCostI, TowerArmorGoldCostII, TowerArmorGoldCostIII;
    public int TowerHPIncreaseI, TowerHPIncreaseII, TowerHPIncreaseIII;



	// Use this for initialization
	void Start ()
    {
        towerRef = GameObject.Find("Tower Hit Collider").GetComponent<TowerStats>();

        TowerArmorGoldText.text = TowerArmorGoldCostI + "g";
        TowerRestoreGoldText.text = TowerRestoreGoldCost + "g";
        TowerRestoreHealthText.text = TowerHealthRestore + " HP";
	}

    public void UpgradeTowerArmor()
    {
        if (CurrentLevel == TowerArmorLevels.NULL)
        {
            if (goldRef.CurrentGold >= TowerArmorGoldCostI)
            {
                goldRef.CurrentGold -= TowerArmorGoldCostI;
                CurrentLevel = TowerArmorLevels.LEVELONE;
                towerRef.MaxHealth += TowerHPIncreaseI;

                TowerArmorGoldText.text = TowerArmorGoldCostII + "g";
                TowerArmorText.text = "Tower Armor";
                TowerArmorUpgradeImage1.color = UpgradeColor;
            }
        }
        else if (CurrentLevel == TowerArmorLevels.LEVELONE)
        {
            if (goldRef.CurrentGold >= TowerArmorGoldCostII)
            {
                goldRef.CurrentGold -= TowerArmorGoldCostII;
                CurrentLevel = TowerArmorLevels.LEVELTWO;
                towerRef.MaxHealth += TowerHPIncreaseII;

                TowerArmorGoldText.text = TowerArmorGoldCostIII + "g";
                TowerArmorText.text = "Tower Armor";
                TowerArmorUpgradeImage2.color = UpgradeColor;
            }
        }
        else if (CurrentLevel == TowerArmorLevels.LEVELTWO)
        {
            if (goldRef.CurrentGold >= TowerArmorGoldCostIII)
            {
                goldRef.CurrentGold -= TowerArmorGoldCostIII;
                CurrentLevel = TowerArmorLevels.LEVELTHREE;
                towerRef.MaxHealth += TowerHPIncreaseIII;

                TowerArmorGoldText.text = "Maxed Out";
                TowerArmorText.text = "Tower Armor";
                TowerArmorUpgradeImage3.color = UpgradeColor;
            }
        }
        else if (CurrentLevel == TowerArmorLevels.LEVELTHREE)
        {
            //Maxed out
        }
    }

    public void RestoreTowerHP()
    {
        if (goldRef.CurrentGold >= TowerRestoreGoldCost)
        {
            if (towerRef.Health < towerRef.MaxHealth)
            {
                goldRef.CurrentGold -= TowerRestoreGoldCost;
                towerRef.Health += TowerHealthRestore;

                if (towerRef.Health > towerRef.MaxHealth)
                {
                    towerRef.Health = towerRef.MaxHealth;
                }
            }
        }
    }
}
