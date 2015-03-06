using UnityEngine;
using System.Collections;


public class ResourceBar : MonoBehaviour 
{
    public float maxScale;
    public float percentMissing;


	void Start () 
    {
	
	}
	

	void Update () 
    {
        if (percentMissing > 100)
            percentMissing = 100;

        if (percentMissing < 0)
            percentMissing = 0;

        float adjusted = maxScale * (percentMissing / 100);

        transform.localScale = new Vector3(adjusted, transform.localScale.y, transform.localScale.z);
	}
}
