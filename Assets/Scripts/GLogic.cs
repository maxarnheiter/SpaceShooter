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

    public static bool playerDead;

    public static float score;
    public static float missileCount;

    public static event ScoreChangeEventHandler ScoreChange;
    public static event MissileCountChangeEventHandler MissileCountChange;

    public static event PlayerHealthChangeEventHandler PlayerHealthChange;
    public static event PlayerShieldChangeEventHandler PlayerShieldChange;

    static event PlayerHitEventHandler PlayerHit;
    static event PlayerShieldHitEventHandler PlayerShieldHit;
    static event PlayerDeathEventHandler PlayerDeath;

    //Enemy
    static event EnemyHitEventHandler EnemyHit;
    static event EnemyShieldHitEventHandler EnemyShieldHit;
    static event EnemyDeathEventHandler EnemyDeath;

    //Boss
    static event BossDeathEventHandler BossDeath;
    static event BossSpawnEventHandler BossSpawn;


    
    static GLogic()
    {
        EnemyHit += new EnemyHitEventHandler(OnEnemyHit);
        EnemyShieldHit += new EnemyShieldHitEventHandler(OnEnemyShieldHit);
        EnemyDeath += new EnemyDeathEventHandler(OnEnemyDeath);

        BossDeath += new BossDeathEventHandler(OnBossDeath);
        BossSpawn += new BossSpawnEventHandler(OnBossSpawn);

        PlayerHit += new PlayerHitEventHandler(OnPlayerHit);
        PlayerShieldHit += new PlayerShieldHitEventHandler(OnPlayerShieldHit);
        PlayerDeath += new PlayerDeathEventHandler(OnPlayerDeath);

    }

    public static void OnLevelLoaded()
    {
        playerHealth = GameObject.FindGameObjectWithTag(Conf.player_tag).GetComponent<Health>();
        playerShield = GameObject.FindGameObjectWithTag(Conf.player_shield_tag).GetComponent<Shield>();
    }

    public static void OnStartButtonClicked()
    {
        Application.LoadLevel("battle_backup");
    }

    public static void OnDifficultyButtonClicked(GameMode newGameMode)
    {
        gameMode = newGameMode;
    }

    public static void OnShotCollision(GameObject source, GameObject target, Shot shot)
    {
        if (source == null || target == null)
            return;

        if(source.tag == Conf.player_tag)
        {
            if(target.tag == Conf.enemy_tag)
                EnemyHit(target, shot);
            
            if(target.tag == Conf.enemy_shield_tag)
                EnemyShieldHit(target, shot);
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
        if (!playerDead)
        {
            playerHealth.TakeDamage(shot.damage);

            shot.Explode();

            PlayerHealthChange(playerHealth.initialHealth, playerHealth.currentHealth);
        }
    }

    public static void OnPlayerShieldHit(Shot shot)
    {
        if (!playerDead)
        {
            playerShield.TakeDamage(shot.damage);

            shot.Explode();

            PlayerShieldChange(playerShield.initialAmount, playerShield.currentAmount);
        }
    }

    public static void OnEnemySpawn(GameObject enemy)
    {
        if (enemy.tag == Conf.boss_tag)
            BossSpawn(enemy);
    }

    public static void OnBossSpawn(GameObject boss)
    {

    }

    public static void OnEnemyHit(GameObject enemy, Shot shot)
    {
        var enemyHealth = enemy.GetComponent<Health>();

        enemyHealth.TakeDamage(shot.damage);

        score += enemy.GetComponent<Points>().hitValue;

        shot.Explode();
    }

    public static void OnDeathExplosionEnd(GameObject explodingObject)
    {
        if (explodingObject.tag == Conf.enemy_tag || explodingObject.tag == Conf.boss_tag)
            GameObject.Destroy(explodingObject);

        if (explodingObject.tag == Conf.player_tag)
        {
            explodingObject.GetComponent<DeathExplosion>().enabled = false;
        }
    }

    public static void OnEnemyShieldHit(GameObject shieldObject, Shot shot)
    {
        var enemyShield = shieldObject.GetComponent<Shield>();

        enemyShield.TakeDamage(shot.damage);

        shot.Explode();
    }

    public static void OnDeath(GameObject dyingObject)
    {
        if(dyingObject.tag == Conf.enemy_tag || dyingObject.tag == Conf.boss_tag)
            EnemyDeath(dyingObject);
        
        if(dyingObject.tag == Conf.player_tag)
            PlayerDeath();

        var deathExplosionComponent = dyingObject.GetComponent<DeathExplosion>();
        deathExplosionComponent.Begin();
        
    }

    static void OnPlayerDeath()
    {
        playerDead = true;

        var gameOverScript = GameObject.FindObjectOfType<GameOver>();

        gameOverScript.Begin();
    }

    static void OnEnemyDeath(GameObject enemy)
    {
        score += enemy.GetComponent<Points>().deathValue;

        if (enemy.tag == Conf.boss_tag)
            BossDeath(enemy);
    }

    static void OnBossDeath(GameObject boss)
    {
        //do specific boss death stuff
    }


}


