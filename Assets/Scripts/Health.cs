using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public float initialHealth;
	public float currentHealth;

    float difficulty = 1f;

    static event DeathEventHandler Death;
    bool doOnce;

	void Start () 
	{
        Death += new DeathEventHandler(GLogic.OnDeath);

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

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        if (!doOnce)
        {
            doOnce = true;
            Death(gameObject);
        }
    }
}
