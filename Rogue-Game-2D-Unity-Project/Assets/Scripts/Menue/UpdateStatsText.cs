using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStatsText : MonoBehaviour
{
    private string textTemplate;
    // Start is called before the first frame update
    void Start()
    {
        Text statText = this.GetComponent<Text>();
        textTemplate = statText.text;
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void CallbackUpdateStats(int number)
    {
        Text statText = this.GetComponent<Text>();
        statText.text = $"{this.textTemplate} {number}";
    }
}
