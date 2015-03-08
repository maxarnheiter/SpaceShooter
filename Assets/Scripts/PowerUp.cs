using UnityEngine;
using System.Collections.Generic;


public class PowerUp : MonoBehaviour 
{

    public float fallSpeed;

    bool destroySelf;
    bool playOnce;

	void Start () 
    {
        rigidbody2D.velocity = new Vector2(0, -1f * fallSpeed);
	}
	

	void Update () 
    {
        if(destroySelf)
        if(!audio.isPlaying)
            GameObject.Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player Ship")
        {
            if (!playOnce)
            {
                playOnce = true;
                audio.Play();
                renderer.enabled = false;

                var playerShoot = collision.gameObject.GetComponent<PlayerShoot>();

                playerShoot.upgradeLevel++;
            }

            destroySelf = true;
        }
    }
}
