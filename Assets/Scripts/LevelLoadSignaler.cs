using UnityEngine;
using System.Collections;

public class LevelLoadSignaler : MonoBehaviour 
{

    event LevelLoadedEventHandler LevelLoaded;
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        LevelLoaded += new LevelLoadedEventHandler(GLogic.OnLevelLoaded);
    }

    void OnLevelWasLoaded()
    {
        LevelLoaded();
    }
}
