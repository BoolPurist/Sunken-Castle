# class GetCameraComponent

Custom component for fixing wrong overlapping of gui elements and sprites that results from creating/destroy menus dynamically

## Where to attach

This component should be attached to a game object that has the component "canvas" and holds buttons for submenus.  

## properties in the unity inspector

tagForCamera (mandatory)
Tag to find object with the component "camera" which is assigned as renderer camera for the canvas.  

sortingLayer (mandatory)
Name of sorting layer the canvas should have
