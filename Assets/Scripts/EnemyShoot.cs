﻿using UnityEngine;
using System.Collections.Generic;

public class EnemyShoot : MonoBehaviour 
{

    public EnemyShootBehavior shootBehavior;
    public float attackInterval;
    public float bombardXRange;
    public float clusterSize;
    public float clusterVariation;
    public float clusterMissVariation;
    public float targetMissVariation;

    public ShotType blindShotType;
    public ShotType targetShotType;
    public ShotType bombardShotType;
    public ShotType clusterShotType;
    public ShotType waveShotType;

    public List<Vector3> wavePositions;

    public GameObject smallShot;
    public GameObject mediumShot;
    public GameObject largeShot;

    float difficulty = 1f;

    public enum EnemyShootBehavior
    {
        BlindFire,
        TargetFire,
        Bombard,
        ClusterFire, 
        WaveBarrage,
    }

    public enum ShotType
    {
        Small, 
        Medium, 
        Large, 
        Random
    }

    bool isVisible;
    GameObject player;

    float lastAttackTime;

	void Start () 
    {
        var difficultyComponent = gameObject.GetComponent<DifficultySetting>();

        if (difficultyComponent != null)
            difficulty = difficultyComponent.difficulty;

        AdjustForDifficulty();
	}

    void AdjustForDifficulty()
    {
        attackInterval = attackInterval + ((attackInterval * difficulty) - attackInterval);

        clusterSize *= Mathf.Ceil(difficulty);

        clusterMissVariation = clusterMissVariation + ((clusterMissVariation * difficulty) - clusterMissVariation);

        targetMissVariation = targetMissVariation + ((targetMissVariation * difficulty) - targetMissVariation);
    }
	

	void Update () 
    {
	    if(isVisible)
        {
            FindPlayer();
            AttackPlayer();
        }
	}

    void OnBecameVisible()
    {
        isVisible = true;
    }

    void OnBecameInvisible()
    {
        isVisible = false;
    }

    void FindPlayer()
    {
        if(player == null)
        {
            player = GameObject.Find("Player Ship");
        }
    }

    void DoShot(ShotType shotType, Vector3 startPosition, Vector3 targetPosition, float speedBoost)
    {
        GameObject newShot = null;
        Shot shot;

        if (shotType == ShotType.Small)
            newShot = GameObject.Instantiate(smallShot, startPosition, Quaternion.identity) as GameObject;

        if (shotType == ShotType.Medium)
            newShot = GameObject.Instantiate(mediumShot, startPosition, Quaternion.identity) as GameObject;

        if(shotType == ShotType.Large)
            newShot = GameObject.Instantiate(largeShot, startPosition, Quaternion.identity) as GameObject;

        if(shotType == ShotType.Random)
            newShot = GameObject.Instantiate(GetRandomShotGameObject(), startPosition, Quaternion.identity) as GameObject;

        if (newShot != null)
        {
            shot = newShot.GetComponent<Shot>();

            if (speedBoost > 1f)
                shot.speed *= speedBoost;

            shot.Shoot(targetPosition);
        }
    }

    void AttackPlayer()
    {
        if (!MinimumTimeElapsed())
            return;

        switch(shootBehavior)
        {
            case EnemyShootBehavior.BlindFire:
                BlindFire();
                break;
            case EnemyShootBehavior.Bombard:
                Bombard();
                break;
            case EnemyShootBehavior.ClusterFire:
                ClusterFire();
                break;
            case EnemyShootBehavior.TargetFire:
                TargetFire();
                break;
            case EnemyShootBehavior.WaveBarrage:
                WaveBarrage();
                break;
        }

        lastAttackTime = Time.realtimeSinceStartup;
    }

    void BlindFire()
    {
        DoShot(blindShotType, transform.position, Vector3.down, 0f);
    }

    void Bombard()
    {
        
        float xChange = Random.Range((bombardXRange * -1f), bombardXRange);
        var startPos = new Vector3(transform.position.x + xChange, transform.position.y, transform.position.z);
        
        DoShot(bombardShotType, startPos, Vector3.down, 0f);
    }

    void ClusterFire()
    {

        for(int i = 0; i <= clusterSize; i++)
        {
            float xChange = Random.Range((clusterVariation * -1f), clusterVariation);
            float yChange = Random.Range((clusterVariation * -1f), clusterVariation);

            float targetXChange = Random.Range((clusterMissVariation * -1f), clusterMissVariation);
            float targetYChange = Random.Range((clusterMissVariation * -1f), clusterMissVariation);

            var startPos = new Vector3(transform.position.x + xChange, transform.position.y + yChange, transform.position.z);

            var targetPos = new Vector3(player.transform.position.x + targetXChange, player.transform.position.y + targetYChange, player.transform.position.z);

            var distance = new Vector3(targetPos.x - transform.position.x, targetPos.y - transform.position.y, 0f);

            DoShot(clusterShotType, startPos, distance, 0f);
        }

    }

    void TargetFire()
    {
        float targetXChange = Random.Range((targetMissVariation * -1f), targetMissVariation);
        float targetYChange = Random.Range((targetMissVariation * -1f), targetMissVariation);

        var targetPos = new Vector3(player.transform.position.x + targetXChange, player.transform.position.y + targetYChange, player.transform.position.z);

        var distance = new Vector3(targetPos.x - transform.position.x, targetPos.y - transform.position.y, 0f);

        DoShot(targetShotType, transform.position, distance, 0f);
    }

    void WaveBarrage()
    {
        if(wavePositions.Count > 0)
        {
            foreach(var position in wavePositions)
            {
                DoShot(waveShotType, transform.position, position, 0f);
            }
        }
    }

    bool MinimumTimeElapsed()
    {
        var now = Time.realtimeSinceStartup;
        var elapsed = now - lastAttackTime;

        if (elapsed >= attackInterval)
            return true;

        return false;
    }

    GameObject GetRandomShotGameObject()
    {
        int random = Random.Range(0, 3);

        if (random == 1)
            return mediumShot;
        if (random == 2)
            return largeShot;

        return smallShot;
    }
}