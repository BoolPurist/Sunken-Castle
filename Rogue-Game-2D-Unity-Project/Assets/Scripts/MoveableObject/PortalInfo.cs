using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInfo : MonoBehaviour
{
    public LayerMask WhatIsPlayer;
    public Vector2 portalRadius;

    public string sceneToLoad;

    private int count = 0;
    private bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        this.isActivated = isActivated == false && GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (this.isActivated == true && other.CompareTag("Player") && other.isTrigger == false)
        {
            this.GetComponent<ChooseRandomScene>().ChooseNextRandomScene();
        }
    }

    void OnDrawGizmosSelected() //Visualizes the levelRadius and portalRadius for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.gameObject.transform.position, (Vector3)portalRadius);
    }
}
