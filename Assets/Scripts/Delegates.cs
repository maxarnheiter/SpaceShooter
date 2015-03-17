using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


//Game State and Mode
public delegate void StartButtonClickedEventHandler();
public delegate void DifficultyButtonClickedEventHandler(DifficultyMode newGameMode);



//Player
public delegate void PlayerHealthChangeEventHandler(float max, float current);
public delegate void PlayerShieldChangeEventHandler(float max, float current);
public delegate void PlayerHitEventHandler(Shot shot);
public delegate void PlayerShieldHitEventHandler(Shot shot);
public delegate void PlayerDeathEventHandler();

public delegate void ScoreChangeEventHandler(float prevoius, float current, float change);
public delegate void MissileCountChangeEventHandler(float previous, float current, float change);

//Enemy
public delegate void EnemyHitEventHandler(GameObject enemyObject, Shot shot);
public delegate void EnemyShieldHitEventHandler(GameObject enemyObject, Shot shot);
public delegate void EnemyDeathEventHandler(GameObject enemyObject);
public delegate void EnemySpawnEventHandler(GameObject enemyObject, Vector3 startPosition);

//Boss
public delegate void BossDeathEventHandler(GameObject bossObject);
public delegate void BossSpawnEventHandler(GameObject bossObject);
public delegate void BossHealthChangeEventHandler(float max, float current);

//Shot
public delegate void ShotCollisionEventHandler(GameObject source, GameObject target, Shot shot);



//Misc
public delegate void FaderFinishedEventHandler();
public delegate void DeathEventHandler(GameObject dyingObject);
public delegate void DeathExplosionEndEventHandler(GameObject explodingObject);
public delegate void LevelLoadedEventHandler();

public delegate void VictoryEventHandler();
public delegate void DefeatEventHandler();







