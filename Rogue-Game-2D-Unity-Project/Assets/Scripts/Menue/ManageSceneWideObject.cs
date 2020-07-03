using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManageSceneWideObject : MonoBehaviour
{
    // Prefab for object which exits through serveral scenes.
    [Tooltip("Prefab as base for the object to exit over serverls scenes.")]
    public GameObject prefabSceneWideObject;

    protected string prefabSceneWideObjectTag;

    protected void Awake()
    {
        // Storing tag assigned to the prefab for later checking if the object already exits.
        this.prefabSceneWideObjectTag = this.prefabSceneWideObject.tag;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Deletes the scene wide object and creates a new one. This way the object is rested.
    public void ResetSceneWideObject()
    {
        this.DeleteSceneWideObject();
        this.Spawn();
    }

    // Creates a scene wide object. It only does so when the object does not exit yet.
    public void SpawnSceneWideObject()
    {
        if (GameObject.FindGameObjectWithTag(this.prefabSceneWideObjectTag) == null)
        {
            this.Spawn();
        }
    }

    private void Spawn()
    {
        GameObject sceneWideObject = Instantiate(this.prefabSceneWideObject);

        // A unique tag must be assigned to the scene wide object.
        if (this.prefabSceneWideObjectTag == "Untagged")
        {
            Debug.LogError("The prefab for the scene wide object is not tagged !");
            return;
        }

        // Storing the tag for finding it later.
        this.prefabSceneWideObjectTag = sceneWideObject.tag;

        // This causes the object to continue to exits throughout the scene.
        DontDestroyOnLoad(sceneWideObject);
    }

    // Deletes the scene wide object if was created.
    private void DeleteSceneWideObject()
    {
        GameObject sceneWideObject = GameObject.FindGameObjectWithTag(prefabSceneWideObjectTag);

        // Only delete it if it exits !
        if (sceneWideObject != null)
        {
            Destroy(sceneWideObject);
        }
    }
}
