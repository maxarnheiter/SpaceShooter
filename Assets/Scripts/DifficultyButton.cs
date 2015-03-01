using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DifficultyButton : MonoBehaviour 
{
    public Sprite upSprite;
    public Sprite downSprite;

    public GameMode setMode;

    GameInitializer initializer;
    SpriteRenderer spriteRenderer;
	
	void Start () 
    {
        initializer = GameObject.FindObjectOfType<GameInitializer>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	
	void Update () 
    {
        if (initializer.gameMode == setMode)
            spriteRenderer.sprite = downSprite;
        else
            spriteRenderer.sprite = upSprite;
	}

    void OnMouseDown()
    {
        initializer.gameMode = setMode;
    }

    
}
