using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float verzoegerung = 0.1f;
    [HideInInspector]
    public bool allowToUpdate = true;

    Camera cam;
   
    void Start()
    {
        cam = GetComponent<Camera>();
        transform.position = playerTransform.position;       
    }
    void Update()
    {
        if (this.playerTransform != null)
        {
            if (allowToUpdate)
            {
                Vector3 cameraFollowPosition = playerTransform.position;
                cameraFollowPosition.z = -10;
                Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
                float distance = Vector3.Distance(cameraFollowPosition, transform.position); //float to increase camera movement the further player is away from camera
                float cameraMoveSpeed = 2f;

                transform.position = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
            }
        }
       
        
    }
}
