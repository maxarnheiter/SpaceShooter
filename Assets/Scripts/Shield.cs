using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{

	public float amount;
    public float currentAmount;

    public float fadeTime;
    public float collapseTime;

	SpriteRenderer spriteRenderer;

    float currentTransparency;
    float currentScale;

    float lastHitTime;
    float collapseStartTime;
    bool isCollapsing;

	void Start () 
	{
        isCollapsing = false;
        currentTransparency = 0f;
        currentScale = 1f;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, currentTransparency);
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
	}

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
        var now = Time.realtimeSinceStartup;
        var elapsed = now - collapseStartTime;

        if (elapsed >= collapseTime)
            Destroy(gameObject);

        currentScale = 1f - (elapsed / collapseTime);
    }
}
