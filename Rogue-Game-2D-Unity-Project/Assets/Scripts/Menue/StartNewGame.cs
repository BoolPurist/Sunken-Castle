using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void OnClickStartNewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
