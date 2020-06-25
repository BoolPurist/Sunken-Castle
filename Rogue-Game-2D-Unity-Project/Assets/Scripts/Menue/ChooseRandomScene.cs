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

    public void ChooseNextRandomScene()
    {
        SelectScenes sceneLoader = GameObject.FindGameObjectWithTag(this.prefabSceneWideObjectTag).GetComponent<SelectScenes>();
        if (sceneLoader != null)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void ChooseNextRandomSceneFromPause()
    {
        Time.timeScale = 1f;
        this.ChooseNextRandomScene();

    }
}
