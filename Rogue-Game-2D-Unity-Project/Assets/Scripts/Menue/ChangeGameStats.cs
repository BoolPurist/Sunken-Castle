using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows to change global values throughout the scenes for the player.
// All global stat are stored in static class GameStats.
public class ChangeGameStats : MonoBehaviour
{
    // Makes sure the global player stats are as if the game just started.
    public void ResetStatsInGame()
    {
        GameStats.currentPlayerHealth = -1;
        GameStats.score = 0;
    }

}
