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

    protected int completedLevels = -1;

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
                Debug.LogWarning($"Object with the tag given by this.tagForObjectWithCompleted was found !");
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

    private float TotalPowerGainThroughCompletedLevels() => Math.Max(0, this.completedLevels) * this.powerGainPerLeveCompleted;

    protected int WholeNumberStatFromPowerGain(int referenceValue)
    {
        float referenceValueFloat = (float)referenceValue;
        int totalPowerGain = (int)(referenceValue * this.TotalPowerGainThroughCompletedLevels());

        return referenceValue + totalPowerGain;
    }
}
