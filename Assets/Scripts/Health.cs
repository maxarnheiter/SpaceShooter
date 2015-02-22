using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public float initialHealth;
	public float currentHealth;

	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log (collision.gameObject);
	}
}
