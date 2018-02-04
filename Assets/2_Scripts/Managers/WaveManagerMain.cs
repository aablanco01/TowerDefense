using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManagerMain : MonoBehaviour
{
    //Note to self, when doing the Spawn Manager, the actual variable DOESN'T DO SHIT! It's for the player's reference. 
    //Gotta hard code the waves yourself! YUCK!


    public GameObject Skeleton, Shadowbolt, Grunt, Assassin, FireBall, Calanis;

    public int Wave1Enemies, Wave2Enemies, Wave3Enemies, Wave4Enemies, Wave5Enemies, Wave6Enemies, Wave7Enemies, Wave8Enemies, Wave9Enemies, Wave10Enemies;
    private float DelayinSpawn;
    public float DelayinSpawnMin, DelayinSpawnMax;
    public int NumofWaves; //Number of waves that are expected 
    public int CurrentWave; //Keeps track of what wave the player is currently in
    public int CurrentNumofEnemies; 
    public bool EnemiesInvading;
    public bool Spawning;
    

    public Transform GroundUnitSpawn, FlyingUnitSpawn;

    private UpgradeSystem upgradesystemRef;
    private SpellManager spellmanager_ref;

    [HideInInspector]
    public bool GameStarted, FirstWaveComplete;

    #region Event Subscription
    private void OnEnable()
    {
        EnemyStats.OnEnemyDeath += CheckForEndWave;
    }

    private void OnDisable()
    {
        EnemyStats.OnEnemyDeath -= CheckForEndWave;
    }
    #endregion

    // Use this for initialization
    void Start ()
    {
        upgradesystemRef = GameObject.Find("Upgrade System").GetComponent<UpgradeSystem>();
        spellmanager_ref = GameObject.Find("Spells").GetComponent<SpellManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (EnemiesInvading == true)
        {
            switch (CurrentWave)
            {
                case 1:
                    StartCoroutine(Spawn1());
                    break;
                case 2:
                    StartCoroutine(Spawn2());
                    break;
                case 3:
                    StartCoroutine(Spawn3());
                    break;
            }      
        }
        if (GameStarted)
        {
            EndWave();
        }
    }

    private void CheckForEndWave(object sender, EventArgs e)
    {
        if(CurrentNumofEnemies <= 0)
        {
            EnemiesInvading = false;
            upgradesystemRef.ShowMenu(); 
        }
    }

    protected void SpawnUnit(GameObject Unit, Transform UnitSpawn)
    {
        Instantiate(Unit, UnitSpawn.position, UnitSpawn.rotation);
    }

    protected void EndWave()
    {
            if (CurrentNumofEnemies <= 0)
            {
                if (CurrentWave >= NumofWaves)
                {
                    //Winner winner - Chicken dinner
                    SceneManager.LoadScene(3);
                }
            }
    }

    public void SetEnemyCount()
    {

        switch (CurrentWave)
        {
            case 1:
                CurrentNumofEnemies = Wave1Enemies;
                break;
            case 2:
                CurrentNumofEnemies = Wave2Enemies;
                break;
            case 3:
                CurrentNumofEnemies = Wave3Enemies;
                break;
            case 4:
                CurrentNumofEnemies = Wave4Enemies;
                break;
            case 5:
                CurrentNumofEnemies = Wave5Enemies;
                break;
            case 6:
                CurrentNumofEnemies = Wave6Enemies;
                break;
            case 7:
                CurrentNumofEnemies = Wave7Enemies;
                break;
            case 8:
                CurrentNumofEnemies = Wave8Enemies;
                break;
            case 9:
                CurrentNumofEnemies = Wave9Enemies;
                break;
            case 10:
                CurrentNumofEnemies = Wave10Enemies;
                break;
        }
    }

    void SetTimerDelayByRandom()
    {
        DelayinSpawn = UnityEngine.Random.Range(DelayinSpawnMin, DelayinSpawnMax);
    }


    IEnumerator Spawn1() 
    {

        if (Spawning == false)
        {
            Spawning = true;

            print("Spawning enemy!");
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            upgradesystemRef.CanCheckForWaveEnd = true;
            print("Enemy Spawned!!");
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);


        }

        
    }

    IEnumerator Spawn2()
    {

        if (Spawning == false)
        {
            Spawning = true;

            print("Spawning enemy!");
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            upgradesystemRef.CanCheckForWaveEnd = true;
            print("Enemy Spawned!!");
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);
            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

        }


    }

    IEnumerator Spawn3()
    {

        if (Spawning == false)
        {
            Spawning = true;

            print("Spawning enemy!");
            SetTimerDelayByRandom();
            SpawnUnit(Grunt, GroundUnitSpawn);
            upgradesystemRef.CanCheckForWaveEnd = true;
            print("Enemy Spawned!!");
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Skeleton, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Grunt, GroundUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Grunt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Grunt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

            SetTimerDelayByRandom();
            SpawnUnit(Shadowbolt, FlyingUnitSpawn);
            yield return new WaitForSeconds(DelayinSpawn);

        }


    }


}
