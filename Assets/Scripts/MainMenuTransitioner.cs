using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuTransitioner : MonoBehaviour 
{
    public float transitionRate;

    public GameObject scoreTextObj;
    public GameObject finalScoreTextObj;

    Text scoreText;
    Text finalScoreText;

    SpriteRenderer spriteRenderer;

    event MainMenuTransitionerCompletedEventHandler MainMenuTransitionerCompleted;

    bool doOnce;

	void Start () 
    {
        MainMenuTransitionerCompleted += new MainMenuTransitionerCompletedEventHandler(GLogic.OnMainMenuTransitionerCompleted);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        scoreText = scoreTextObj.GetComponent<Text>();
        finalScoreText = finalScoreTextObj.GetComponent<Text>();
	}
	

	void FixedUpdate () 
    {
        ChangeColor();
        Check();
	}

    void ChangeColor()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + transitionRate);
        scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, scoreText.color.a - transitionRate);
        finalScoreText.color = new Color(finalScoreText.color.r, finalScoreText.color.g, finalScoreText.color.b, finalScoreText.color.a - transitionRate);
    }

    void Check()
    { 
        if(spriteRenderer.color.a >= 1 && scoreText.color.a <= 0 && finalScoreText.color.a <= 0)
        {
            if(!doOnce)
            {
                doOnce = true;
                MainMenuTransitionerCompleted();
            }
        }
    }

}
