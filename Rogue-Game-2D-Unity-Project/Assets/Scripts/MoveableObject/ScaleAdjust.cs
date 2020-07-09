using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAdjust : MonoBehaviour
{
    private Transform transform;
    private void Start()
    {
        transform = GetComponent<Transform>();
        transform.localScale = new Vector3(3f, 3f, 2.1869f);
    }

    // Update is called once per frame
    private void Update()
    {
        Destroy(this);
    }
}
