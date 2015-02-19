using UnityEngine;
using System.Collections;

public class PlayerWindResist : MonoBehaviour 
{

	public float windFactor;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + windFactor, transform.position.z);
	}
}
