using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


//Game State and Mode
public delegate void GameStateChangeEventHandler(GameState previousState, GameState newState);



//Player
public delegate void PlayerHealthChangeEventHandler(float max, float current);
public delegate void PlayerShieldChangeEventHandler(float max, float current);
public delegate void PlayerHitEventHandler(float damage);
public delegate void PlayerShieldHitEventHandler(float damage);

public delegate void ScoreChangeEventHandler(float prevoius, float current, float change);
public delegate void MissileCountChangeEventHandler(float previous, float current, float change);

//Enemy
public delegate void EnemyHitEventHandler(float damage);
public delegate void EnemyShieldHitEventHandler(float damage);

//Shot
public delegate void ShotCollisionEventHandler(GameObject source, GameObject target, float shotDamage);









