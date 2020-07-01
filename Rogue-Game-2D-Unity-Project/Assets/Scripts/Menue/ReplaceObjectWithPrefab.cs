using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObjectWithPrefab : MonoBehaviour
{
    [Tooltip("Object in scene which needs to be deleted/replaced.")]
    public GameObject toReplaceObject;
    [Tooltip("Object which should be created in a scene.")]
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReplaceObject()
    {
        // First creates the game object based on a provided prefab on the same position of the object to be replaced.
        Instantiate(this.prefab);

        // Remove the object to be replaced.
        Destroy(this.toReplaceObject);


    }
}
