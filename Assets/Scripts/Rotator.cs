using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{

	public float rotationSpeed;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		float change = rotationSpeed * Time.deltaTime;

		transform.Rotate (0f, 0f, change);
	}
}
