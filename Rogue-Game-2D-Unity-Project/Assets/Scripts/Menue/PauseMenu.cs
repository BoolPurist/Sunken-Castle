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
        GameObject playerCamera = this.transform.parent.gameObject;
        if (playerCamera == null)
        {
            Debug.LogError("Pause menu has no parent for some reason. The parent usually a camera of the player then would handle the resuming the game.");
            return;
        }

        playerCamera.GetComponent<ManagePauseMenu>().Resume();
    }

}
