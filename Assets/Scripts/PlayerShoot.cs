using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject laserShot;

	void Start () 
	{

	}


	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			var newShot = GameObject.Instantiate(laserShot) as GameObject;

			newShot.transform.position = this.transform.position;
		}
	}
}
