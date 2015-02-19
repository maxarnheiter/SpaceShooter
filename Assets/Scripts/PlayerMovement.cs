using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	float xSpeed;
	float ySpeed;

	float xChange;
	float yChange;

	public float xAdjust;
	public float yAdjust;

	public float forwardBoost;
	public float ySlow;

	public float minimumY;

	public float windResist;

	void Start () 
	{
	
	}

	void Update () 
	{
		xChange = 0;
		yChange = 0;

		xSpeed = Input.GetAxis ("Horizontal");
		ySpeed = Input.GetAxis ("Vertical");

		if (ySpeed > 0)
			ySpeed *= forwardBoost;

		xChange = xSpeed * Time.deltaTime * xAdjust;

		if (ySpeed > 0)
			yChange = (ySpeed * Time.deltaTime * yAdjust);
		else if(transform.position.y > minimumY)
			yChange = (ySpeed * Time.deltaTime * yAdjust) + windResist;



		transform.position = new Vector3(transform.position.x + xChange, transform.position.y + yChange, transform.position.z);

		
	}
}
