# class UpdateStatsText

Serves as an interface for other game objects to display a status as a number in a text displayed on
the player view.

## where to attach

Attach it to a game object with the unity component "Text". That game object must be a child of a game
object with component "canvas".

## properties from other components in the unity inspector that influences this component.

Text from the component "Text".
It is text field. What is written here, will be displayed before the number manged by the component
"UpdateStatsText".

## Note on usage in a prefab

It is recommended to place a game object as text with this component attached to place to the left of canvas. Reason: Otherwise a part the status as text can be outside to the game view.