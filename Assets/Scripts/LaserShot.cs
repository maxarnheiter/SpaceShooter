using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour 
{

	public float speed = 4f;
	float change;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		change = speed * Time.deltaTime;

		transform.position = new Vector3 (transform.position.x, transform.position.y + change, transform.position.z);
	}
}
