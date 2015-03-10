using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
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
    bool isCollapsing;

    float difficulty = 1f;

    ResourceBar resBar;

	void Start () 
	{
        isCollapsing = false;
        currentTransparency = 0f;
        currentScale = 1f;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, currentTransparency);

        var difficultyComponent = gameObject.GetComponent<DifficultySetting>();

        if (difficultyComponent != null)
            difficulty = difficultyComponent.difficulty;

        AdjustForDifficulty();

        resBar = GameObject.Find("Player Shield Missing Bar").GetComponent<ResourceBar>();
	}

    void AdjustForDifficulty()
    {
        if(gameObject.name.Contains("Enemy"))
        {
            initialAmount *= difficulty;
            currentAmount *= difficulty;
        }
        if(gameObject.name.Contains("Player"))
        {
            initialAmount = initialAmount + ((initialAmount * difficulty) - initialAmount);
            currentAmount = currentAmount + ((currentAmount * difficulty) - currentAmount);
        }
    }
	
	void Update () 
	{
        if (!isCollapsing)
        {
            Fade();
            SetTransparency();
        }

        if(isCollapsing)
        {
            Collapse();
            SetScale();
        }

        if(gameObject.name == "Player Shield")
            resBar.percentMissing = 100 - ((currentAmount / initialAmount) * 100);
	}

    public void TakeDamage(float damage)
    {
        currentTransparency = 1f;
        lastHitTime = Time.realtimeSinceStartup;

        currentAmount -= damage;

        if (currentAmount <= 0)
        {
            if (!isCollapsing)
            {
                isCollapsing = true;
                SetTransparency();
                collapseStartTime = Time.realtimeSinceStartup;
            }
        }
    }


    //soon to be deprecated
    public void HitByShot(Shot shot, Vector3 position)
    {
        currentTransparency = 1f;
        lastHitTime = Time.realtimeSinceStartup;

        currentAmount -= shot.damage;

        if (currentAmount <= 0)
        {
            if (!isCollapsing)
            {
                isCollapsing = true;
                SetTransparency();
                collapseStartTime = Time.realtimeSinceStartup;
            }
        }
    }

    void SetTransparency()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, currentTransparency);
    }

    void SetScale()
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1f);
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

    void Collapse()
    {
        var polyCollider = gameObject.GetComponent<PolygonCollider2D>();
        polyCollider.enabled = false;

        var now = Time.realtimeSinceStartup;
        var elapsed = now - collapseStartTime;

        if (elapsed >= collapseTime)
            Destroy(gameObject);

        currentScale = 1f - (elapsed / collapseTime);
    }
}
