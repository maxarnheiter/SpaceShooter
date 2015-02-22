using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour 
{

	public float speed;

	public float damage;

	void Start () 
	{
		var shotBody = gameObject.GetComponent<Rigidbody2D>();
		shotBody.AddForce(Vector2.up * speed, ForceMode2D.Force);
	}
	

	void Update () 
	{
	
	}
}
