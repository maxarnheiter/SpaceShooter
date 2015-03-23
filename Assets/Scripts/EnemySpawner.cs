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
    float By = 4f;
    float Cy = 3.5f;
    float Dy = 3f;
    float Ey = 2.5f;

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

        startTime = Time.time;
    }

    void FixedUpdate()
    {
        var now = Time.time;
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
        SpawnGroup(tiny, GroupType.DoubleHorizontal, 5f);

        SpawnGroup(small, GroupType.TripleTriangle, 10f);

        SpawnBuff(13f);

        SpawnGroup(medium, GroupType.Square, 17f);

        SpawnGroup(small, GroupType.DoubleVertical, 27f);

        SpawnGroup(large, GroupType.TripleDiagonal, 35f);

        SpawnGroup(medium, GroupType.TripleWall, 50f);

        SpawnBuff(55f);

        SpawnGroup(tiny, GroupType.SquareWide, 60f);

        SpawnGroup(small_shield, GroupType.Square, 62f);

        SpawnGroup(medium_shield, GroupType.Single, 63f);

        SpawnGroup(tiny, GroupType.SquareWide, 69f);
        SpawnGroup(tiny, GroupType.TripleTriangle, 69f);

        SpawnGroup(boss, GroupType.Single, 70f);
        

         
    }

    void DoNormal()
    {
        SpawnGroup(tiny, GroupType.DoubleHorizontal, 2f);

        SpawnBuff(3f);

        SpawnGroup(tiny_shield, GroupType.DoubleVertical, 4f);

        SpawnGroup(small, GroupType.DoubleHorizontal, 8f);

        SpawnGroup(small_shield, GroupType.TripleTriangle, 14f);

        SpawnGroup(medium, GroupType.Square, 18f);

        SpawnGroup(large_shield, GroupType.Single, 22f);

        SpawnBuff(23f);

        SpawnGroup(tiny_shield, GroupType.TripleDiagonal, 25f);

        SpawnGroup(small, GroupType.DoubleVertical, 29f);

        SpawnGroup(large, GroupType.Single, 34f);

        SpawnGroup(tiny_shield, GroupType.TripleTriangle, 38f);

        SpawnGroup(large, GroupType.Single, 40f);

        SpawnGroup(medium_shield, GroupType.Single, 43f);

        SpawnGroup(medium, GroupType.TripleWall, 51f);

        SpawnBuff(52f);

        SpawnGroup(large, GroupType.Square, 58f);

        SpawnGroup(small_shield, GroupType.TripleWall, 65f);

        SpawnGroup(large_shield, GroupType.Single, 72f);

        SpawnGroup(tiny_shield, GroupType.Square, 83f);

        SpawnGroup(medium_shield, GroupType.TripleWall, 87f);

        SpawnGroup(large_shield, GroupType.Single, 89f);

        SpawnBuff(90f);

        SpawnGroup(small_shield, GroupType.DoubleHorizontal, 93f);

        SpawnGroup(small_shield, GroupType.TripleWall, 97f);

        SpawnGroup(small_shield, GroupType.Square, 103f);

        SpawnGroup(medium_shield, GroupType.Single, 107f);

        SpawnGroup(large_shield, GroupType.DoubleVertical, 112f);

        SpawnGroup(boss, GroupType.Single, 120f);

        SpawnGroup(small, GroupType.Square, 125f);

        SpawnGroup(small, GroupType.Square, 135f);

        SpawnGroup(small, GroupType.Square, 145f);

        SpawnGroup(small, GroupType.Square, 155f);

    }

    void DoHard()
    {
        SpawnBuff(3f);

        SpawnGroup(tiny_shield, GroupType.DoubleVertical, 5f);

        SpawnGroup(tiny_shield, GroupType.TripleTriangle, 8f);

        SpawnGroup(tiny_shield, GroupType.Square, 12f);

        SpawnGroup(small_shield, GroupType.DoubleVertical, 15f);

        SpawnGroup(small_shield, GroupType.TripleTriangle, 19f);

        SpawnGroup(small_shield, GroupType.Square, 24f);

        SpawnGroup(medium_shield, GroupType.Single, 25f);

        SpawnBuff(25f);

        SpawnGroup(medium_shield, GroupType.DoubleHorizontal, 27f);

        SpawnGroup(small_shield, GroupType.Single, 30f);

        SpawnGroup(medium_shield, GroupType.SquareWide, 32f);

        SpawnGroup(small_shield, GroupType.DoubleVertical, 36f);

        SpawnGroup(medium_shield, GroupType.TripleWall, 40f);

        SpawnGroup(tiny_shield, GroupType.DoubleHorizontal, 45f);

        SpawnBuff(50f);

        SpawnGroup(large_shield, GroupType.DoubleHorizontal, 55f);

        SpawnGroup(medium_shield, GroupType.Single, 60f);

        SpawnGroup(large_shield, GroupType.TripleDiagonal, 65f);

        SpawnGroup(medium_shield, GroupType.SquareWide, 70f);

        SpawnGroup(large_shield, GroupType.Single, 74f);

        SpawnBuff(75f);

        SpawnGroup(medium_shield, GroupType.Square, 77f);

        SpawnGroup(large_shield, GroupType.DoubleHorizontal, 82);

        SpawnGroup(large_shield, GroupType.TripleDiagonal, 90f);

        SpawnGroup(small_shield, GroupType.TripleWall, 93f);

        SpawnGroup(tiny_shield, GroupType.Square, 98f);

        SpawnBuff(100f);

        SpawnGroup(small_shield, GroupType.Single, 101f);

        SpawnGroup(small_shield, GroupType.DoubleHorizontal, 103f);

        SpawnGroup(small_shield, GroupType.Single, 105f);

        SpawnGroup(small_shield, GroupType.DoubleVertical, 107f);

        SpawnGroup(small_shield, GroupType.Single, 109f);

        SpawnGroup(small_shield, GroupType.DoubleHorizontal, 111f);

        SpawnGroup(small_shield, GroupType.Single, 113f);

        SpawnGroup(small_shield, GroupType.Single, 115f);

        SpawnGroup(small_shield, GroupType.DoubleVertical, 117f);

        SpawnGroup(small_shield, GroupType.Single, 119f);

        SpawnGroup(small_shield, GroupType.DoubleHorizontal, 121f);

        SpawnGroup(small_shield, GroupType.Single, 123f);

        SpawnBuff(125f);

        SpawnGroup(tiny_shield, GroupType.Square, 127f);

        SpawnGroup(tiny_shield, GroupType.TripleTriangle, 130f);

        SpawnGroup(tiny_shield, GroupType.DoubleHorizontal, 135f);

        SpawnGroup(small_shield, GroupType.TripleWall, 139f);

        SpawnGroup(small_shield, GroupType.DoubleVertical, 144f);

        SpawnGroup(small_shield, GroupType.Square, 148f);

        SpawnGroup(small_shield, GroupType.TripleWall, 152f);

        SpawnGroup(medium_shield, GroupType.DoubleVertical, 155f);

        SpawnGroup(medium_shield, GroupType.TripleDiagonal, 160f);

        SpawnGroup(medium_shield, GroupType.DoubleHorizontal, 165f);

        SpawnGroup(medium_shield, GroupType.Square, 170f);

        SpawnGroup(large_shield, GroupType.Single, 175f);

        SpawnGroup(tiny_shield, GroupType.Square, 180f);

        SpawnGroup(large_shield, GroupType.DoubleHorizontal, 185f);

        SpawnGroup(tiny_shield, GroupType.Square, 190f);

        SpawnGroup(large_shield, GroupType.TripleTriangle, 192f);

        SpawnGroup(boss_shield, GroupType.Single, 200f);
    }

    void DoEndless()
    {
        var elapsed = Time.time - startTime;
        var loopPeriod = 75f;
        var loop = Mathf.Floor(elapsed / loopPeriod);


        //Do once per loop
        SpawnBuff((loop * loopPeriod) + 2);

        SpawnGroup(tiny_shield, GroupType.TripleTriangle, (loop * loopPeriod) + 13);

        SpawnGroup(medium_shield, GroupType.DoubleVertical, (loop * loopPeriod) + 23);

        SpawnGroup(small_shield, GroupType.Square, (loop * loopPeriod) + 27);

        SpawnBuff((loop * loopPeriod) + 30);

        SpawnGroup(large, GroupType.Single, (loop * loopPeriod) + 40);

        SpawnGroup(boss, GroupType.Single, (loop * loopPeriod) + 55);

        //Do i times per loop
        for (int i = 0; i <= loop; i++)
        {
          
            SpawnGroup(tiny, GroupType.Single, (loop * loopPeriod) + 3 + i);

            SpawnGroup(small, GroupType.Single, (loop * loopPeriod) + 9 + i);

            SpawnGroup(small_shield, GroupType.Single, (loop * loopPeriod) + 15 + i);

            SpawnGroup(medium, GroupType.Single, (loop * loopPeriod) + 20 + i);

            SpawnGroup(tiny, GroupType.DoubleHorizontal, (loop * loopPeriod) + 35 + i);

            SpawnGroup(large, GroupType.Single, (loop * loopPeriod) + 45 + i);

            SpawnGroup(large_shield, GroupType.Single, (loop * loopPeriod) + 50 + i);

            SpawnGroup(tiny_shield, GroupType.DoubleHorizontal, (loop * loopPeriod) + 56 + i);

        }
            
    }

    void SpawnBuff(float spawnTime)
    {
        var elapsed = Time.time - startTime;

        if (elapsed >= spawnTime && elapsed <= (spawnTime + minimumSpawnGap))
        {
            float randX = Random.Range(-2.5f, 2.5f);

            GameObject.Instantiate(buff, new Vector3(transform.position.x + randX, transform.position.y, transform.position.z), Quaternion.identity);

            lastSpawnTime = Time.time;
        }
    }

    void SpawnGroup(GameObject enemy, GroupType groupType, float spawnTime)
    {

        var elapsed = Time.time - startTime;

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

            lastSpawnTime = Time.time;
        }
    }

    void Spawn(GameObject enemyPrefab, Vector3 startPosition)
    {
        var newEnemyObject = GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
        EnemySpawn(newEnemyObject, startPosition);
    }
}

