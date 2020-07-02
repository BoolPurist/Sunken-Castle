# class ManageGameOverScreen

Creates a Game Over screen on the game view on the base of an unity prefab.

## Where to attach ?

It recommended to attach this component to the game object in a scene that represents the camera of the player. That object has usually a component "Camera" attached.

## properties in the unity inspector.

Pause Menu State (optional)
Other component that handles a pause menu. This way the pause menu will not triggered during the game over screen because the game is over. This component should be attached to same game object that the ManageGameOversScreen is attached to.

Prefab Game Over Screen (mandatory)
Prefab that makes up the menu for game over when the player dies. A prefab must be assigned to the property in the unity inspector for this component to work properly.
