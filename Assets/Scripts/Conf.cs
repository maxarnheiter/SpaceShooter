using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public static class Conf
{
    //tags
    public const string player_tag = "player";
    public const string player_shield_tag = "player shield";
    public const string enemy_tag = "enemy";
    public const string enemy_shield_tag = "enemy shield";
    public const string shot_tag = "shot";
    public const string boss_tag = "boss";
    public const string boss_shield_tag = "boss shield";

    //score
    public static Vector3 scoreFinalPos = new Vector3(6.75f, 45f, 0f);
    public const int scoreFinalFontSize = 40;
}

