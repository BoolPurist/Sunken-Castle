using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject prefabGameOverScreen;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CallbackCreateGameOverScreen(object sender, EventArgs e)
    {
        if (prefabGameOverScreen == null)
        {
            Debug.Log("No Prefab was provided for the game over screen !");
        }
        else
        {
            GameObject gameOverScreen = Instantiate(prefabGameOverScreen, this.transform);
        }
    }
}
