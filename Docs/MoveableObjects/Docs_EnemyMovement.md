# class EnemyMovement

Summary: is used to let the enemy move around the level in different styles

## attributes

public Transform player

Summary: Position of the player in the Level

public Rigidbody2D rb

Summary: Body of the enemy which is used to move it around

private Vector2 movement

Summary: the final movment vector of the enemy

public Animator animator

Summary: Animator used for animating the movement

public float moveSpeed

Summary: The speed at which the enemy moves

public int movementType

Summary: The style of movement the enemy uses:
 - (movementType = 1) Run to the player
 - (movementType = 2) Run from the player

public bool allowedToMove

Summary: Allows or disallows the enemy to move

## Methods

private void Start()

Summary: Sets "animator" and "rb" to the needed components

private void Update()

Summary: Is cast once per frame. Calculates the direction from the playerposition, rotates the enemy in needed direction and sets movement vector. If no player can be found, stops the enemy. Gives needed information for movement to the animator controller.

private void FixedUpdate()

Summary: Starts one of the movement methods depending on which movementType is chosen

private void moveToPlayer(Vector2 direction)

Summary: Moves the enemy in a straight line to the player

private void moveFromPlayer(Vector2 direction)

Summary: Moves the enemy in a straight line away from the player