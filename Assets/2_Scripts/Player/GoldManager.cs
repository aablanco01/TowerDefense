using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int CurrentGold;
    public Text GoldUI;

    private void Update()
    {
        GoldUI.text = "Gold: " + CurrentGold;   
    }

    public void AddGold(int Value)
    {
        CurrentGold += Value;
    }

    public void RemoveGold(int Value)
    {
        CurrentGold -= Value;
    }
}
