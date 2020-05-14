using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    // Scene must also be added in the build settings for that project.
    public void OnClickStartNewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
