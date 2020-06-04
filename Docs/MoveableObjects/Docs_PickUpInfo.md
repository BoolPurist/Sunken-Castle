# class PickUpInfo

Summary: Entity with this script is able to be picked up by Player and give him a chosen effect.

## attributes

public int healthAmount

Summary: Amount of health the player gains when picking up the entity

public Transform healthPos

Summary: Position from which the healingRange will be cast

public Vector2 healingRange

Summary: Range around the entity the Player has to touch in order to pick up the entity

public LayerMask whatIsPlayer

Summary: Layer used to check if a Player is currently touching the entity

## Methods

private void Update()

Summary: Is cast once per frame. Checks if a Player is in range of the healingRange, if yes, acitvates "GainHealth(int x)" method of the player, whereas x is the healthAmount. If Player "picked up" the entity, the entity gets destroyed.

private void OnDrawGismosSelected()

Summary: Draws the healingRange around the healthPos, which makes it easier to work with the entity