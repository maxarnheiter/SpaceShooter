using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

    public GameObject tiny;
    public GameObject tiny_shield;
    public GameObject small;
    public GameObject small_shield;
    public GameObject medium;
    public GameObject medium_shield;
    public GameObject large;
    public GameObject large_shield;
    public GameObject boss;
    public GameObject boss_shield;

    event EnemySpawnEventHandler EnemySpawn;

    void Start()
    {
        EnemySpawn += new EnemySpawnEventHandler(GLogic.OnEnemySpawn);
    }

    void Update()
    {
       
    }
}

