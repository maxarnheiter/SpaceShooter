using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour 
{

	public float speed;

	public float damage;

    public GameObject explosion;

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
        var targetHealth = collision.gameObject.GetComponent<Health>();

        if(targetHealth != null)
        {
            targetHealth.HitByShot(this, transform.position);
        }

        if(collision.gameObject.name.Contains("Enemy"))
        {
            Explode(transform.position);
        }
    }

    void Explode(Vector3 position)
    {
        GameObject.Instantiate(explosion, position, Quaternion.identity);
        Destroy(gameObject);
    }
}
