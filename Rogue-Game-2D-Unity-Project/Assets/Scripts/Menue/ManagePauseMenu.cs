using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePauseMenu : MonoBehaviour
{
    public KeyCode buttonPause = KeyCode.Space;

    public GameObject pauseMenuPrefab;

    private GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenuPrefab == null)
        {
            Debug.LogError("No Prefab for the pause menu was assigned !");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuPrefab == null)
        {
            return;
        }
        else if (Input.GetKeyDown(buttonPause))
        {
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

    public void Resume()
    {
        Time.timeScale = 1f;
        Destroy(pauseMenu);
    }

    private void Pause()
    {
        pauseMenu = Instantiate(pauseMenuPrefab, this.transform);
        Time.timeScale = 0f;
    }


}
