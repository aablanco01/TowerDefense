using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    //Autumn Variables - organize later
    public bool CanCheckForWaveEnd { get; set; }

    protected GoldManager goldRef;

    public GameObject UpgradeMenuUI;
    public Color UpgradeColor;

    private WaveManagerMain wavemanageRef;
    private SpellManager spellmanager_Ref;

    //HERE COMES A LIST OF SHIT! GAMEOBJECTS DO NOT FAIL ME NOW!

#region Spells
    protected GameObject MagicMissileTitle, ThunderStrikeTitle, EarthSpikeTitle;
    protected GameObject MagicMissileCost, ThunderStrikeCost, EarthSpikeCost;
    protected GameObject MagicMissileUpgradeSlot1, MagicMissileUpgradeSlot2, MagicMissileUpgradeSlot3;
    protected GameObject ThunderStrikeUpgradeSlot1, ThunderStrikeUpgradeSlot2, ThunderStrikeUpgradeSlot3;
    protected GameObject EarthSpikeUpgradeSlot1, EarthSpikeUpgradeSlot2, EarthSpikeUpgradeSlot3;

    protected Text MagicMissileText, ThunderStrikeText, EarthSpikeText;
    protected Text MagicMissileGoldText, ThunderStrikeGoldText, EarthSpikeGoldText;
    protected Image MagicMissileUpgradeImage1, MagicMissileUpgradeImage2, MagicMissileUpgradeImage3;
    protected Image ThunderStrikeUpgradeImage1, ThunderStrikeUpgradeImage2, ThunderStrikeUpgradeImage3;
    protected Image EarthSpikeUpgradeImage1, EarthSpikeUpgradeImage2, EarthSpikeUpgradeImage3;
    #endregion

    #region Mana Upgrades

    protected GameObject ManaPoolTitle, ManaRegenTitle;
    protected GameObject ManaPoolCost, ManaRegenCost;
    protected GameObject ManaPoolUpgradeSlot1, ManaPoolUpgradeSlot2, ManaPoolUpgradeSlot3;
    protected GameObject ManaRegenUpgradeSlot1, ManaRegenUpgradeSlot2, ManaRegenUpgradeSlot3;

    protected Text ManaPoolText, ManaRegenText;
    protected Text ManaPoolGoldText, ManaRegenGoldText;
    protected Image ManaPoolUpgradeImage1, ManaPoolUpgradeImage2, ManaPoolUpgradeImage3;
    protected Image ManaRegenUpgradeImage1, ManaRegenUpgradeImage2, ManaRegenUpgradeImage3;

    #endregion

    #region Tower Upgrades

    protected GameObject TowerArmorTitle, TowerRestoreTitle;
    protected GameObject TowerArmorCost, TowerRestoreCost;
    protected GameObject TowerRestoreHealthTitle;
    protected GameObject TowerArmorUpgradeSlot1, TowerArmorUpgradeSlot2, TowerArmorUpgradeSlot3;

    protected Text TowerArmorText, TowerRestoreText;
    protected Text TowerArmorGoldText, TowerRestoreGoldText;
    protected Text TowerRestoreHealthText;
    protected Image TowerArmorUpgradeImage1, TowerArmorUpgradeImage2, TowerArmorUpgradeImage3;

    #endregion



    // Use this for initialization
    void Awake ()
    {
        goldRef = GameObject.Find("Gold Manager Object").GetComponent<GoldManager>();
        wavemanageRef = GameObject.Find("Wave Manager").GetComponent<WaveManagerMain>();
        spellmanager_Ref = GameObject.Find("Spells").GetComponent<SpellManager>();

        #region Spells Find

        //Magic Missile References being set.
        MagicMissileTitle = GameObject.Find("Magic Missile Spell Text");
        MagicMissileText = MagicMissileTitle.GetComponent<Text>();
        MagicMissileCost = GameObject.Find("Magic Missile Spell Cost");
        MagicMissileGoldText = MagicMissileCost.GetComponent<Text>();
        MagicMissileUpgradeSlot1 = GameObject.Find("MM Upgrade Slot 1");
        MagicMissileUpgradeImage1 = MagicMissileUpgradeSlot1.GetComponent<Image>();
        MagicMissileUpgradeSlot2 = GameObject.Find("MM Upgrade Slot 2");
        MagicMissileUpgradeImage2 = MagicMissileUpgradeSlot2.GetComponent<Image>();
        MagicMissileUpgradeSlot3 = GameObject.Find("MM Upgrade Slot 3");
        MagicMissileUpgradeImage3 = MagicMissileUpgradeSlot3.GetComponent<Image>();

        //Thunder Strike References being set.
        ThunderStrikeTitle = GameObject.Find("Thunder Strike Spell Text");
        ThunderStrikeText = ThunderStrikeTitle.GetComponent<Text>();
        ThunderStrikeCost = GameObject.Find("Thunder Strike Spell Cost");
        ThunderStrikeGoldText = ThunderStrikeCost.GetComponent<Text>();
        ThunderStrikeUpgradeSlot1 = GameObject.Find("TS Upgrade Slot 1");
        ThunderStrikeUpgradeImage1 = ThunderStrikeUpgradeSlot1.GetComponent<Image>();
        ThunderStrikeUpgradeSlot2 = GameObject.Find("TS Upgrade Slot 2");
        ThunderStrikeUpgradeImage2 = ThunderStrikeUpgradeSlot2.GetComponent<Image>();
        ThunderStrikeUpgradeSlot3 = GameObject.Find("TS Upgrade Slot 3");
        ThunderStrikeUpgradeImage3 = ThunderStrikeUpgradeSlot3.GetComponent<Image>();

        //EarthSpike References being set.
        EarthSpikeTitle = GameObject.Find("Earth Spike Spell Text");
        EarthSpikeText = EarthSpikeTitle.GetComponent<Text>();
        EarthSpikeCost = GameObject.Find("Earth Spike Spell Cost");
        EarthSpikeGoldText = EarthSpikeCost.GetComponent<Text>();
        EarthSpikeUpgradeSlot1 = GameObject.Find("ES Upgrade Slot 1");
        EarthSpikeUpgradeImage1 = EarthSpikeUpgradeSlot1.GetComponent<Image>();
        EarthSpikeUpgradeSlot2 = GameObject.Find("ES Upgrade Slot 2");
        EarthSpikeUpgradeImage2 = EarthSpikeUpgradeSlot2.GetComponent<Image>();
        EarthSpikeUpgradeSlot3 = GameObject.Find("ES Upgrade Slot 3");
        EarthSpikeUpgradeImage3 = EarthSpikeUpgradeSlot3.GetComponent<Image>();

        #endregion

        #region Mana Find

        //Mana Pool References
        ManaPoolTitle = GameObject.Find("Mana Pool Upgrade Text");
        ManaPoolText = ManaPoolTitle.GetComponent<Text>();
        ManaPoolCost = GameObject.Find("Mana Pool Cost Text");
        ManaPoolGoldText = ManaPoolCost.GetComponent<Text>();
        ManaPoolUpgradeSlot1 = GameObject.Find("MP Upgrade Slot 1");
        ManaPoolUpgradeImage1 = ManaPoolUpgradeSlot1.GetComponent<Image>();
        ManaPoolUpgradeSlot2 = GameObject.Find("MP Upgrade Slot 2");
        ManaPoolUpgradeImage2 = ManaPoolUpgradeSlot2.GetComponent<Image>();
        ManaPoolUpgradeSlot3 = GameObject.Find("MP Upgrade Slot 3");
        ManaPoolUpgradeImage3 = ManaPoolUpgradeSlot3.GetComponent<Image>();

        //Mana Regen References
        ManaRegenTitle = GameObject.Find("Mana Regen Upgrade Text");
        ManaRegenText = ManaRegenTitle.GetComponent<Text>();
        ManaRegenCost = GameObject.Find("Mana Regen Cost Text");
        ManaRegenGoldText = ManaRegenCost.GetComponent<Text>();
        ManaRegenUpgradeSlot1 = GameObject.Find("MR Upgrade Slot 1");
        ManaRegenUpgradeImage1 = ManaRegenUpgradeSlot1.GetComponent<Image>();
        ManaRegenUpgradeSlot2 = GameObject.Find("MR Upgrade Slot 2");
        ManaRegenUpgradeImage2 = ManaRegenUpgradeSlot2.GetComponent<Image>();
        ManaRegenUpgradeSlot3 = GameObject.Find("MR Upgrade Slot 3");
        ManaRegenUpgradeImage3 = ManaRegenUpgradeSlot3.GetComponent<Image>();

        #endregion

        #region  Tower Find

        //Tower Armor References
        TowerArmorTitle = GameObject.Find("Tower Armor Upgrade Text");
        TowerArmorText = TowerArmorTitle.GetComponent<Text>();
        TowerArmorCost = GameObject.Find("Tower Armor Cost Text");
        TowerArmorGoldText = TowerArmorCost.GetComponent<Text>();
        TowerArmorUpgradeSlot1 = GameObject.Find("TA Upgrade Slot 1");
        TowerArmorUpgradeImage1 = TowerArmorUpgradeSlot1.GetComponent<Image>();
        TowerArmorUpgradeSlot2 = GameObject.Find("TA Upgrade Slot 2");
        TowerArmorUpgradeImage2 = TowerArmorUpgradeSlot2.GetComponent<Image>();
        TowerArmorUpgradeSlot3 = GameObject.Find("TA Upgrade Slot 3");
        TowerArmorUpgradeImage3 = TowerArmorUpgradeSlot3.GetComponent<Image>();

        //Tower Restore References (THE EASIEST ONE TFG!)
        TowerRestoreTitle = GameObject.Find("Tower Restore Text");
        TowerRestoreText = TowerRestoreTitle.GetComponent<Text>();
        TowerRestoreCost = GameObject.Find("Tower Restore Cost Text");
        TowerRestoreGoldText = TowerRestoreCost.GetComponent<Text>();
        TowerRestoreHealthTitle = GameObject.Find("Tower Heal Text");
        TowerRestoreHealthText = TowerRestoreHealthTitle.GetComponent<Text>();


        #endregion 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowMenu()
    {
        UpgradeMenuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        wavemanageRef.GameStarted = true;
        wavemanageRef.Spawning = false;
        wavemanageRef.CurrentWave++;
        wavemanageRef.EnemiesInvading = true;
        UpgradeMenuUI.SetActive(false);
        wavemanageRef.SetEnemyCount();
    }
}
