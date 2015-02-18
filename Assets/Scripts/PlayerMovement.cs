using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour 
{

	Animator animator;
	
	bool moving;
	float speed;
	
	float speedAdjust = 4f;
	
	void Start () 
	{
		animator = gameObject.GetComponent<Animator>();
	}
	
	void Update () 
	{
		speed = Input.GetAxis("Horizontal");
		
		animator.SetFloat("speed", speed);
		
		float change = speed * Time.deltaTime * speedAdjust;
		
		
		transform.position = new Vector3(transform.position.x + change, transform.position.y, transform.position.z);
	}
}
