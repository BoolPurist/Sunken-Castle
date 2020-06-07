using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // PauseMenu ist not active when Level is launched.
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CallbackResumeButton()
    {
        // The parent of the object which is component is attached to is has the component to resume the game properly.
        GameObject playerCamera = this.transform.parent.gameObject;
        // Checks if for some reason the object with this component has not parent.
        if (playerCamera == null)
        {
            Debug.LogError("Pause menu has no parent for some reason. The parent usually a camera of the player then would handle the resuming the game.");
            return;
        }

        // Let the game resume from the pause menu properly.
        playerCamera.GetComponent<ManagePauseMenu>().Resume();
    }

}
