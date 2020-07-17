using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main menu and its sub menus are denamically created and destroyed.
// That leads to incorrectly overlapping of gui elements and background sprites.
// This component fixes that by assigning the component camera to the public field Render Camera 
// and assigning Layer sortingLayer to the sorting layer name.
public class GetCameraComponent : MonoBehaviour
{
    [Tooltip("Tag to find object that is a camera in a scene.")]
    public string tagForCamera;
    [Tooltip("Sorting Layer the canvas component should have.")]
    public string sortingLayer;

    // Start is called before the first frame update
    private void Start()
    {
        // Access canvas component that renders the surface for the gui elements displayed on the camera.
        Canvas canvas = this.GetComponent<Canvas>();

        if (canvas != null)
        {
            // Get the object that has the component camera.
            GameObject cameraObject = GameObject.FindGameObjectWithTag(this.tagForCamera);

            if (cameraObject != null)
            {
                // Get the component camera to manpulate certain pubic fields on this component.
                Camera cameraComponent = cameraObject.GetComponent<Camera>();

                if (cameraComponent != null)
                {
                    // For the Render Camera 
                    canvas.worldCamera = cameraComponent;
                    // For the sorting layer of the canvas.
                    canvas.sortingLayerName = this.sortingLayer;
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
}
