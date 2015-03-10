using UnityEngine;
using System.Collections;


public class ResourceBar : MonoBehaviour 
{
    public float maxScale;
    public float percentMissing = 0f;

    public ResourceBarType barType;


	void Start () 
    {
	    switch(barType)
        {
            case ResourceBarType.PlayerHealth:
                GLogic.PlayerHealthChange += new PlayerHealthChangeEventHandler(OnResourceChange);
            break;
            case ResourceBarType.PlayerShield:
                GLogic.PlayerShieldChange += new PlayerShieldChangeEventHandler(OnResourceChange);
            break;
            case ResourceBarType.BossHealth:
                
            break;
        }
	}
	

	void Update () 
    {
        float adjusted = maxScale * (percentMissing / 100f);

        if (adjusted < 0f)
            adjusted = 0f;

        if (adjusted > maxScale)
            adjusted = maxScale;

        transform.localScale = new Vector3(adjusted, transform.localScale.y, transform.localScale.z);
	}

    void OnResourceChange(float max, float current)
    {
        percentMissing = 100 - ((current / max) * 100);

        if (percentMissing > 100)
            percentMissing = 100;

        if (percentMissing < 0)
            percentMissing = 0;
    }
}
