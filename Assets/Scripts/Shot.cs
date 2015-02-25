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

	}
	

	void Update () 
	{
	
	}

	public void Shoot(Vector3 targetPosition)
	{
		var shotBody = gameObject.GetComponent<Rigidbody2D>();
		shotBody.AddForce(targetPosition * speed, ForceMode2D.Force);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
		if (targetNames.Any (s => s.Contains(collision.gameObject.name))) 
		{
			var targetHealth = collision.gameObject.GetComponent<Health>();

			if(targetHealth != null)
			{
				targetHealth.HitByShot(this, transform.position);
			}

            var targetShield = collision.gameObject.GetComponent<Shield>();

            if(targetShield != null)
            {
                targetShield.HitByShot(this, transform.position);
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
