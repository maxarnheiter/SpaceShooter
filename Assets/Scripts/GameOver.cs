using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour 
{

    public GameObject primaryAudioObject;
    public GameObject secondaryAudioObject;

    public float scoreMoveSpeed;

    SpriteFader spriteFader;
    AudioFader primaryAudioFader;
    AudioFader secondaryAudioFader;

    AudioSource audioSource;

    float startTime;
    bool started;

    GameObject scoreTextObj;
    RectTransform scoreTransform;
    Text scoreText;
    int startFontSize;

	void Start () 
    {
        spriteFader = gameObject.GetComponent<SpriteFader>();
        primaryAudioFader = primaryAudioObject.GetComponent<AudioFader>();
        secondaryAudioFader = secondaryAudioObject.GetComponent<AudioFader>();

        audioSource = gameObject.GetComponent<AudioSource>();

        scoreTextObj = GameObject.Find("Score Text");
        scoreText = scoreTextObj.GetComponent<Text>();
        scoreTransform = scoreTextObj.GetComponent<RectTransform>();
	}
	
    void Update()
    {
        if(started)
        {
            MoveAndScaleScore();
        }
    }

	void FixedUpdate () 
    {
       
	}

    public void Begin()
    {
        startTime = Time.realtimeSinceStartup;

        spriteFader.enabled = true;
        primaryAudioFader.enabled = true;
        secondaryAudioFader.enabled = true;

        audioSource.Play();

        started = true;
    }

    void MoveAndScaleScore()
    {
       //change font size?


        scoreTransform.anchoredPosition = Vector3.MoveTowards(scoreTransform.anchoredPosition, Conf.scoreFinalPos, scoreMoveSpeed);
    }
}
