# class ChooseRandomScene extends class ManageSceneWideObject

Provides callback methods for select a random scene by using the functionality of an object the component "SelectScenes". If such an object does not exits yet then it will spawned.

## where to attach

Attach it to game object which triggers scene change.

## callback methods

ChooseNextRandomScene()
Will make sure the next scene to be loaded will be random.

ChooseNextRandomSceneFromPause()
Does the same as ChooseNextRandomScene() and unpauses the game.
Use that if the game is paused when the scene is changed.