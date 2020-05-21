using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStatsText : MonoBehaviour
{
    // Holds the text given by the unity inspector to be used later.
    private string textTemplate;
    private int currentStat = 0;
    // Start is called before the first frame update
    void Start()
    {
        Text statText = this.GetComponent<Text>();
        // Saves the text given by the unity inspector.
        textTemplate = statText.text;
    }


    // Update is called once per frame
    void Update()
    {

    }

    // Takes the number and insert it at end of the gui text.
    public void CallbackUpdateStats(int number)
    {
        this.currentStat = number;
        Text statText = this.GetComponent<Text>();
        statText.text = $"{this.textTemplate} {number}";
    }

    // Adds number to a inner stat value and then inserts that value at the end of the guitext
    public void CallbackUpdateStatsAdd(int number)
    {
        this.currentStat += number;
        CallbackUpdateStats(currentStat);
    }

    // Resets the stat value to zero and then inserts that zero at the end of the gui text.
    public void CallbackUpdateStatsReset()
    {
        this.currentStat = 0;
        CallbackUpdateStats(currentStat);
    }
}
