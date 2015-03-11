using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


//Game State and Mode
public delegate void StartButtonClickedEventHandler();
public delegate void DifficultyButtonClickedEventHandler(GameMode newGameMode);



//Player
public delegate void PlayerHealthChangeEventHandler(float max, float current);
public delegate void PlayerShieldChangeEventHandler(float max, float current);
public delegate void PlayerHitEventHandler(Shot shot);
public delegate void PlayerShieldHitEventHandler(Shot shot);

public delegate void ScoreChangeEventHandler(float prevoius, float current, float change);
public delegate void MissileCountChangeEventHandler(float previous, float current, float change);

//Enemy
public delegate void EnemyHitEventHandler(Shot shot);
public delegate void EnemyShieldHitEventHandler(Shot shot);

//Shot
public delegate void ShotCollisionEventHandler(GameObject source, GameObject target, Shot shot);



//Misc
public delegate void FaderFinishedEventHandler();
public delegate void DeathEventHandler(GameObject dyingObject);





