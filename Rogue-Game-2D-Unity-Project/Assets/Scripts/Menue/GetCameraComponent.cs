using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCameraComponent : MonoBehaviour
{
    [Tooltip("Tag to find object that is a camera in a scene.")]
    public string tagForCamera;
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = this.GetComponent<Canvas>();

        if (canvas != null)
        {
            GameObject cameraObject = GameObject.FindGameObjectWithTag(this.tagForCamera);

            if (cameraObject != null)
            {
                Camera cameraComponent = cameraObject.GetComponent<Camera>();

                if (cameraComponent != null)
                {
                    canvas.worldCamera = cameraComponent;
                }
                else
                {
                    Debug.LogWarning($"The found camera object has no component camera !");
                }
            }
            else
            {
                Debug.LogWarning($"The tag for {this.tagForCamera} an object the the camera component could not be found !");
            }
        }
        else
        {
            Debug.LogWarning($"GetCameraComponent can not work because it is attached to a object with component canvas ! ");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
