using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomScene : ManageSceneWideObject
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Chooses the next left random level.
    public void ChooseNextRandomScene()
    {
        // Accessing the loader for selecting a random scene.
        GameObject sceneLoader = GameObject.FindGameObjectWithTag(base.prefabSceneWideObjectTag);
        if (sceneLoader != null)
        {
            SelectScenes selectScenes = sceneLoader.GetComponent<SelectScenes>();

            if (selectScenes != null)
            {
                selectScenes.LoadNextScene();
            }
            else
            {
                Debug.LogWarning($"The object with tag \"{base.prefabSceneWideObjectTag}\" has no component \"SelectScenes\" ");
            }
        }
        else
        {
            base.ResetSceneWideObject();
        }
    }

    // Choosing a random scene from pause menu. So the new loaded scene is not paused.
    public void ChooseNextRandomSceneFromPause()
    {
        // Stoping pausing the game.
        Time.timeScale = 1f;
        this.ChooseNextRandomScene();

    }
}
