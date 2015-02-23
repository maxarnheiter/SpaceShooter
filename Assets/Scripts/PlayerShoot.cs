using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject smallShot;
	public GameObject bigShot;

	public float shotInterval;

	public int upgradeLevel;
	
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

	void Level_0_Shoot()
	{
		var newShot = GameObject.Instantiate(smallShot) as GameObject;
		
		newShot.transform.position = this.transform.position;
	}

	void Level_1_Shoot()
	{
		var shot1XOffset = 0.1f;
		var shot2XOffset = -0.1f;

		var position1 = new Vector3 (transform.position.x + shot1XOffset, transform.position.y, transform.position.z);
		var position2 = new Vector3 (transform.position.x + shot2XOffset, transform.position.y, transform.position.z);

		var shot1 = GameObject.Instantiate (smallShot) as GameObject;
		var shot2 = GameObject.Instantiate (smallShot) as GameObject;

		shot1.transform.position = position1;
		shot2.transform.position = position2;
	}

	void Level_2_Shoot()
	{
		var shot1XOffset = 0.2f;
		var shot2XOffset = -0.2f;
		var shot3YOffset = 0.15f;
		
		var position1 = new Vector3 (transform.position.x + shot1XOffset, transform.position.y, transform.position.z);
		var position2 = new Vector3 (transform.position.x + shot2XOffset, transform.position.y, transform.position.z);
		var position3 = new Vector3 (transform.position.x, transform.position.y + shot3YOffset, transform.position.z);
		
		var shot1 = GameObject.Instantiate (smallShot) as GameObject;
		var shot2 = GameObject.Instantiate (smallShot) as GameObject;
		var shot3 = GameObject.Instantiate (smallShot) as GameObject;
		
		shot1.transform.position = position1;
		shot2.transform.position = position2;
		shot3.transform.position = position3;

	}
}
