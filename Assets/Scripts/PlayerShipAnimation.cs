using UnityEngine;
using System.Collections.Generic;

public class PlayerShipAnimation : MonoBehaviour 
{

	Animator animator;
	
	bool moving;
	float speed;
	
	void Start () 
	{
		animator = gameObject.GetComponent<Animator>();
	}
	
	void Update () 
	{
		speed = Input.GetAxis("Horizontal");
		
		animator.SetFloat("speed", speed);
	}
}
