using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour 
{

    public float fadeRate;

    SpriteRenderer spriteRenderer;

    bool start;

	void Start () 
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	

	void FixedUpdate () 
    {
        if(start)
           spriteRenderer.color = new Color(1f, 1f, 1f, spriteRenderer.color.a + fadeRate);
	}

    public void Begin()
    {
        start = true;
    }
}
