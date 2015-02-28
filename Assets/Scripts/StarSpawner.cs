using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class StarSpawner : MonoBehaviour 
{

    public float spawnWidthRange;

    public List<GameObject> stars;

    public float spawnInterval;

    float lastStarSpawnTime;
    
	
	void Start () 
    {
	
	}
	
	
	void Update () 
    {
        var now = Time.realtimeSinceStartup;
        var elapsed = now - lastStarSpawnTime;

        if (elapsed >= spawnInterval)
        {
            SpawnStar();
            lastStarSpawnTime = now;
        }

	}

    void SpawnStar()
    {
        int randomStarIndex = Random.Range(0, stars.Count);
        var randomStar = stars.ElementAt(randomStarIndex);

        var randomWidth = Random.Range((spawnWidthRange * -1), spawnWidthRange);

        var newStar = GameObject.Instantiate(randomStar, new Vector3(transform.position.x + randomWidth, transform.position.y, 0f), Quaternion.identity) as GameObject;

        newStar.transform.parent = transform;
    }
}
