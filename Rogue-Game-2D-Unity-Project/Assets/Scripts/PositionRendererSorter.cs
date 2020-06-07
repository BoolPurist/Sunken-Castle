using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    private Renderer myRender;
    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool updateOnce = false;




    void Awake()
    {
        myRender = GetComponent<Renderer>();

    }

    void LateUpdate()
    {
        myRender.sortingOrder = (int)(sortingOrderBase - (transform.position.y * 100) - offset);

        if(updateOnce)
            Destroy(this);
    }


    
}
