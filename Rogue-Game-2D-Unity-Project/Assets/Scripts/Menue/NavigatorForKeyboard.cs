using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NavigatorForKeyboard : MonoBehaviour
{
    [Tooltip("Button to press to move up in the selection in the options.")]
    public KeyCode MoveUpKey = KeyCode.UpArrow;
    [Tooltip("Button to press to move down in the selection in the options.")]
    public KeyCode MoveDownKey = KeyCode.DownArrow;
    [Tooltip("Button to press to select a focused button vie keyboard.")]
    public KeyCode SelectKey = KeyCode.Space;

    // Index of the array which holds the buttons of the options.
    // If the selection goes up by one the index is incremented.
    // If the selection goes down by one the index is decremented.
    private int currentButtonSelected = -1;
    // Holds the buttons of the option.
    private List<Button> buttons = new List<Button>();

    // Start is called before the first frame update
    private void Start()
    {
        foreach (Transform child in this.transform)
        {
            Button currentButton = child.gameObject.GetComponent<Button>();
            // Checks if the a child is button by having the component button.
            if (currentButton != null)
            {
                buttons.Add(currentButton);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Listens to the keyboard stroke.
        bool MoveUpKeyPressed = Input.GetKeyDown(MoveUpKey);
        bool firePressed = Input.GetKeyDown(SelectKey);
        bool MoveDownKeyPressed = Input.GetKeyDown(MoveDownKey);

        // Checks if an element of the options has been not be selected by keyboard so far.
        if ((MoveDownKeyPressed || MoveUpKeyPressed || firePressed) && currentButtonSelected == -1)
        {
            currentButtonSelected = 0;
            this.buttons[currentButtonSelected].Select();
        }
        else if (MoveUpKeyPressed)
        {
            // Moves the to next botton down.
            currentButtonSelected--;
            // if the selections goes up too much so the index is smaller than zero.
            // Otherwise an OutOfBoundException would happen.
            currentButtonSelected = currentButtonSelected >= 0 ? currentButtonSelected : buttons.Count - 1;
            this.buttons[currentButtonSelected].Select();
        }
        else if (MoveDownKeyPressed)
        {
            // Moves the to next botton up.
            currentButtonSelected++;
            // if the selections goes down too much so the index is >= length of the button array.
            // Otherwise an OutOfBoundException would happen.
            currentButtonSelected = currentButtonSelected < buttons.Count ? currentButtonSelected : 0;
            this.buttons[currentButtonSelected].Select();
        }
        else if (firePressed && currentButtonSelected != -1)
        {
            // The attached callback functions on the currently selected buttons is triggered.
            this.buttons[currentButtonSelected].onClick.Invoke();
        }

    }
}
