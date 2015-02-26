using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour 
{

    public EnemyShootBehavior shootBehavior;
    public float attackInterval;
    public float bombardXRange;
    public float clusterSize;
    public float clusterVariation;
    public float clusterMissVariation;
    public float targetMissVariation;
    public float waveCount;

    public GameObject smallShot;
    public GameObject mediumShot;
    public GameObject largeShot;

    public enum EnemyShootBehavior
    {
        BlindFire,
        TargetFire,
        Bombard,
        ClusterFire, 
        WaveBarrage,
    }

    enum ShotType
    {
        Small, 
        Medium, 
        Large
    }

    bool isVisible;
    GameObject player;

    float lastAttackTime;

	void Start () 
    {
       
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
        DoShot(ShotType.Small, transform.position, Vector3.down, 0f);
    }

    void Bombard()
    {
        int randShot = Random.Range(0, 2);
        float xChange = Random.Range((bombardXRange * -1f), bombardXRange);
        var startPos = new Vector3(transform.position.x + xChange, transform.position.y, transform.position.z);

        if(randShot == 0)
            DoShot(ShotType.Small, startPos, Vector3.down, 0f);
        
        if(randShot == 1)
            DoShot(ShotType.Medium, startPos, Vector3.down, 0f);
    }

    void ClusterFire()
    {
        int randShot = Random.Range(0, 2);

        for(int i = 0; i <= clusterSize; i++)
        {
            float xChange = Random.Range((clusterVariation * -1f), clusterVariation);
            float yChange = Random.Range((clusterVariation * -1f), clusterVariation);

            float targetXChange = Random.Range((clusterMissVariation * -1f), clusterMissVariation);
            float targetYChange = Random.Range((clusterMissVariation * -1f), clusterMissVariation);

            var startPos = new Vector3(transform.position.x + xChange, transform.position.y + yChange, transform.position.z);

            var targetPos = new Vector3(player.transform.position.x + targetXChange, player.transform.position.y + targetYChange, player.transform.position.z);

            var distance = new Vector3(targetPos.x - transform.position.x, targetPos.y - transform.position.y, 0f);

            if (randShot == 0)
                DoShot(ShotType.Small, startPos, distance, 0f);

            if (randShot == 1)
                DoShot(ShotType.Medium, startPos, distance, 0f);
        }

    }

    void TargetFire()
    {
        float targetXChange = Random.Range((targetMissVariation * -1f), targetMissVariation);
        float targetYChange = Random.Range((targetMissVariation * -1f), targetMissVariation);

        var targetPos = new Vector3(player.transform.position.x + targetXChange, player.transform.position.y + targetYChange, player.transform.position.z);

        var distance = new Vector3(targetPos.x - transform.position.x, targetPos.y - transform.position.y, 0f);

        DoShot(ShotType.Medium, transform.position, distance, 0f);
    }

    void WaveBarrage()
    {
        for(int i = 0; i < waveCount; i++)
        {

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
}
