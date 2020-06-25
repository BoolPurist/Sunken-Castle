using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScenes : MonoBehaviour
{
    public int startIndexScene = 1;

    private int[] sceneIndexes;

    private List<int> sceneIndexesLeft;

    private void Awake()
    {
        if (startIndexScene > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError("Start index is greater than the last index of scenes in the building settings.");
            return;
        }

        this.sceneIndexes = new int[SceneManager.sceneCountInBuildSettings - this.startIndexScene];
        for (int i = this.startIndexScene, j = 0; i < SceneManager.sceneCountInBuildSettings; i++, j++)
        {
            this.sceneIndexes[j] = i;
        }

        this.ResetScenePool();
        this.LoadNextScene();

    }

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ResetScenePool()
    {
        Debug.Log("Reseting.");
        this.sceneIndexesLeft = new List<int>();

        foreach (int index in this.sceneIndexes)
        {
            this.sceneIndexesLeft.Add(index);
        }
    }


    public void LoadNextScene()
    {
        if (this.sceneIndexesLeft.Count <= 0)
        {
            this.ResetScenePool();
        }


        System.Random randomGenerator = new System.Random();

        int indexForNextScene = randomGenerator.Next(0, this.sceneIndexesLeft.Count);
        indexForNextScene = this.sceneIndexesLeft[indexForNextScene];

        this.sceneIndexesLeft.Remove(indexForNextScene);

        SceneManager.LoadScene(indexForNextScene);

    }
}
