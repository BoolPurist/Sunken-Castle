# class ChangeScene

Unity component for loading a new scene when clicked on a object as a button.

It provides 2 methods currently

## Where to attach

This component should be attached to a game object that represents a button on a canves in unity so the callback methods of this component can be invoke by a click event.

## callback methods.

OnClickChangeScene(string sceneName)
Changes to the scene according to the string parameter given in the code invoking the this callback method

OnClickChangeSceneFromPause(string sceneName)
Does the same as OnClickChangeScene(string sceneName) and unpauses the game additionally.
It is recommended to use this callback method when the game is paused during changing to another scene.

