using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInfo : MonoBehaviour
{
    public Transform portal;
    public Transform levelCenter;
    public LayerMask WhatIsEnemy;
    public LayerMask WhatIsPlayer;
    public Vector2 levelRadius;
    public Vector2 portalRadius;

    public string sceneToLoad;

    private int count = 0;
    private bool isActivated = false;

    // Update is called once per frame
    void Update()
    {
        count = 0;
        if(isActivated == false)
        {
            Collider2D[] EnemyNumber = Physics2D.OverlapBoxAll(levelCenter.position,levelRadius, WhatIsEnemy);
            for(int i = 0;i < EnemyNumber.Length; i++)
            {
                count++;
            }
            if(count == 0)
            {
                Debug.Log("No more enemies present");
                Activate();
            }
            else
            {
                Debug.Log("Enemies still present");
                Debug.Log(count);
            }
        }
        else
        {
            Collider2D[] Player = Physics2D.OverlapBoxAll(portal.position, portalRadius, WhatIsPlayer);
            if(Player != null)
            {
                ChangeLevel();
            }
        }
    }

    void Activate()
    {
        isActivated = true;
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnDrawGizmosSelected() //Visualizes the levelRadius and portalRadius for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(levelCenter.position, (Vector3)levelRadius);
        Gizmos.DrawWireCube(portal.position, (Vector3)portalRadius);
    }
}
