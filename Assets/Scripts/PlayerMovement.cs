using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	float xSpeed;
	float ySpeed;

	float xChange;
	float yChange;

	float xAdjust = 3f;
	float yAdjust = 1f;

	float yBoost = 2f;
	float ySlow = 0.8f;

	void Start () 
	{
	
	}

	void Update () 
	{
		xSpeed = Input.GetAxis ("Horizontal");
		ySpeed = Input.GetAxis ("Vertical");

		if (ySpeed > 0)
			ySpeed *= yBoost;
		if (ySpeed < 0)
			ySpeed *= ySlow;

		xChange = xSpeed * Time.deltaTime * xAdjust;
		yChange = ySpeed * Time.deltaTime * yAdjust;

		transform.position = new Vector3(transform.position.x + xChange, transform.position.y + yChange, transform.position.z);
	}
}
