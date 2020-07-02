# class NavigatorForKeyboard

Makes a button menu controllable with a keyboard.

## where to attach ?

On the game object with the component "Canvas" and as parent of the game object as buttons for the menu.

## properties in the unity inspector

Move Up Key (mandatory)
Pressing this key moves the selection to next button up. If the current button is first one from the top.
The selection moves to the button at the bottom.
Move Down Key (mandatory)
Pressing this key moves the selection one button down. If the current button is first one from the bottom. 
The selection moves to the first button from the top.
Select Key (mandatory)
Pressing this key clicks on the button which is currently selected. This invokes the callback methods of a component attached to an object.