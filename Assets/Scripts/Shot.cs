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

        Debug.Log("before" + targetPosition);

        Vector2 force = GetNormalizedForce(targetPosition);

        Debug.Log("after" + force);

        shotBody.velocity = new Vector2(force.x * speed, force.y * speed);

	}

    Vector2 GetNormalizedForce(Vector3 targetPosition)
    {
        float x = targetPosition.x;
        float y = targetPosition.y;

        if(Mathf.Abs(x) > 1 || Mathf.Abs(y) > 1)
        {
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                var finalX = 1;

                if (x < 0)
                    finalX *= -1;

                var finalY = Mathf.Abs(y) / Mathf.Abs(x);

                if (y < 0)
                    finalY *= -1;

                x = finalX;
                y = finalY;
            }
            
            if(Mathf.Abs(x) < Mathf.Abs(y))
            {
                var finalY = 1;

                if (y < 0)
                    finalY *= -1;

                var finalX = Mathf.Abs(x) / Mathf.Abs(y);

                if (x < 0)
                    finalX *= -1;

                x = finalX;
                y = finalY;
            }

            if(x == y)
            {
                //TODO
            }
        }

        return new Vector2(x, y);
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
