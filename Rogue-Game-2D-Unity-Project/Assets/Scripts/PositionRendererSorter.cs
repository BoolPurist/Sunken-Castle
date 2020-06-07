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

    private float timer;
    private float timerMax = 0.1f;



    void Awake()
    {
        myRender = GetComponent<Renderer>();

    }

    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            myRender.sortingOrder = (int)(sortingOrderBase - (transform.position.y * 100) - offset);
            if (updateOnce)
                Destroy(this);
            timer = timerMax;
        }
    }


    
}
