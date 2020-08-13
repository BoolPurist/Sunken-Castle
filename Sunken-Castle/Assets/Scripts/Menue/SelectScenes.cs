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

    private int completedLevels = 0;

    public int CompletedLevels
    {
        get => this.completedLevels;
    }

    private void Awake()
    {
        // Check for preventing Out of bound exception because of too high start index.
        if (this.startIndexScene > SceneManager.sceneCountInBuildSettings - 1)
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

        // Start a new fresh list of index for a scene to choose from randomly.
        this.ResetScenePool();

        // LoadNextScene will load next random scene and increment the count of completed scenes.
        // Depending if the first scene played is the main menu or a chosen scene started from the debugger in unity.
        // The start value for the count of completed levels must set accordingly. 
        // If the buildIndex is zero than the next scene is chosen from the main menu. 
        // In that case the player did not complete a level so far ! So enemy don't get stronger in the first level already.
        // If buildIndex is not zero first Level was started in the debugger from unity.
        // In that case the enemy should become stronger in the next level.
        this.completedLevels = SceneManager.GetActiveScene().buildIndex == 0 ? -1 : 0;

        this.LoadNextScene();
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
        // Check for only main menu is accessible to player. indexCount == 0 and
        // Check for only main menu and one scene is accessible to the player. indexCount == 1 ?  
        if (indexCount != 0 && indexCount != 1)
        {
            // Making sure that after reset of scene pool to choose from, not the current scene is chosen for the first pick to load a scene. 
            this.sceneIndexesLeft.Remove(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public void LoadNextScene()
    {
        this.completedLevels++;

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
