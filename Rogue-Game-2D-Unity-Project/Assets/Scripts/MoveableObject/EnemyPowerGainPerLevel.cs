using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPowerGainPerLevel : MonoBehaviour
{
    [Tooltip("Enemies gains amount of life and damage for each completed level based on the number.")]
    [Range(0f, 1f)]
    public float powerGainPerLeveCompleted;

    [Tooltip("Tag of scene wide object for holding number of completed levels.")]
    public string tagForObjectWithCompleted = "";

    protected int completedLevels;

    // Start is called before the first frame update
    protected void Start()
    {
        if (this.tagForObjectWithCompleted != "")
        {
            GameObject objectWithCompletedLevels = GameObject.FindGameObjectWithTag(this.tagForObjectWithCompleted);

            if (objectWithCompletedLevels != null)
            {
                SelectScenes componentSelectScenes = objectWithCompletedLevels.GetComponent<SelectScenes>();

                if (componentSelectScenes != null)
                {
                    this.completedLevels = componentSelectScenes.CompletedLevels;
                }
                else
                {
                    Debug.LogWarning($"Component SeclectScene is not attached to the  object supposed to hold the number of completed level !");
                }
            }
            else
            {
                Debug.LogWarning($"Object with the tag {this.tagForObjectWithCompleted} for holding the progress made by player was not found !");
            }
        }
        else
        {
            Debug.LogWarning($"this.tagForObjectWithCompleted is not set");
        }

    }

    // Update is called once per frame
    protected void Update()
    {

    }

    // Getter for the percentage as power gain on base of completed levels so far. 
    private float TotalPowerGainThroughCompletedLevels
    {
        get => this.completedLevels * this.powerGainPerLeveCompleted;
    }

    // Returns a whole number as a result  referenceStat + precentage as power gain of referenceStat 
    protected int WholeNumberStatFromPowerGain(int referenceStat)
    {
        float referenceStatFloat = (float)referenceStat;
        int totalPowerGain = (int)(referenceStat * this.TotalPowerGainThroughCompletedLevels);

        return referenceStat + totalPowerGain;
    }
}
