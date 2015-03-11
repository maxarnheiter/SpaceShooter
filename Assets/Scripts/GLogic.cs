using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GLogic
{

    //Game State and Mode
    public static GameState gameState;
    public static GameMode gameMode;

    


    //Player
    static Health playerHealth;
    static Shield playerShield;

    static float score;
    static float missileCount;

    public static event ScoreChangeEventHandler ScoreChange;
    public static event MissileCountChangeEventHandler MissileCountChange;

    public static event PlayerHealthChangeEventHandler PlayerHealthChange;
    public static event PlayerShieldChangeEventHandler PlayerShieldChange;

    static event PlayerHitEventHandler PlayerHit;
    static event PlayerShieldHitEventHandler PlayerShieldHit;

    //Enemy
    static event EnemyHitEventHandler EnemyHit;
    static event EnemyShieldHitEventHandler EnemyShieldHit;


    
    static GLogic()
    {
        EnemyHit += new EnemyHitEventHandler(OnEnemyHit);
        EnemyShieldHit += new EnemyShieldHitEventHandler(OnEnemyShieldHit);
        PlayerHit += new PlayerHitEventHandler(OnPlayerHit);
        PlayerShieldHit += new PlayerShieldHitEventHandler(OnPlayerShieldHit);
    }

    public static void OnStartButtonClicked()
    {
        //temp
        Application.LoadLevel("battle");
    }

    public static void OnDifficultyButtonClicked(GameMode newGameMode)
    {
        gameMode = newGameMode;
    }

    public static void OnShotCollision(GameObject source, GameObject target, Shot shot)
    {
        if(source.tag == Conf.player_tag)
        {
            if(target.tag == Conf.enemy_tag)
                EnemyHit(shot);
            
            if(target.tag == Conf.enemy_shield_tag)
                EnemyShieldHit(shot);
        }

        if(source.tag == Conf.enemy_tag)
        {
            if(target.tag == Conf.player_tag)
                PlayerHit(shot);
            
            if(target.tag == Conf.player_shield_tag)
                PlayerShieldHit(shot);
        }
    }

    public static void OnPlayerHit(Shot shot)
    {
        //temp
        playerHealth = GameObject.Find("Player Ship").GetComponent<Health>();

        playerHealth.TakeDamage(shot.damage);

        shot.Explode();

        PlayerHealthChange(playerHealth.initialHealth, playerHealth.currentHealth);
    }

    public static void OnPlayerShieldHit(Shot shot)
    {
        //temp
        playerShield = GameObject.Find("Player Shield").GetComponent<Shield>();

        playerShield.TakeDamage(shot.damage);

        shot.Explode();

        PlayerShieldChange(playerShield.initialAmount, playerShield.currentAmount);
    }

    public static void OnEnemyHit(Shot shot)
    {
        Debug.Log("enemy hit");
    }

    public static void OnEnemyShieldHit(Shot shot)
    {
        Debug.Log("enemy shield hit");
    }

    public static void OnDeath(GameObject dyingObject)
    {
        if(dyingObject.tag == Conf.enemy_tag)
        {
            //do enemy death event
        }

        if(dyingObject.tag == Conf.player_tag)
        {
            // do player death event
        }
    }
}


