using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{

    public float fallSpeed;

    Rigidbody2D body;
	
	void Start () 
    {
        body = gameObject.GetComponent<Rigidbody2D>();

        body.velocity = Vector3.down * fallSpeed;
	}
	
	
	void Update () 
    {
	
	}
}
