using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DifficultyButton : MonoBehaviour 
{
    public Sprite upSprite;
    public Sprite downSprite;

    public DifficultyMode setMode;

    public GameObject buttonText;

    SpriteRenderer spriteRenderer;
    SpriteRenderer buttonRenderer;

    AudioSource audioSource;

    event DifficultyButtonClickedEventHandler DifficultyButtonClicked;
	
	void Start () 
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        buttonRenderer = buttonText.GetComponent<SpriteRenderer>();
        audioSource = gameObject.GetComponent<AudioSource>();

        DifficultyButtonClicked += new DifficultyButtonClickedEventHandler(GLogic.OnDifficultyButtonClicked);
	}
	
	
	void Update () 
    {
        if (GLogic.difficultyMode == setMode)
            SetButton(true);
        else
            SetButton(false);
            
	}

    void SetButton(bool enabled)
    {
        if(enabled)
        {
            spriteRenderer.sprite = downSprite;
            buttonRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            spriteRenderer.sprite = upSprite;
            buttonRenderer.color = Color.white;
        }
    }

    void OnMouseDown()
    {
        if (GLogic.difficultyMode != setMode)
        {
            DifficultyButtonClicked(setMode);
            audioSource.Play();
        }
    }

    
}
