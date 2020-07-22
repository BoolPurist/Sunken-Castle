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



    private void Awake()
    {
        this.myRender = this.GetComponent<Renderer>();

    }

    private void LateUpdate()
    {
        this.timer -= Time.deltaTime;
        if (this.timer <= 0f)
        {
            this.myRender.sortingOrder = (int)(this.sortingOrderBase - (this.transform.position.y * 100) - this.offset);

            if (this.updateOnce)
            {
                Destroy(this);
            }

            this.timer = this.timerMax;
        }
    }



}
