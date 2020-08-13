using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Ending the game does only work in builded version of the game not in the unity editor or debugger.
    public void OnClickEndGame()
    {
        Application.Quit();
    }
}
