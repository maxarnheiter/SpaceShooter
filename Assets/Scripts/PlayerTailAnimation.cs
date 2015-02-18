using UnityEngine;
using System.Collections;

public class PlayerTailAnimation : MonoBehaviour 
{

	float speed;
	Animator animator;

	void Start () 
	{
		animator = gameObject.GetComponent<Animator> ();
	}
	

	void Update () 
	{
		speed = Input.GetAxis ("Vertical");

		animator.SetFloat ("speed", speed);
	}
}
