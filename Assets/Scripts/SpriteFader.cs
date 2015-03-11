using UnityEngine;
using System.Collections;

public class SpriteFader : MonoBehaviour 
{
        public float fadeRate;
        public event FaderFinishedEventHandler FaderFinished;

        bool fadeIn;
        bool fadeOut;
        bool done;
        bool doOnce;

        SpriteRenderer spriteRenderer;
	
	void Start () 
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer.color.a == 0)
            fadeIn = true;
        if (spriteRenderer.color.a > 0)
            fadeOut = true;
	}
	
	void Update () 
    {
        if (fadeIn)
            FadeIn();
        if (fadeOut)
            FadeOut();

        if (done)
        if (!doOnce)
        {
            doOnce = true;
            FaderFinished();
        }
	}

    void FadeIn()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, spriteRenderer.color.a + fadeRate);

        if (spriteRenderer.color.a >= 1)
            done = true;
    }

    void FadeOut()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, spriteRenderer.color.a - fadeRate);

        if (spriteRenderer.color.a <= 0)
            done = true;
    }
}

