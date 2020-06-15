using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInfo : MonoBehaviour
{
    public Transform portal;
    public LayerMask WhatIsEnemy;
    public LayerMask WhatIsPlayer;
    public Vector2 levelRadius;
    public Vector2 portalRadius;

    private bool isActivated = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated == false)
        {
            Collider2D[] Enemy = Physics2D.OverlapBoxAll(portal.position, levelRadius, WhatIsEnemy);
            if(Enemy[0] == null)
            {
                Activate();
            }
        }
        else
        {
            Collider2D[] Player = Physics2D.OverlapBoxAll(portal.position, portalRadius, WhatIsPlayer);
            if(Player[0] != null)
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

    }

    void OnDrawGizmosSelected() //Visualizes the levelRadius and portalRadius for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(portal.position, (Vector3)levelRadius);
        Gizmos.DrawWireCube(portal.position, (Vector3)portalRadius);
    }
}
