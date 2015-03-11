using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Shot : MonoBehaviour 
{
    public event ShotCollisionEventHandler ShotCollision;

	public float speed;

	public float damage;

    public GameObject explosion;

    public GameObject source;

	public List<string> targetNames;

	void Start () 
	{
        ShotCollision += new ShotCollisionEventHandler(GLogic.OnShotCollision);
	}
	

	void Update () 
	{
	
	}

	public void Shoot(GameObject Source, Vector3 targetPosition)
	{
        source = Source;

		var shotBody = gameObject.GetComponent<Rigidbody2D>();

        Vector2 force = GetNormalizedForce(targetPosition);

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
        ShotCollision(source, collision.gameObject, this);
    }

    public void Explode()
    {
        GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
