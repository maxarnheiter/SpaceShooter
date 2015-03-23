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
    bool doOnce;

    GameObject scoreTextObj;
    RectTransform scoreTransform;
    Text scoreText;
    int startFontSize;

    event ScoreFinishedMovingEventHandler ScoreFinishedMoving;

	void Start () 
    {
        spriteFader = gameObject.GetComponent<SpriteFader>();
        primaryAudioFader = primaryAudioObject.GetComponent<AudioFader>();
        secondaryAudioFader = secondaryAudioObject.GetComponent<AudioFader>();

        audioSource = gameObject.GetComponent<AudioSource>();

        scoreTextObj = GameObject.Find("Score Text");
        scoreText = scoreTextObj.GetComponent<Text>();
        scoreTransform = scoreTextObj.GetComponent<RectTransform>();

        ScoreFinishedMoving += new ScoreFinishedMovingEventHandler(GLogic.OnScoreTextFinishedMoving);
	}
	
    void Update()
    {
        if(started)
        {
            MoveScore();
            CheckScorePosition();
        }
    }

    public void Begin(bool isDefeat)
    {
        startTime = Time.time;

        spriteFader.enabled = true;


        if (isDefeat)
        {
            primaryAudioFader.SetFadeOut();
            secondaryAudioFader.SetFadeOut();

            primaryAudioFader.enabled = true;
            secondaryAudioFader.enabled = true;
            audioSource.Play();
        }

        started = true;
    }

    void MoveScore()
    {
        scoreTransform.anchoredPosition = Vector3.MoveTowards(scoreTransform.anchoredPosition, Conf.scoreFinalPos, scoreMoveSpeed);
    }

    void CheckScorePosition()
    {
        if(!doOnce)
        {
            if(scoreTransform.anchoredPosition.x == Conf.scoreFinalPos.x && scoreTransform.anchoredPosition.y == Conf.scoreFinalPos.y)
            {
                doOnce = true;
                ScoreFinishedMoving();
            }
        }
    }
}
