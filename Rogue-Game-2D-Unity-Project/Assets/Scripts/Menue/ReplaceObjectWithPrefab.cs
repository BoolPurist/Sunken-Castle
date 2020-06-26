using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObjectWithPrefab : MonoBehaviour
{
    public GameObject toReplaceObject;

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
