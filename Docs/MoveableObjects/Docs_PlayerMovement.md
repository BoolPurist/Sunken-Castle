# class PlayerMovement

Summary: let's the player move

## attributes

public float moveSpeed

Summary: Movement speed of the player

public Rigidbody2D rb

Summary: "physical" body of the player used for collision

public Animator animator

Summary: player animator

Vector2 movement

Summary: calculated movement vector

public bool allowToMove

Summary: bool whicht allows/disallows the player to move

## methods

private void Start()

Summary: sets "Animator" and "Rigidbody2D" to needed components

private void Update

Summary: checks for movement input

private void FixedUpdate

Summary: if player is allowed to move, program moves player in direction gained from the input, and activates animator accordingly