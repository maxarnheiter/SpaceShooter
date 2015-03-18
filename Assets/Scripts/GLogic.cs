using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class GLogic
{

    //Game State and Mode
    public static GameState gameState;
    public static DifficultyMode difficultyMode = DifficultyMode.Normal;

    static event VictoryEventHandler Victory;
    static event DefeatEventHandler Defeat;


    //Player
    static Health playerHealth;
    static Shield playerShield;

    public static bool playerDead;
    public static bool isGameOver;

    public static float score;

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
    public static event BossHealthChangeEventHandler BossHealthChange;

    static GameObject bossHealthBar;

    //Music
    static MusicPlayer musicPlayer;


    
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

        Victory += new VictoryEventHandler(OnVictory);
        Defeat += new DefeatEventHandler(OnDefeat);
    }

    public static void OnLevelLoaded()
    {
        playerHealth = GameObject.FindGameObjectWithTag(Conf.player_tag).GetComponent<Health>();
        playerShield = GameObject.FindGameObjectWithTag(Conf.player_shield_tag).GetComponent<Shield>();

        bossHealthBar = GameObject.Find("Boss Health Bar");
        bossHealthBar.SetActive(false);

        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
    }

    public static void OnStartButtonClicked()
    {
        Application.LoadLevel("battle_backup");
    }

    public static void OnDifficultyButtonClicked(DifficultyMode newGameMode)
    {
        difficultyMode = newGameMode;
    }

    public static void OnShotCollision(GameObject source, GameObject target, Shot shot)
    {
        if (source == null || target == null)
            return;

        if(source.tag == Conf.player_tag)
        {
            if (target.tag == Conf.enemy_shield_tag || target.tag == Conf.boss_shield_tag)
                EnemyShieldHit(target, shot);

            if(target.tag == Conf.enemy_tag || target.tag == Conf.boss_tag)
                EnemyHit(target, shot);
        }

        if(source.tag == Conf.enemy_tag || source.tag == Conf.boss_tag)
        {
            if (target.tag == Conf.player_shield_tag)
                PlayerShieldHit(shot);

            if(target.tag == Conf.player_tag)
                PlayerHit(shot);
        }
    }

    public static void OnPlayerHit(Shot shot)
    {
        if (!playerDead && !isGameOver)
        {
            playerHealth.TakeDamage(shot.damage);

            shot.Explode();

            PlayerHealthChange(playerHealth.initialHealth, playerHealth.currentHealth);
        }
    }

    public static void OnPlayerShieldHit(Shot shot)
    {
        if (!playerDead && !isGameOver)
        {
            //If the player shield is depleted, ignore the collision and let it pass through to hit the player
            if (playerShield.currentAmount <= 0)
                return;

            playerShield.TakeDamage(shot.damage);

            shot.Explode();

            PlayerShieldChange(playerShield.initialAmount, playerShield.currentAmount);
        }
    }

    public static void OnEnemySpawn(GameObject enemy, Vector3 startPosition)
    {
        if (enemy.tag == Conf.boss_tag)
            BossSpawn(enemy);

        enemy.GetComponent<EnemyMovement>().SetStartPosition(startPosition);
    }

    public static void OnBossSpawn(GameObject boss)
    {
        bossHealthBar.SetActive(true);

        musicPlayer.PlayBossMusic();
    }

    public static void OnEnemyHit(GameObject enemy, Shot shot)
    {
        var enemyHealth = enemy.GetComponent<Health>();

        enemyHealth.TakeDamage(shot.damage);

        if(!isGameOver)
            score += enemy.GetComponent<Points>().hitValue;

        if (enemy.gameObject.tag == Conf.boss_tag)
            BossHealthChange(enemyHealth.initialHealth, enemyHealth.currentHealth);

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

        if (enemyShield.currentAmount <= 0)
            return;

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

        Defeat();
    }

    static void OnEnemyDeath(GameObject enemy)
    {
        if (!isGameOver)
            score += enemy.GetComponent<Points>().deathValue;

        if (enemy.tag == Conf.boss_tag)
            BossDeath(enemy);
    }

    static void OnBossDeath(GameObject boss)
    {
        var bossHealth = boss.GetComponent<Health>();
        BossHealthChange(bossHealth.initialHealth, bossHealth.initialHealth);

        bossHealthBar.SetActive(false);


        if(difficultyMode != DifficultyMode.Endless)
        {
            musicPlayer.TurnOff();
            Victory();
        }

        musicPlayer.PlayStandardMusic();
    }

    static void OnVictory()
    {
        isGameOver = true;

        var gameOverScript = GameObject.FindObjectOfType<GameOver>();

        gameOverScript.Begin(false);
    }

    static void OnDefeat()
    {
        isGameOver = true;

        var gameOverScript = GameObject.FindObjectOfType<GameOver>();

        gameOverScript.Begin(true);
    }

    public static void OnMusicPlayerOff()
    {
        var victory_player = Resources.Load("victory_audio_player") as GameObject;
        GameObject.Instantiate(victory_player);
    }

    public static void OnScoreTextFinishedMoving()
    {
        var finalScoreText = GameObject.Find("Final Score Text").GetComponent<Text>();

        finalScoreText.enabled = true;
    }
}


