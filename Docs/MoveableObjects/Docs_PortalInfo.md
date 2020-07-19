# class PortalInfo

Summary: Script for the portal entity that is used to change levels, level can be changed to new random level after all enemies are defeated

## attributes

private bool isActivated

Summary: if all enemies in the level have been deafeated, the portal activates

public Animator animator

Summary: Portal Animator

## methods

private void Update()

Summary: Checks if all enemies have been defeated, if yes, activates portal with according animation

public void OnTriggerStay2D(Collider2D other)

Summary: Checks if a player has entered the portal, if yes, and the portal is activated, invokes method ChooseNextRandomScene in different script, and changes level
