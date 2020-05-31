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

    }


    // Update is called once per frame
    void Update()
    {

    }

    // Updates the gui text the current stat value.
    private void UpdateText()
    {
        Text statText = this.GetComponent<Text>();
        if (this.textTemplate == null)
        {
            this.textTemplate = statText.text;
        }

        int textPointsLength = this.currentStat.ToString().Length;
        statText.text = $"{this.textTemplate} {this.currentStat}";
    }

    // Takes the number and insert it at end of the gui text.
    public void CallbackUpdateStats(int number)
    {
        this.currentStat = number;
        this.UpdateText();
    }

    // Adds number to a inner stat value and then inserts that value at the end of the guitext
    public void CallbackUpdateStatsAdd(int number)
    {
        this.currentStat += number;
        this.UpdateText();
    }

    // Resets the stat value to zero and then inserts that zero at the end of the gui text.
    public void CallbackUpdateStatsReset()
    {
        this.currentStat = 0;
        this.UpdateText();
    }
}
