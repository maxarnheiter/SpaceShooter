using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{

    public GameObject primaryAudioObject;
    public GameObject secondaryAudioObject;

    SpriteFader spriteFader;
    AudioFader primaryAudioFader;
    AudioFader secondaryAudioFader;

    AudioSource audioSource;

	void Start () 
    {
        spriteFader = gameObject.GetComponent<SpriteFader>();
        primaryAudioFader = primaryAudioObject.GetComponent<AudioFader>();
        secondaryAudioFader = secondaryAudioObject.GetComponent<AudioFader>();

        audioSource = gameObject.GetComponent<AudioSource>();
	}
	

	void FixedUpdate () 
    {
       
	}

    public void Begin()
    {
        spriteFader.enabled = true;
        primaryAudioFader.enabled = true;
        secondaryAudioFader.enabled = true;

        audioSource.Play();
    }
}
