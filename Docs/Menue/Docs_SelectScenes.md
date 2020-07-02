# class SelectScenes

Selects a random scene provided in the building settings of the game.
It will not select are already chosen scene until all available random scenes were already chosen. Then the pool of available random scene to choose from is rested.

## Where to attach

It is recommended to attach this component to a prefab as scene wide object  which does not get destroyed when a scene change happens.

## properties in the unity inspector

Start Index Scene 
Every scene in the building scene has an index. The start index determines which scenes are included in the random selection.
First example is 0 as start index. Here all scenes included in the building settings can be chosen.
Second example is 2 as start index. Here the scene with the index 2 and all other scenes with higher index in the building settings can be chosen.