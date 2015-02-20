using UnityEngine;
using System.Collections;

public class GameBounds : MonoBehaviour 
{

	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log ("collision");
		Destroy(collision.gameObject);
	}
}
