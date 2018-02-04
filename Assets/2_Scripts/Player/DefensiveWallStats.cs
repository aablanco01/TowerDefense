using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveWallStats : MonoBehaviour
{
    public int WallHealth;


    public void TakeDamage(int Damage)
    {
        WallHealth -= Damage;
    }
}
