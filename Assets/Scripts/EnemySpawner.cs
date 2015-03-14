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

    enum GroupType
    {
        DoubleHorizontal,
        DoubleVertical,
        TripleTriangle,
        TripleDiagonal,
        TripleWall,
        Square, 
        SquareWide
    }


    event EnemySpawnEventHandler EnemySpawn;

    void Start()
    {
        EnemySpawn += new EnemySpawnEventHandler(GLogic.OnEnemySpawn);
    }

    void FixedUpdate()
    {
        var now = Time.realtimeSinceStartup;
        var elapsed = now - lastSpawnTime;

        if (elapsed < minimumSpawnGap)
            return;

       switch(GLogic.gameMode)
       {
           case GameMode.Easy:
               DoEasy();
               break;
           case GameMode.Normal:
               DoNormal();
               break;
           case GameMode.Hard:
               DoHard();
               break;
           case GameMode.Endless:
               DoEndless();
               break;
       }
    }

    void DoEasy()
    {
        SpawnGroup(tiny, GroupType.DoubleHorizontal, 10f);

        SpawnGroup(small, GroupType.TripleTriangle, 15f);
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

    

    void SpawnGroup(GameObject enemy, GroupType groupType, float spawnTime)
    {
        var now = Time.realtimeSinceStartup;

        if (now >= spawnTime && now <= (spawnTime + minimumSpawnGap))
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

                }
                break;
                case GroupType.TripleWall:
                {

                }
                break;
                case GroupType.Square:
                {

                }
                break;
                case GroupType.SquareWide:
                {

                }
                break;
            }

            lastSpawnTime = now;
        }
    }

    void Spawn(GameObject enemy, Vector3 startPosition)
    {
        GameObject.Instantiate(enemy, transform.position, Quaternion.identity);
        EnemySpawn(enemy, startPosition);
    }
}

