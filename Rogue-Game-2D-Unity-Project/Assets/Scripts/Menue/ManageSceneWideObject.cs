using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSceneWideObject : MonoBehaviour
{
    public GameObject prefabSceneWideObject;

    private string prefabSceneWideObjectTag;

    private void Awake()
    {
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

    public void SpawnSceneWideObject()
    {
        if (GameObject.FindGameObjectWithTag(this.prefabSceneWideObjectTag) == null)
        {
            GameObject sceneWideObject = Instantiate(this.prefabSceneWideObject);

            if (this.prefabSceneWideObjectTag == "Untagged")
            {
                Debug.LogError("The prefab for the scene wide object is not tagged !");
                return;
            }

            this.prefabSceneWideObjectTag = sceneWideObject.tag;

            // This causes the object to continue to exits throughout the scene.
            DontDestroyOnLoad(sceneWideObject);
        }
    }

    public void DeleteSceneWideObject()
    {
        GameObject sceneWideObject = GameObject.FindGameObjectWithTag(prefabSceneWideObjectTag);

        if (sceneWideObject != null)
        {
            Destroy(sceneWideObject);
        }
    }
}
