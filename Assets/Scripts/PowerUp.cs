using UnityEngine;
using System.Collections.Generic;


public class PowerUp : MonoBehaviour 
{

    public float fallSpeed;

    bool destroySelf;
    bool playOnce;

	void Start () 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1f * fallSpeed);
	}
	

	void Update () 
    {
        if(destroySelf)
        if(!GetComponent<AudioSource>().isPlaying)
            GameObject.Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == Conf.player_tag)
        {
            if (!playOnce)
            {
                playOnce = true;
                GetComponent<AudioSource>().Play();
                GetComponent<Renderer>().enabled = false;

                //Adjust player shooting behavior
                var playerShoot = collision.gameObject.GetComponent<PlayerShoot>();
                playerShoot.upgradeLevel++;

                //Adjust player movement behavior
                var playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                playerMovement.xAdjust *= 1.1f;
                playerMovement.yAdjust *= 1.1f;
                playerMovement.forwardBoost *= 1.1f;

                
            }

            destroySelf = true;
        }
    }
}
