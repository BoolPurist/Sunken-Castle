using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScenes : MonoBehaviour
{
    // Scene that should not be selected randomly like a scene as main have an index smaller than the start index.
    public int startIndexScene = 1;

    // Contains all indexes of scenes in the building settings that are meant to be chosen randomly. 
    private int[] sceneIndexes;

    // Indexes of scenes left to be able to be selected randomly until next Reset.
    private List<int> sceneIndexesLeft;

    private void Awake()
    {
        // Check for preventing Out of bound exception because of too high start index.
        if (startIndexScene > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError("Start index is greater than the last index of scenes in the building settings.");
            return;
        }

        // Getting all indexes for scenes meant to be selected randomly.
        this.sceneIndexes = new int[SceneManager.sceneCountInBuildSettings - this.startIndexScene];
        for (int i = this.startIndexScene, j = 0; i < SceneManager.sceneCountInBuildSettings; i++, j++)
        {
            this.sceneIndexes[j] = i;
        }

        // Start a new fresh list of index for a scene to choose from.
        this.ResetScenePool();
        this.LoadNextScene();

    }

    // Start is called before the first frame update
    private void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    // Reseting list of indexes of scene meant to be selected randomly.
    private void ResetScenePool()
    {

        this.sceneIndexesLeft = new List<int>();

        foreach (int index in this.sceneIndexes)
        {
            this.sceneIndexesLeft.Add(index);
        }

        int indexCount = this.sceneIndexesLeft.Count;

        // Current scene should not be picked again for the next scene.
        // Check for only main menu is accessible to player. indexCount == 0 ?
        // Check for only main menu and one scene is accessible to the player. indexCount == 1 ?  
        if (indexCount != 0 && indexCount != 1)
        {
            this.sceneIndexesLeft.Remove(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public void LoadNextScene()
    {
        // Check if the list of left scenes to select from is empty.
        // If true, perform a reset of the list.
        if (this.sceneIndexesLeft.Count <= 0)
        {
            this.ResetScenePool();
        }

        // Choose a left scene of the pool and load that scene.
        System.Random randomGenerator = new System.Random();

        int indexForNextScene = randomGenerator.Next(0, this.sceneIndexesLeft.Count);
        indexForNextScene = this.sceneIndexesLeft[indexForNextScene];

        // The selected scene which is loaded is removed from the list of left scenes.
        // This way the selected scene can only be loaded after the next reset of the level pool.
        this.sceneIndexesLeft.Remove(indexForNextScene);

        SceneManager.LoadScene(indexForNextScene);

    }
}
