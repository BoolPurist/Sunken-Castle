using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGameOverScreen : MonoBehaviour
{
    [Header("Other Components")]
    // component that manages a pause menu in spawning and removing.
    [Tooltip("Component for managing the pausing in the game. This way it prevents pausing during game over.")]
    public ManagePauseMenu pauseMenuState;

    [Header("Prefabs")]
    // Prefab that is the menu for the game over overlay.
    [Tooltip("Prefab that makes up the menu which comes up during game over.")]
    public GameObject prefabGameOverScreen;

    // Is used to prevent game over prefab being created more than once.
    private bool hasSpawnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Enables to spawn one game over screen on the death event of the player.
        this.hasSpawnGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CallbackCreateGameOverScreen(object sender, EventArgs e)
    {
        // Checks if the game over screen was already spawned.
        // Otherwise there is a danger of spawning duplicate menus on top of each other.
        if (hasSpawnGameOver == false)
        {
            // Usually a prefab for the game over should be selected in the unity inspector for this component.
            if (prefabGameOverScreen == null)
            {
                Debug.Log("No Prefab was provided for the game over screen !");
            }
            else
            {
                GameObject gameOverScreen = Instantiate(prefabGameOverScreen, this.transform);
                // Deactivates a manager component for a pause menu so pausing during game over is not possible anymore.
                if (pauseMenuState != null)
                {
                    pauseMenuState.enabled = false;
                }
                // Makes sure no duplicate game over screen is spawned.
                hasSpawnGameOver = true;
            }

        }
    }
}
