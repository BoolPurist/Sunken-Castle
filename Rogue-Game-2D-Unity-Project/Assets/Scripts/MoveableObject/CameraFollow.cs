using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    public float verzoegerung = 0.1f;
    [HideInInspector]
    public bool allowToUpdate = true;




    private void Start()
    {
        this.playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (this.playerTransform != null)
        {
            this.transform.position = this.playerTransform.position;
        }
    }

    private void FixedUpdate()
    {
        if (this.playerTransform != null)
        {
            if (this.allowToUpdate)
            {

                UnityEngine.Vector3 cameraFollowPosition = this.playerTransform.position; 
                //Position which Camera has to Follow
                cameraFollowPosition.z = -10;
                UnityEngine.Vector3 cameraMoveDir = (cameraFollowPosition - this.transform.position).normalized; 
                //Direction in which Camera has to move
                float distance = UnityEngine.Vector3.Distance(cameraFollowPosition, transform.position); 
                //float to increase camera movement the further player is away from camera
                float cameraMoveSpeed = 2f;
                this.transform.position = this.transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime; 
                //Term to calculate new CameraPostion

            }


        }


    }
}
