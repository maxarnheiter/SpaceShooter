using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{

    public float animationDuration;
    public float fadeDuration;

    float startTime;
    float endTime;
    float endFadeTime;

    SpriteRenderer spriteRenderer;
	
	void Start () 
    {
        startTime = Time.time;
        endTime = startTime + animationDuration;
        endFadeTime = endTime + fadeDuration;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	
	void Update () 
    {
        var now = Time.time;

        if (now >= endTime)
            BeginFade();
        
	}

    void BeginFade()
    {
        var now = Time.time;

        if (now >= endFadeTime)
            Destroy(gameObject);

        var timeSinceEnd = now - endTime;

        var percentElapsed = timeSinceEnd / fadeDuration;

        var fadeAmount = 1f - percentElapsed;

        spriteRenderer.color = new Color(1f, 1f, 1f, fadeAmount);
    }
}
