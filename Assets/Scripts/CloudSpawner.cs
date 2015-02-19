using UnityEngine;
using System.Collections.Generic;

public class CloudSpawner : MonoBehaviour 
{
	
	public List<GameObject> clouds;
	
	public float minimumCloudInterval;
	
	public float maximumXVariation;
	public float maximumYVariation;
	
	float lastCloudSpawnTime;
	
	
	void Start () 
	{
		SpawnCloud();
	}
	
	
	void Update () 
	{
		float elapsedTime = Time.realtimeSinceStartup - lastCloudSpawnTime;
		
		if(elapsedTime >= minimumCloudInterval)
			SpawnCloud();

	}
	
	void SpawnCloud()
	{
		var pos = transform.position;
	
		var randomIndex = Random.Range(0, (clouds.Count -1));
		
		var xVariation = Random.Range(maximumXVariation * -1, maximumXVariation);
		var yVariation = Random.Range(maximumYVariation * -1, maximumYVariation);
		
		var startPosition = new Vector3(pos.x + xVariation, pos.y + yVariation, 0f);
		
		var newCloud = GameObject.Instantiate(clouds[randomIndex], startPosition, Quaternion.identity) as GameObject;
		
		newCloud.transform.parent = transform;
		
		lastCloudSpawnTime = Time.realtimeSinceStartup;
	}
	
	
}
