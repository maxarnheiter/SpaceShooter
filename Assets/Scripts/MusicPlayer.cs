using UnityEngine;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour 
{

    public GameObject primaryObject;
    public GameObject secondaryObject;

    public List<AudioClip> standardClips;

    public List<AudioClip> bossClips;

    public float transitionTime;

    bool playBoss;

    AudioSource primarySource;
    AudioSource secondarySource;


	void Start () 
    {
        primarySource = primaryObject.GetComponent<AudioSource>();
        secondarySource = secondaryObject.GetComponent<AudioSource>();
	}
	

	void Update () 
    {
	
	}

    void Transition()
    {

    }
}
