# class PlayerAttack

Summary: Let's the player attack

## attributes

public float timeBtwAttacks

Summary: time needed to wait between two attacks

private float curTimeBtwAttacks

Summary: time until the next attack can be executed

public Animator animator

Summary: player animator

public Transform attackPos(Right/Left/Up/Down)

Summary: Points in all 4 directions from which the attackRange will create a circle around them, the program will search for enemies in that circle

public float attackRange

Summary: Range of the attack, extends from the attackPos 

public int damage

Summary: damage the player deals per hit

public LayerMask whatIsEnemy

Summary: Layer the program uses to search for enemies

## Methods

private void Update()

Summary: Is cast once per frame, if an attack can be executed, checks if attack button is pressed, and attacks in chosen direction, else, let's time tick down

private void OnDrawGizmosSelected()

Summary: Draws the attackRange for easier setup