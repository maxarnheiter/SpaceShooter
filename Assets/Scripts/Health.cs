using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public float initialHealth;
	public float currentHealth;

    float difficulty = 1f;

	void Start () 
	{
        var difficultyComponent = gameObject.GetComponent<DifficultySetting>();

        if (difficultyComponent != null)
            difficulty = difficultyComponent.difficulty;
	}

    void AdjustForDifficulty()
    {
        if(gameObject.name.Contains("Player"))
        {
            initialHealth = initialHealth + ((initialHealth * difficulty) - initialHealth);
            currentHealth = currentHealth + ((currentHealth * difficulty) - currentHealth);
        }
        if(gameObject.name.Contains("Enemy"))
        {
            initialHealth *= difficulty;
            currentHealth *= difficulty;
        }
        
    }
	

	void Update () 
	{
        
	}

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }


    //Soon to be deprecated
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
