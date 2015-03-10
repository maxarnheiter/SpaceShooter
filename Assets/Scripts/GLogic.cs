using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public static class GLogic
{

    //Game State and Mode
    static GameState gameState;
    static GameMode gameMode;

    static event GameStateChangeEventHandler GameStateChange;

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


    static void OnGameStateChange(GameState previousState, GameState newState)
    {

    }


    public static void OnShotCollision(GameObject source, GameObject target, float shotDamage)
    {
        if(source.tag == Conf.player_tag)
        {
            if(target.tag == Conf.enemy_tag)
                EnemyHit(shotDamage);
            
            if(target.tag == Conf.enemy_shield_tag)
                EnemyShieldHit(shotDamage);
        }

        if(source.tag == Conf.enemy_tag)
        {
            if(target.tag == Conf.player_tag)
                PlayerHit(shotDamage);
            
            if(target.tag == Conf.player_shield_tag)
                PlayerShieldHit(shotDamage);
        }
    }

    public static void OnPlayerHit(float damage)
    {
        //temp
        playerHealth = GameObject.Find("Player Ship").GetComponent<Health>();

        playerHealth.TakeDamage(damage);

        PlayerHealthChange(playerHealth.initialHealth, playerHealth.currentHealth);
    }

    public static void OnPlayerShieldHit(float damage)
    {
        //temp
        playerShield = GameObject.Find("Player Shield").GetComponent<Shield>();

        playerShield.TakeDamage(damage);

        PlayerShieldChange(playerShield.initialAmount, playerShield.currentAmount);
    }

    public static void OnEnemyHit(float damage)
    {
        Debug.Log("enemy hit");
    }

    public static void OnEnemyShieldHit(float damage)
    {
        Debug.Log("enemy shield hit");
    }
}


