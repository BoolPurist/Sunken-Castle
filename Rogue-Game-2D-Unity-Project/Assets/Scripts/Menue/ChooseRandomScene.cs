using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomScene : MonoBehaviour
{
    public GameObject prefabSceneWideObject;

    private string prefabSceneWideObjectTag;

    private void Awake()
    {
        // Storing tag assigned to the prefab for later checking if the object already exits.
        this.prefabSceneWideObjectTag = prefabSceneWideObject.tag;
    }
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
        SelectScenes sceneLoader = GameObject.FindGameObjectWithTag(this.prefabSceneWideObjectTag).GetComponent<SelectScenes>();
        if (sceneLoader != null)
        {
            sceneLoader.LoadNextScene();
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
