using UnityEngine;
using System.Collections.Generic;

public class ResourceBarAnimator : MonoBehaviour 
{

    public float fadeInterval;
    public float fadeRate;

    public GameObject upperObject;
    public GameObject lowerObject;

    public List<Sprite> sprites;

    SpriteRenderer upperRenderer;
    SpriteRenderer lowerRenderer;

    int index = 0;
    float lastFadeTime;
    float upperAlpha;
	
	void Start () 
    {
        upperRenderer = upperObject.GetComponent<SpriteRenderer>();
        lowerRenderer = lowerObject.GetComponent<SpriteRenderer>();

        upperRenderer.sprite = sprites[index];
        lowerRenderer.sprite = sprites[index + 1];
	}
	
	
	void FixedUpdate () 
    {
        var now = Time.time;
        var elapsed = now - lastFadeTime;

        if (elapsed >= fadeInterval)
        {
            Fade();
            lastFadeTime = now;
        }

        Swap();
	}

    void Fade()
    {
        upperAlpha = upperAlpha - fadeRate;

        if (upperAlpha < 0)
            upperAlpha = 0;

        upperRenderer.color = new Color(1f, 1f, 1f, upperAlpha);
    }
    
    void Swap()
    {
        if(upperAlpha <= 0)
        {
            upperAlpha = 1f;
            
            upperRenderer.sprite = sprites[index % sprites.Count];
            lowerRenderer.sprite = sprites[(index + 1) % sprites.Count];

            upperRenderer.color = new Color(1f, 1f, 1f, 1f);

            index++;


        }
    }
}
