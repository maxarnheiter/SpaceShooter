﻿using UnityEngine;
using System.Collections;

public class DeathExplosion : MonoBehaviour 
{
    public GameObject explosion;

    public int explosionCount;

    public float explosionDuration;

    float xRange;
    float yRange;

    bool isExploding;

    float startTime;
    float endTime;

    float explosionInterval;
    float lastExplosionTime;

    event DeathExplosionEndEventHandler DeathExplosionEnd;

	void Start () 
    {
        var poly = gameObject.GetComponent<PolygonCollider2D>();

        if(poly != null)
        {
            xRange = poly.bounds.extents.x;
            yRange = poly.bounds.extents.y;
        }

        DeathExplosionEnd += new DeathExplosionEndEventHandler(GLogic.OnDeathExplosionEnd);
	}
	
	void Update () 
    {
	    if(isExploding)
        {
            var now = Time.time;

            if (now >= (lastExplosionTime + explosionInterval))
                DoExplosion();

            if (now >= endTime)
                DeathExplosionEnd(gameObject);
            
        }
	}

    public void Begin()
    {
        if (!isExploding)
        {
            startTime = Time.time;

            endTime = startTime + explosionDuration;

            explosionInterval = explosionDuration / explosionCount;

            lastExplosionTime = startTime - explosionInterval;

            isExploding = true;
        }

    }

    void DoExplosion()
    {
        lastExplosionTime = Time.time;

        var randomX = Random.Range((xRange * -1f), xRange);
        var randomY = Random.Range((yRange * -1f), yRange);

        var explosionPosition = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

        GameObject.Instantiate(explosion, explosionPosition, Quaternion.identity);
    }
}
