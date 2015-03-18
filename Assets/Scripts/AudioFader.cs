using UnityEngine;
using System.Collections;

public class AudioFader : MonoBehaviour
{
    public float fadeRate;
    public event FaderFinishedEventHandler FaderFinished;

    bool fadeIn;
    bool fadeOut;
    bool done;
    bool doOnce;

    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource.volume == 0)
            fadeIn = true;
        if (audioSource.volume > 0)
            fadeOut = true;
    }

    void Update()
    {
        if (fadeIn)
            FadeIn();
        if (fadeOut)
            FadeOut();

        if (done)
            if (!doOnce)
            {
                doOnce = true;
                if(FaderFinished != null)
                    FaderFinished();
            }
    }

    void FadeIn()
    {
        audioSource.volume += fadeRate;

        if (audioSource.volume >= 0)
            done = true;
    }

    void FadeOut()
    {
        audioSource.volume -= fadeRate;

        if (audioSource.volume <= 0)
            done = true;
    }

    public void SetFadeOut()
    {
        fadeOut = true;
    }
}

