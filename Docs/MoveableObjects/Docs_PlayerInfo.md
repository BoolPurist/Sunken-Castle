# class PlayerInfo

Summary: Manages the health of the player

## attributes

public delegate void OnHealthChange(int number)

Summary: Used for Event and UI Health showcase, number is currentHealth

public event OnHealthChange OnHealthChanges

Summary: Event fired when health changes

public EventHandler OnDeathPlayer

Summary: Event fired when player dies

public Animator animator

Summary: Player Animator

public int maxHealth

Summary: Maximal health of the player

public int currentHealth

Summary: current health of the player

public bool isDead

Summary: true if player has died, false else

## Methods

public int CurrentHealth

Summary: get-Method for currentHealth

private void Start()

Summary: sets currentHealth to maxHealth, Adds needed Methods to events, fires event onHealthChange as to update the UI to maxHealth

private void Update()

Summary: Is cast once per frame, checks for player death, invokes needed events, destroys the object

public void TakeDamage()

Summary: Plays isHit Animation, updates player health und invokes HealthChange event

public void GainHealth(int health)

Summary: Gains certain amount of health, can't go above maxHealth, invokes OnHealthChange event

