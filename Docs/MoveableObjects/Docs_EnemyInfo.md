# class EnemyInfo

Summary: handles health and death of and enemy

## attributes

public delegate void OnDeathEnemy(int number)

Summary: used for event OnDeathEnemy

public event OnDeathEnemy OnDeathEnemies

Summary: invoked when an enemy dies, raises score

public Animator animator

Summary: enemy animator

private bool isDead

Summary: bool which checks if enemy is dead, true if yes, false else

public int score

Summary: Amount of score the player recieves when killing the enemy

public int maxHealth

Summary: Maximal health of the enemy

private int currentHealth

Summary: current health of the enemy

## methods

public int CurrentHealth

Summary: get-Method for currentHealth

private void Start

Summary: Adds methods to event, sets currentHealth to maxHealth, sets "Animator" to needed components

private void update()

Summary: checks for enemy death, if enemy dies, invoke Die()

public void TakeDamage(int damage)

Summary: subtracts "damage" from "currentHealth"

public void Die()

Summary: disallows the enemy to move, invokes event to raise player score, disallows the enemy to attack, plays death animation, destroys the enemy


