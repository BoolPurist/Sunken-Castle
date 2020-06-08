using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Scene must also be added in the build settings for that project.
    public void OnClickChangeScene(string sceneName)
    {
        if (sceneName == null || sceneName == String.Empty)
        {
            Debug.Log("No scene name was provided !");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    // Is used by the pause menu to change into another scene properly. Otherwise the scene change into, is still paused.
    public void OnClickChangeSceneFromPause(string sceneName)
    {
        Time.timeScale = 1f;
        OnClickChangeScene(sceneName);
    }
}
