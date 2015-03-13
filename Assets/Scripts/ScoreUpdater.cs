using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdater : MonoBehaviour 
{

    Text textComponent;

	void Start () 
    {
        textComponent = gameObject.GetComponent<Text>();
	}
	

	void Update () 
    {
        textComponent.text = GLogic.score.ToString();
	}
}
