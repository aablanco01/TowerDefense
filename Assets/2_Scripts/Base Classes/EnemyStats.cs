using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static EventHandler OnEnemyDeath;

    public string Name;
    public int Health;
    public int GoldDrop;
    public int Damage;
    public float PerSecond;
    public float MoveSpeed;
    [HideInInspector]
    public bool AtTower = false;

    public bool IsSpell;
    public bool IsFlying;
    private bool isAttacking = false;

    //References to the Tower
    private Transform MageTower, TopMageTower;
    private TowerStats TowerStat_Ref;
    private GoldManager goldRef;
    private WaveManagerMain wavemanagerRef;
    

    void Awake()
    {
        MageTower = GameObject.Find("Mage Tower").GetComponent<Transform>();
        TopMageTower = GameObject.Find("Top Tower Position").GetComponent<Transform>();
        TowerStat_Ref = GameObject.Find("Tower Hit Collider").GetComponent<TowerStats>();
        goldRef = GameObject.Find("Gold Manager Object").GetComponent<GoldManager>();
        wavemanagerRef = GameObject.Find("Wave Manager").GetComponent<WaveManagerMain>();
    }

    void Update()
    {
        MoveTowardsTower();
    }


    public void MoveTowardsTower()
    {
        if (AtTower == false)
        {
            if (IsSpell == true || IsFlying == true)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, TopMageTower.position, MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(this.transform.position, MageTower.position, MoveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (isAttacking == false)
            {
                isAttacking = true;
                StartCoroutine(AttackTower());
            }
        }
    }

    IEnumerator AttackTower()
    {

        TowerStat_Ref.TakeDamage(Damage);

        if (IsSpell == false)
        {
            yield return new WaitForSeconds(PerSecond);
            isAttacking = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    public void TakeDamage(int SpellDamage)
    {
        Health -= SpellDamage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        goldRef.AddGold(GoldDrop);
        wavemanagerRef.CurrentNumofEnemies--;
        OnEnemyDeath(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }

}
