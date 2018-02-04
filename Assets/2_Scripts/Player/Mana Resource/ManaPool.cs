using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPool : MonoBehaviour
{

    public int MaxManaPool;
    public int CurrentMana;

    public int ManaRegenRate;
    public float ManaRegenDelay;

    public Text ManaUI;

    // Use this for initialization
    void Start()
    {
        CurrentMana = MaxManaPool;
    }

    // Update is called once per frame
    void Update()
    {
        ManaUI.text = "Mana: " + CurrentMana + "/" + MaxManaPool;
    }

    
    

    public void IncreaseManaPool(int NewMax)
    {
        MaxManaPool += NewMax;
    }

    public void SpendMana(int ManaCost)
    {
        CurrentMana -= ManaCost;
    }

    public void AddMana(int Value)
    {
        CurrentMana += Value;
    }
}
