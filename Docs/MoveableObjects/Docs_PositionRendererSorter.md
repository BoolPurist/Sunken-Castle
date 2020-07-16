# class PositionRendererSorter

Summary: Puts the object which this script is attached to on the right Position

## attributes

private Renderer myRender

Summary: Renderer for sortingOrder

private int sortingOrderBase

Summary: Sorting Order Base for detailed Postion

private int offset

Summary: Position can be manipulated through inspector

private bool updateOnce

Summary: if the object doesn't change Position => true; if Postion updates while in game => false

private float timer

Summary: slows down the update rate for performance

private float timerMax

Summary: constant to reset timer

## Methods

private void LateUpdate()

Summary: Is casted once per frame, if the timer is 0f, calculates the needed sortingOrder, and checks wheter this needs to be done more than once, otherwise it destroys itself

private void Awake()

Summary: Gets the Component Renderer attached to the object as soon as the scene is executed
