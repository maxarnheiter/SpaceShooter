using UnityEngine;
using System.Collections;

public class GameInitializer : MonoBehaviour 
{

    public GameMode gameMode;

    AudioSource startAudio;
    AudioSource backgroundAudio;

    SpriteRenderer overlayRenderer;

    public float audioFadeOutRate;
    public float whiteOverlayFadeInRate;

    bool fade;

	void Start () 
    {
        startAudio = gameObject.GetComponent<AudioSource>();
	}
	

	void Update () 
    {
	
	}

    void FixedUpdate()
    {
        if (fade)
            Fade();
    }

    void OnMouseDown()
    {
        fade = true;

        backgroundAudio = GameObject.Find("Start Menu Audio").GetComponent<AudioSource>();
        overlayRenderer = GameObject.Find("White Fade Overlay").GetComponent<SpriteRenderer>();

        startAudio.Play();
    }

    void Fade()
    {
        backgroundAudio.volume -= audioFadeOutRate;

        overlayRenderer.color = new Color(1f, 1f, 1f, overlayRenderer.color.a + whiteOverlayFadeInRate);
    }
}
