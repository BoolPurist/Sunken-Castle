using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holding all global stats for the player. The stats are accessed from serval instances during the game.
public static class GameStats
{
    public static int currentPlayerHealth = -1;
    // Score for many enemies the player killed.
    public static int score = 0;

}
