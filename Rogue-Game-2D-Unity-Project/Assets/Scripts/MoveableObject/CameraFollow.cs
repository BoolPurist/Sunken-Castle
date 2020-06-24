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
    public Transform playerTransform;
    public float verzoegerung = 0.1f;
    [HideInInspector]
    public bool allowToUpdate = true;

    Camera cam;
    BoxCollider2D boxCollider;
    bool vertical = false;
    bool horizontal = false;
    bool once = true; //allows fixPosition only to Update once when collision detected
    UnityEngine.Vector3 fixPosition;


   
    void Start()
    {
        cam = GetComponent<Camera>();
        boxCollider = GetComponent<BoxCollider2D>();
        transform.position = playerTransform.position;        
    }
    void FixedUpdate()
    {
        if (this.playerTransform != null)
        {
            Collider2D[] Borders = Physics2D.OverlapBoxAll(boxCollider.transform.position, boxCollider.size, 0f);
            for (int i = 0; i < Borders.Length; i++)
            {
                if (Borders[i].gameObject.name == "Top" && !(Borders[i].gameObject.name == "Left" || Borders[i].gameObject.name == "Right"))
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = false;
                    }

                    if (playerTransform.position.y < fixPosition.y)
                    {
                        vertical = false; 
                        once = true;
                    }
                    else
                        vertical = true;
                }
                else if (Borders[i].gameObject.name == "Bottom" && !(Borders[i].gameObject.name == "Left" || Borders[i].gameObject.name == "Right"))
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = false;
                    }

                    if (playerTransform.position.y > fixPosition.y)
                    {
                        vertical = false;
                        once = true;
                    }

                    else
                        vertical = true;
                }
                else if (Borders[i].gameObject.name == "Left" && !(Borders[i].gameObject.name == "Top" || Borders[i].gameObject.name == "Bottom"))
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = true;
                    }

                    if (playerTransform.position.x > fixPosition.x)
                    {
                        horizontal = false;
                        once = true;
                    }

                    else
                        horizontal = true;
                }
                else if (Borders[i].gameObject.name == "Right" && !(Borders[i].gameObject.name == "Top" || Borders[i].gameObject.name == "Bottom"))
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = false;
                    }

                    if (playerTransform.position.x < fixPosition.x)
                    {
                        horizontal = false;
                        once = true;
                    }

                    else
                        horizontal = true;

                }
                else if (Borders[i].gameObject.name == "Right" && Borders[i].gameObject.name == "Top")
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = false;
                    }

                    if (playerTransform.position.x < fixPosition.x || playerTransform.position.y < fixPosition.y)
                    {
                        horizontal = false;
                        vertical = false;
                        once = true;
                    }

                    else
                        horizontal = true; vertical = true;

                }
                else if (Borders[i].gameObject.name == "Right" && Borders[i].gameObject.name == "Bottom")
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = false;
                    }

                    if (playerTransform.position.x < fixPosition.x || playerTransform.position.y > fixPosition.y)
                    {
                        horizontal = false;
                        vertical = false;
                        once = true;
                    }

                    else
                        horizontal = true; vertical = true;

                }
                else if (Borders[i].gameObject.name == "Left" && Borders[i].gameObject.name == "Top")
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = false;
                    }

                    if (playerTransform.position.x > fixPosition.x || playerTransform.position.y < fixPosition.y)
                    {
                        horizontal = false;
                        vertical = false;
                        once = true;
                    }

                    else
                        horizontal = true; vertical = true;

                }
                else if (Borders[i].gameObject.name == "Left" && Borders[i].gameObject.name == "Bottom")
                {
                    if (once)
                    {
                        fixPosition = playerTransform.position;
                        once = false;
                    }

                    if (playerTransform.position.x > fixPosition.x || playerTransform.position.y > fixPosition.y)
                    {
                        horizontal = false;
                        vertical = false;
                        once = true;
                    }

                    else
                        horizontal = true; vertical = true;

                }
            }

            if (allowToUpdate)
            {
                
                if (vertical && horizontal)
                {
                    //Camera musn't move!
                }                                
                else if (vertical)
                {
                    float cameraFollowPosition = playerTransform.position.x;
                    UnityEngine.Vector3 cameraMoveDir = (new UnityEngine.Vector3(cameraFollowPosition, transform.position.y, -10) - transform.position).normalized;
                    float distance = UnityEngine.Vector3.Distance(new UnityEngine.Vector3(cameraFollowPosition, transform.position.y, -10), transform.position); //float to increase camera movement the further player is away from camera
                    float cameraMoveSpeed = 2f;
                    transform.position = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
                }
                else if (horizontal)
                {
                    float cameraFollowPosition = playerTransform.position.y;
                    UnityEngine.Vector3 cameraMoveDir = (new UnityEngine.Vector3(transform.position.x, cameraFollowPosition, -10) - transform.position).normalized;
                    float distance = UnityEngine.Vector3.Distance(new UnityEngine.Vector3(transform.position.x, cameraFollowPosition, -10), transform.position); //float to increase camera movement the further player is away from camera
                    float cameraMoveSpeed = 2f;
                    transform.position = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
                }
                else
                {
                    UnityEngine.Vector3 cameraFollowPosition = playerTransform.position;
                    cameraFollowPosition.z = -10;
                    UnityEngine.Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
                    float distance = UnityEngine.Vector3.Distance(cameraFollowPosition, transform.position); //float to increase camera movement the further player is away from camera
                    float cameraMoveSpeed = 2f;
                    transform.position = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
                }
            }

               
        }
       
        
    }
}
