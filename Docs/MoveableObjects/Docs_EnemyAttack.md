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

private Animator anim

Summary: Enemy Animator

public float timeBtwEnemyAttack

Summary: set time that needs to pass for the enemy to be able to attack again

private float curTimeBtwEnemyAttack

Summary: Time that has to pass until the next attack can be launched

public bool allowToAttack 

Summary: Allows or disallows the enemy to attack

## Methods

private new void Start()

Summary: Sets variables to needed components and increases the enemy damage according to the number of levels the player has completed

private void Update()

Summary: Is cast once per frame. Checks if player is touching the enemy, if that is the case, the enemy is allowed to attack and the timeBtwÁttacks is smaller than 0 the enemy starts the "TryToAttack" Coroutine, else, the timer counts down

private IEnumerator TryToAttack()

Summary: Starts attack animation, when the animation is at its peak, checks again for the player, if he is still there, damage the player

void OnDrawGizmosSelected()

Summary: Draws attackRange for easier Levelbuilding



