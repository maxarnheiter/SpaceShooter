using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MusicPlayer : MonoBehaviour 
{
    public float volume;
    public float transitionRate;

    public GameObject primaryObject;
    public GameObject secondaryObject;

    public List<AudioClip> standardClips;
    public List<AudioClip> bossClips;

    AudioClip currentClip;

    public float transitionTime;

    bool playBoss = false;
    bool usePrimary = true;
    bool transitioning = false;

    AudioSource primarySource;
    AudioSource secondarySource;


	void Start () 
    {
        primarySource = primaryObject.GetComponent<AudioSource>();
        secondarySource = secondaryObject.GetComponent<AudioSource>();

        SetRandomClip();

        primarySource.volume = volume;
        secondarySource.volume = 0;
	}
	

	void FixedUpdate () 
    {
        if (!primarySource.isPlaying)
            primarySource.Play();
        if (!secondarySource.isPlaying)
            secondarySource.Play();

        CheckForTimeTransition();

        if (transitioning)
            Transition();
	}

    void BeginTransition()
    {
        transitioning = true;

        usePrimary = !usePrimary;

        SetRandomClip();
    }

    void Transition()
    {
        if(usePrimary)
        {
            primarySource.volume += transitionRate;
            secondarySource.volume -= transitionRate;

            if (primarySource.volume >= volume)
                transitioning = false;
        }
        else
        {
            primarySource.volume -= transitionRate;
            secondarySource.volume += transitionRate;

            if (secondarySource.volume >= volume)
                transitioning = false;
        }
    }

    void CheckForTimeTransition()
    {
        if(usePrimary)
        {
            if (primarySource.time + transitionTime >= currentClip.length)
                BeginTransition();
        }
        else
        {
            if (secondarySource.time + transitionTime >= currentClip.length)
                BeginTransition();
        }
    }

    void SetRandomClip()
    {
        IEnumerable<AudioClip> clips;

        if (!playBoss)
            clips = standardClips.Where(c => c != currentClip);
        else
            clips = bossClips.Where(c => c != currentClip);

        int rand = Random.Range(0, clips.Count());
        currentClip = clips.ElementAt(rand);

        if (usePrimary)
            primarySource.clip = currentClip;
        else
            secondarySource.clip = currentClip;

    }

    public void PlayStandardMusic()
    {
        playBoss = false;
        BeginTransition();
    }

    public void PlayBossMusic()
    {
        playBoss = true;
        BeginTransition();
    }
}
