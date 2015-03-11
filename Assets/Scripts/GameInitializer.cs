using UnityEngine;
using System.Collections;

public class GameInitializer : MonoBehaviour 
{

        public GameObject audioFaderObject;
        AudioFader audioFader;
        bool audioFaderCompleted;

        public GameObject spriteFaderObject;
        SpriteFader spriteFader;
        bool spriteFadeCompleted;

        AudioSource startAudio;

        event StartButtonClickedEventHandler StartButtonClicked;

	void Start () 
    {
        startAudio = gameObject.GetComponent<AudioSource>();

        spriteFader = spriteFaderObject.GetComponent<SpriteFader>();
        audioFader = audioFaderObject.GetComponent<AudioFader>();

        StartButtonClicked += new StartButtonClickedEventHandler(GLogic.OnStartButtonClicked);
	}


    void OnSpriteFaderFinished()
    {
        spriteFadeCompleted = true;

        if(audioFaderCompleted)
            StartButtonClicked();
    }

    void OnAudioFaderFinished()
    {
        audioFaderCompleted = true;

        if (spriteFadeCompleted)
            StartButtonClicked();
    }

    void OnMouseDown()
    {
        spriteFader.FaderFinished += new FaderFinishedEventHandler(OnSpriteFaderFinished);
        spriteFader.enabled = true;

        audioFader.FaderFinished += new FaderFinishedEventHandler(OnAudioFaderFinished);
        audioFader.enabled = true;

        startAudio.Play();
    }

    
}
