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

    public GameObject buff;

    float Ax = -4.6f;
    float Bx = -2.5f;
    float Cx = 0;
    float Dx = 2.5f;
    float Ex = 4.5f;

    float Ay = 4.5f;
    float By = 3.5f;
    float Cy = 2.5f;
    float Dy = 1.5f;
    float Ey = 0;

    float minimumSpawnGap = 1f;
    float lastSpawnTime;

    float startTime;

    enum GroupType
    {
        DoubleHorizontal,
        DoubleVertical,
        TripleTriangle,
        TripleDiagonal,
        TripleWall,
        Square, 
        SquareWide,
        Single
    }


    event EnemySpawnEventHandler EnemySpawn;

    void Start()
    {
        EnemySpawn += new EnemySpawnEventHandler(GLogic.OnEnemySpawn);

        startTime = Time.realtimeSinceStartup;
    }

    void FixedUpdate()
    {
        var now = Time.realtimeSinceStartup;
        var elapsed = now - lastSpawnTime;

        if (elapsed < minimumSpawnGap)
            return;

       switch(GLogic.difficultyMode)
       {
           case DifficultyMode.Easy:
               DoEasy();
               break;
           case DifficultyMode.Normal:
               DoNormal();
               break;
           case DifficultyMode.Hard:
               DoHard();
               break;
           case DifficultyMode.Endless:
               DoEndless();
               break;
       }
    }

    void DoEasy()
    {

        SpawnGroup(boss, GroupType.Single, 5f);
        SpawnGroup(large, GroupType.TripleDiagonal, 5f);

        /*
        SpawnGroup(tiny, GroupType.DoubleHorizontal, 5f);

        SpawnBuff(8f);

        SpawnGroup(small, GroupType.TripleTriangle, 10f);

        SpawnGroup(medium, GroupType.Square, 17f);

        SpawnGroup(large, GroupType.TripleDiagonal, 35f);

        SpawnGroup(medium, GroupType.TripleWall, 50f);

        SpawnGroup(small, GroupType.SquareWide, 60f);
         * */
    }

    void DoNormal()
    {

    }

    void DoHard()
    {

    }

    void DoEndless()
    {

    }

    void SpawnBuff(float spawnTime)
    {
        var elapsed = Time.realtimeSinceStartup - startTime;

        if (elapsed >= spawnTime && elapsed <= (spawnTime + minimumSpawnGap))
        {
            float randX = Random.Range(-2.5f, 2.5f);

            GameObject.Instantiate(buff, new Vector3(transform.position.x + randX, transform.position.y, transform.position.z), Quaternion.identity);

            lastSpawnTime = Time.realtimeSinceStartup;
        }
    }

    void SpawnGroup(GameObject enemy, GroupType groupType, float spawnTime)
    {
        var elapsed = Time.realtimeSinceStartup - startTime;

        if (elapsed >= spawnTime && elapsed <= (spawnTime + minimumSpawnGap))
        {

            switch(groupType)
            {
                case GroupType.DoubleHorizontal:
                {
                    Spawn(enemy, new Vector3(Bx, By, 0f));
                    Spawn(enemy, new Vector3(Dx, By, 0f));
                }
                break;
                case GroupType.DoubleVertical:
                {
                    Spawn(enemy, new Vector3(Cx, By, 0f));
                    Spawn(enemy, new Vector3(Bx, Dy, 0f));
                }
                break;
                case GroupType.TripleTriangle:
                {
                    Spawn(enemy, new Vector3(Bx, Dy, 0f));
                    Spawn(enemy, new Vector3(Dx, Dy, 0f));
                    Spawn(enemy, new Vector3(Cx, Cy, 0f));
                }
                break;
                case GroupType.TripleDiagonal:
                {
                    Spawn(enemy, new Vector3(Bx, Ey, 0f));
                    Spawn(enemy, new Vector3(Cx, Dy, 0f));
                    Spawn(enemy, new Vector3(Dx, Cy, 0f));
                }
                break;
                case GroupType.TripleWall:
                {
                    Spawn(enemy, new Vector3(Bx, Ey, 0f));
                    Spawn(enemy, new Vector3(Cx, Ey, 0f));
                    Spawn(enemy, new Vector3(Dx, Ey, 0f));
                }
                break;
                case GroupType.Square:
                {
                    Spawn(enemy, new Vector3(Bx, By, 0f));
                    Spawn(enemy, new Vector3(Dx, By, 0f));
                    Spawn(enemy, new Vector3(Bx, Dy, 0f));
                    Spawn(enemy, new Vector3(Dx, Dy, 0f));
                }
                break;
                case GroupType.SquareWide:
                {
                    Spawn(enemy, new Vector3(Ax, Ay, 0f));
                    Spawn(enemy, new Vector3(Ex, Ay, 0f));
                    Spawn(enemy, new Vector3(Ax, Ey, 0f));
                    Spawn(enemy, new Vector3(Ex, Ey, 0f));
                }
                break;
                case GroupType.Single:
                {
                    Spawn(enemy, new Vector3(Cx, Cy, 0f));
                }
                break;
            }

            lastSpawnTime = Time.realtimeSinceStartup;
        }
    }

    void Spawn(GameObject enemyPrefab, Vector3 startPosition)
    {
        var newEnemyObject = GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
        EnemySpawn(newEnemyObject, startPosition);
    }
}

