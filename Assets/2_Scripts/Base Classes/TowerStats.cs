using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerStats : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    private EnemyStats enemyRef;

    public Text HealthDisplay;


    private void Awake()
    {
        Health = MaxHealth;
    }

    private void Update()
    {
        HealthDisplay.text = "Health: " + Health + "/" + MaxHealth;
    }


    public void TakeDamage(int Damage)
    {
        Health -= Damage;

        if (Health <= 0)
        {
            Destroyed();
        }
    }


    public void Destroyed()
    {
        //Loser loser, Nyquil Boozer
        Destroy(this.gameObject);
        SceneManager.LoadScene(2);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyStats>())
        {


                enemyRef = other.gameObject.GetComponent<EnemyStats>();
                enemyRef.AtTower = true;

        }
    }


}
