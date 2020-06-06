using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePauseMenu : MonoBehaviour
{
    // Button to toggle between pause and game.
    public KeyCode buttonPause = KeyCode.Space;
    // Prefab that is the menu to interact with when the game is paused.
    public GameObject pauseMenuPrefab;

    private GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        // A prefab that makes up the menu for the pause should be attached through the unity inspector.
        if (pauseMenuPrefab == null)
        {
            Debug.LogError("No Prefab for the pause menu was assigned !");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Nothing happens if no prefab for the pause menu through unity inspector.
        if (pauseMenuPrefab == null)
        {
            return;
        }
        // Toggles between the game and pause when the respective key is pressed.
        else if (Input.GetKeyDown(buttonPause))
        {
            // If no pause menu as an object is stored the game is not paused.
            // Otherwise a object as pause menu was created already and is stored. The game is paused.
            if (pauseMenu == null)
            {
                this.Pause();
            }
            else
            {
                this.Resume();
            }
        }
    }

    // Pausing ends. Game speed is reverted back to normal.
    // Pause menu is destoried.
    public void Resume()
    {

        Time.timeScale = 1f;
        Destroy(pauseMenu);
    }

    // Pausing starts. Game speed is set to zero so every thing stand stills.
    // Pause menu is created.
    private void Pause()
    {
        pauseMenu = Instantiate(pauseMenuPrefab, this.transform);
        Time.timeScale = 0f;
    }


}
