using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour 
{

	public float minimumX;
	public float maximumX;
	
	public float minimumY;
	public float maximumY;

	void Start () 
	{
	
	}
	
	
	void Update () 
	{
		Vector3 pos = transform.position;
		
		float x = pos.x;
		float y = pos.y;
	
		if(pos.x < minimumX)
			x = minimumX;
			
		if(pos.x > maximumX)
			x = maximumX;
			
		if(pos.y < minimumY)
			y = minimumY;
			
		if(pos.y > maximumY)
			y = maximumY;
			
		transform.position = new Vector3(x, y, pos.z);
	}
}
