using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Shot : MonoBehaviour 
{

	public float speed;

	public float damage;

    public GameObject explosion;

	public List<string> targetNames;

	void Start () 
	{
		var shotBody = gameObject.GetComponent<Rigidbody2D>();
		shotBody.AddForce(Vector2.up * speed, ForceMode2D.Force);
	}
	

	void Update () 
	{
	
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
		if (targetNames.Any (s => s == collision.gameObject.name)) 
		{
			var targetHealth = collision.gameObject.GetComponent<Health>();

			if(targetHealth != null)
			{
				targetHealth.HitByShot(this, transform.position);
			}

			Explode(transform.position);
		}
    }

    void Explode(Vector3 position)
    {
        GameObject.Instantiate(explosion, position, Quaternion.identity);
        Destroy(gameObject);
    }
}
