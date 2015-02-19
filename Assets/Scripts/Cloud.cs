using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour 
{

	public float maxXSpeed;
	public float maxYSpeed;
	
	public float minXSpeed;
	public float minYSpeed;
	
	public float maxTransparency;
	public float minTransparency;
	
	public float destroyX;
	public float destroyY;
	
	float randomXSpeed;
	float randomYSpeed;

	
	void Start () 
	{
		var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		
		var randomTransparency = Random.Range(minTransparency, maxTransparency);
		
		spriteRenderer.color = new Color(1f, 1f, 1f, randomTransparency);
	
		randomXSpeed = Random.Range(maxXSpeed, minXSpeed);
		randomYSpeed = Random.Range(maxYSpeed, minYSpeed);
	}
	
	
	void Update () 
	{
		var pos = transform.position;
		
		var xChange = randomXSpeed * Time.deltaTime;
		var yChange = randomYSpeed * Time.deltaTime;
		
		transform.position = new Vector3(pos.x + xChange, pos.y + yChange, 0f);
		
		if(transform.position.x <= destroyX || transform.position.y <= destroyY)
			DestroySelf();
	}
	
	void DestroySelf()
	{
		DestroyImmediate(this.gameObject);
	}
}
