using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour, IAdjustedDifficulty
{

	public float initialAmount;
    public float currentAmount;

    public float fadeTime;
    public float collapseTime;

	SpriteRenderer spriteRenderer;

    float currentTransparency;
    float currentScale;

    float lastHitTime;
    float collapseStartTime;

    float difficulty = 1f;

	void Start () 
	{
        currentTransparency = 0f;
        currentScale = 1f;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, currentTransparency);

        AdjustForDifficulty();

        currentAmount = initialAmount;
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
        if (gameObject.tag == Conf.player_tag)
            currentAmount = currentAmount * 1.5f;

        if (gameObject.tag == Conf.enemy_tag || gameObject.tag == Conf.boss_tag)
            currentAmount = currentAmount / 1.5f;

    }

    public void Hard()
    {
        if (gameObject.tag == Conf.player_tag)
            currentAmount = currentAmount / 1.5f;

        if (gameObject.tag == Conf.enemy_tag || gameObject.tag == Conf.boss_tag)
            currentAmount = currentAmount * 1.5f;

    }
	
	void Update () 
	{
        Fade();
        SetTransparency();
        
	}

    void Fade()
    {
        if (lastHitTime != 0)
        {
            var now = Time.realtimeSinceStartup;
            var elapsed = now - lastHitTime;

            currentTransparency = 1f - (elapsed / fadeTime);
        }
    }

    void SetTransparency()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, currentTransparency);
    }

    public void TakeDamage(float damage)
    {
        currentTransparency = 1f;
        lastHitTime = Time.realtimeSinceStartup;

        currentAmount -= damage;
    }
}
