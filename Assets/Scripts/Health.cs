using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public float initialHealth;
	public float currentHealth;

    float difficulty = 1f;
    ResourceBar resBar;

	void Start () 
	{
        var difficultyComponent = gameObject.GetComponent<DifficultySetting>();

        if (difficultyComponent != null)
            difficulty = difficultyComponent.difficulty;

        resBar = GameObject.Find("Player Health Missing Bar").GetComponent<ResourceBar>();
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
        
        if(gameObject.name == "Player Ship")
            resBar.percentMissing = 100 - ((currentHealth / initialHealth) * 100);   
        
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
