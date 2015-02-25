using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public float initialHealth;
	public float currentHealth;

	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}

    public void HitByShot(Shot shot, Vector3 position)
    {
        currentHealth -= shot.damage;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        var deathExplosion = gameObject.GetComponent<DeathExplosion>();

        if (deathExplosion != null) 
		{
			deathExplosion.Begin ();
		} 

    }
}
