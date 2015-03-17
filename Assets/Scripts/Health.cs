using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour, IAdjustedDifficulty
{

	public float initialHealth;
	public float currentHealth;

    float difficulty = 1f;

    static event DeathEventHandler Death;
    bool doOnce;

	void Start () 
	{
        Death += new DeathEventHandler(GLogic.OnDeath);

        AdjustForDifficulty();

        currentHealth = initialHealth;
	}

    public void AdjustForDifficulty()
    {
        if (GLogic.difficultyMode == DifficultyMode.Easy)
            Easy();
        if (GLogic.difficultyMode == DifficultyMode.Hard)
            Hard();
    }

    public void Easy()
    {
        if(gameObject.tag == Conf.player_tag)
            currentHealth = currentHealth * 1.5f;
        
        if(gameObject.tag == Conf.enemy_tag || gameObject.tag == Conf.boss_tag)
            currentHealth = currentHealth / 1.5f;
        
    }

    public void Hard()
    {
        if (gameObject.tag == Conf.player_tag)
            currentHealth = currentHealth / 1.5f;
        
        if (gameObject.tag == Conf.enemy_tag || gameObject.tag == Conf.boss_tag)
            currentHealth = currentHealth * 1.5f;
        
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
