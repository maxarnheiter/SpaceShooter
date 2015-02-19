using UnityEngine;
using System.Collections;

public class BackgroundSlider : MonoBehaviour 
{

	public Vector3 resetPosition;
	public float speed = 1f;

	float pixelToUnit = 24;

	float change;
	float height;
	float resetY;

	void Start () 
	{
		height = gameObject.GetComponent<SpriteRenderer> ().sprite.rect.height / pixelToUnit;
		resetY = resetPosition.y - height;
	}


	void Update () 
	{
		change = speed * Time.deltaTime;

		transform.position = new Vector3 (transform.position.x, transform.position.y - change, transform.position.z);

		if (transform.position.y <= resetY)
			transform.position = resetPosition;
	}
}
