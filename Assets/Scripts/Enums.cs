using UnityEngine;
using System.Collections;

public enum GameState
{
    None, 
    StartMenu, 
    Battle, 
    GameOver
}

public enum DifficultyMode
{
    Easy, 
    Normal, 
    Hard, 
    Endless
}

public enum EnemyMovmentMode
{
    Float, 
    Track, 
    Jerk
}

public enum ResourceBarType
{
    PlayerHealth, 
    PlayerShield, 
    BossHealth
}