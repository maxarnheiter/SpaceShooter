using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour 
{

	public float speed;

	void Start () 
	{
		var shotBody = gameObject.GetComponent<Rigidbody2D>();
		shotBody.AddForce(Vector2.up * speed, ForceMode2D.Force);
	}
	

	void Update () 
	{
	
	}
}
