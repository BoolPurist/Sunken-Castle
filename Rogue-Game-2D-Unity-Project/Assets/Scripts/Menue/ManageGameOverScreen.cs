using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGameOverScreen : MonoBehaviour
{

    public ManagePauseMenu pauseMenuState;
    // Start is called before the first frame update

    public GameObject prefabGameOverScreen;

    // Is used that the game over prefab is not created more than once.
    private bool hasSpawnGameOver;

    void Start()
    {
        this.hasSpawnGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CallbackCreateGameOverScreen(object sender, EventArgs e)
    {
        // Checks if the game over screen was already spawned.
        if (hasSpawnGameOver == false)
        {
            if (prefabGameOverScreen == null)
            {
                Debug.Log("No Prefab was provided for the game over screen !");
            }
            else
            {
                GameObject gameOverScreen = Instantiate(prefabGameOverScreen, this.transform);

                if (pauseMenuState != null)
                {
                    pauseMenuState.enabled = false;
                }

                hasSpawnGameOver = true;
            }

        }
    }
}
