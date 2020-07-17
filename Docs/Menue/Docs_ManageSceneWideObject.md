# class ManageSceneWideObject

Spawns a game object that remains even when a new scene is loaded.
It will only spawn this game object when it does not exits in scene yet.
Provides also the functionality to remove the game object from a scene

## where to attach

This component can be attached to every game object in scene to work. For example you can attach to a button which invokes a callback method when clicked

## properties in the unity inspector

prefabSceneWideObject (mandatory)
Prefab that is the base for the game object which should exits over servals scenes.

## callback methods

ResetSceneWideObject()
Deletes the scene wide object and creates a new one. This way the object is rested.

SpawnSceneWideObject()
Creates a scene wide object. It only does so when the object does not exit yet.

DeleteSceneWideObject()
Deletes the scene wide object if was created
