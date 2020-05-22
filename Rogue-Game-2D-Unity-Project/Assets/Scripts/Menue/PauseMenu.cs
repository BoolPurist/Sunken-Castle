using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // PROBLEM: Currently Game can start in PauseMenu, this has to be adressed in the Main Menu script.

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public Scene previousScene;

    // Update is called once per frame
    void Update()
    {
        // Game is paused when ESC get pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Game is resumed
    public void Resume()
    {
        SceneManager.LoadScene(previousScene); //
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Game is paused
    void Pause()
    {
        // Previous Scene is saved
        previousScene = scenename; //
        SceneManager.LoadScene(Pause_Menu_Scene); //
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // The Game shall not be paused when in Main Menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(Main_Menu_Scene);
        // Main Menu Script auch aufrufen?
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}

 