using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour 
{

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    AudioSource audioSource;

    event MainMenuButtonClickedEventHandler MainMenuButtonClicked;

	void Start () 
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        audioSource = gameObject.GetComponent<AudioSource>();

        MainMenuButtonClicked += new MainMenuButtonClickedEventHandler(GLogic.OnMainMenuButtonClicked);
	}


	void Update () 
    {
	    
	}

    public void Enable()
    {
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
    }

    public void Disable()
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
    }
    
    void OnMouseDown()
    {
        audioSource.Play();
        MainMenuButtonClicked();
    }
    
}
