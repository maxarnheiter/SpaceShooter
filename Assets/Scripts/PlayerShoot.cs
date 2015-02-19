using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject laserShot;
	public float shotInterval;
	
	float lastShotTime;

	void Start () 
	{

	}


	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			float timePassed = Time.realtimeSinceStartup - lastShotTime;
			
			if(timePassed >= shotInterval)
				Shoot ();
		}
	}
	
	void Shoot()
	{
		var newShot = GameObject.Instantiate(laserShot) as GameObject;
		
		newShot.transform.position = this.transform.position;
		
		lastShotTime = Time.realtimeSinceStartup;
	}
}
