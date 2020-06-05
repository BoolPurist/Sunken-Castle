# class EnemyAttack

Summary: Let's the enemy attack the player

## attributes

public Transform attackPos

Summary: Position from which the attackRange goes out

public LayerMask whatIsPlayer

Summary: Layer for checking if a Player is touching the enemy

public int damage

Summary: Amount of damage the enemy does to the Player each attack

public Vector2 attackRange

Summary: Range around the attackPos which the Player has to touch to damage

private int angle

Summary: Angle at which the attack is launched

public float timeBtwEnemyAttack

Summary: set time that needs to pass for the enemy to be able to attack again

private float curTimeBtwEnemyAttack

Summary: Time that has to pass until the next attack can be launched

## Methods

private void Update()

Summary: Is cast once per frame. Checks if player is touching the enemy, if yes, casts the "TakeDamage(int x)" method of the player, whereas x is the "damage". Only able to attack if "curTimeBtwEnemyAttack" is 0, if higher, reduces the time.

void OnDrawGizmosSelected()

Summary: Draws attackRange for easier Levelbuilding



