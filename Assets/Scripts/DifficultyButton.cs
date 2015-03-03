using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DifficultyButton : MonoBehaviour 
{
    public Sprite upSprite;
    public Sprite downSprite;

    public GameMode setMode;

    public GameObject buttonText;

    GameInitializer initializer;
    SpriteRenderer spriteRenderer;

    SpriteRenderer buttonRenderer;
	
	void Start () 
    {
        initializer = GameObject.FindObjectOfType<GameInitializer>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        buttonRenderer = buttonText.GetComponent<SpriteRenderer>();
	}
	
	
	void Update () 
    {
        if (initializer.gameMode == setMode)
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
        initializer.gameMode = setMode;
    }

    
}
