﻿using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject smallShot;
	public GameObject bigShot;

	public float shotInterval;

	public int upgradeLevel;
	
	float lastShotTime;

	enum ShotType
	{
		Small, 
		Large
	}

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
		switch (upgradeLevel) 
		{
			case 0:
				Level_0_Shoot();
			break;
			case 1:
				Level_1_Shoot();
			break;
			case 2:
				Level_2_Shoot();
			break;
		}

		lastShotTime = Time.realtimeSinceStartup;
	}

	void DoShot(ShotType shotType, Vector3 startPosition, Vector3 targetPosition, float speedBoost)
	{
		GameObject newShot = null;
		Shot shot;

		if (shotType == ShotType.Small) 
			newShot = GameObject.Instantiate(smallShot, transform.position, Quaternion.identity) as GameObject;
		
		if (shotType == ShotType.Large)
			newShot = GameObject.Instantiate(bigShot, transform.position, Quaternion.identity) as GameObject;

		if (newShot != null) 
		{
			shot = newShot.GetComponent<Shot>();

			if(speedBoost > 1f)
				shot.speed *= speedBoost;

			shot.Shoot(targetPosition);
		}

	}

	void Level_0_Shoot()
	{
		DoShot (ShotType.Small, transform.position, Vector3.up, 0f);
	}

	void Level_1_Shoot()
	{
		var shot1XOffset = 0.1f;
		var shot2XOffset = -0.1f;

		var position1 = new Vector3 (transform.position.x + shot1XOffset, transform.position.y, transform.position.z);
		var position2 = new Vector3 (transform.position.x + shot2XOffset, transform.position.y, transform.position.z);

		DoShot (ShotType.Small, position1, Vector3.up, 1.2f);
		DoShot (ShotType.Small, position2, Vector3.up, 1.2f);
	}

	void Level_2_Shoot()
	{
		var shot1XOffset = 0.2f;
		var shot2XOffset = -0.2f;
		var shot3YOffset = 0.15f;
		
		var position1 = new Vector3 (transform.position.x + shot1XOffset, transform.position.y, transform.position.z);
		var position2 = new Vector3 (transform.position.x + shot2XOffset, transform.position.y, transform.position.z);
		var position3 = new Vector3 (transform.position.x, transform.position.y + shot3YOffset, transform.position.z);
		
		DoShot (ShotType.Small, position1, Vector3.up, 1.35f);
		DoShot (ShotType.Small, position2, Vector3.up, 1.35f);
		DoShot (ShotType.Small, position3, Vector3.up, 1.35f);
	}

	void Level_3_Shoot()
	{

	}
}
