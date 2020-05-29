# class NavigatorForKeyboard

Makes a menu controllable with keyboard.

## public attributes for unity inspector

**public KeyCode MoveUpKey = KeyCode.UpArrow**

Summary:
Holds to key to press to the following:
Upper adjacent button gets selected. If the currently button has no upper adjacent button,
the most bottom button of the menu is selected.

**public KeyCode MoveDownKey = KeyCode.DownArrow**

Summary:
Holds to key to press to the following:
Bottom adjacent button gets selected. If the currently button has no bottom adjacent button,
the most upper button of the menu is selected.

**public KeyCode SelectKey = KeyCode.Space**

Summary:
Holds to key to press to the following:
Code attached to the currently selected button is executed.

## private attributes

**private int currentSelected = -1**

Summary:
Represents current selected button in form of an index number in the linked list "buttons".

**private int buttons**

Summary:
Holds all children with a built-in unity component "Button" of a game object.

## methods

**private void Start()**

Summary:
At the instantiating of a object with that unity component, every children object with a built-in unity component "Button" is saved in the linked list "buttons"

**private void Update()**

Summary:
Every frame this unity component listens to the keyboard input. When a key hold by the public attributes is pressed, the according action is executed. If no key was not stroke before, the most upper button is selected.
