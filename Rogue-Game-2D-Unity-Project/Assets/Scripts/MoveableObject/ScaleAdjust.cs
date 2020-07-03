using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAdjust : MonoBehaviour
{
    private Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
        transform.localScale = new Vector3(3f, 3f, 2.1869f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this);
    }
}
