using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInfo : MonoBehaviour
{
    public Transform portal;
    public LayerMask WhatIsPlayer;
    public Vector2 portalRadius;

    public string sceneToLoad;

    private int count = 0;
    private bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        if(isActivated == false)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                isActivated = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isActivated)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    void OnDrawGizmosSelected() //Visualizes the levelRadius and portalRadius for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(portal.position, (Vector3)portalRadius);
    }
}
