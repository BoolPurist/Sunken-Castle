# class EnemyAI

Summary: Script which lets the enemy find its way around obstacles to find the player, the A* datapack is used heavily for this, if a method or attribute from the datapack is used, i will show it with "(A*)" behind it

## attributes

public Transform target

Summary: Position of the player

public float speed

Summary: Movement speed of the enemy

public float nextWaypointDistance

Summary: Enemy needs to be this close to currentWaypoint to start chasing the next waypoint

public Animator animator

Summary: enemy animator

public float triggerDistance

Summary: The enemy will only follow the player if he is this close to the enemy

public bool allowedToMove

Summary: allows / disallows the enemy to move

private Path path (A*)

Summary: path the enemy takes to get to the player

private int currentWaypoint

Summary: the currentWaypoint the enemy is walking to on his way to the player

private bool reachedEndOfPath

Summary: if true, the enemy has reached the player

private Seeker seeker (A*)

Summary: Seeker which creates a path through the level for the enemy to follow

private Rigidbody2D rb

Summary: "physical" body of the enemy used for collision

# methods

private void Start()

Summary: sets attributes to needed components. Invokes the UpdatePath() method which will be activated once every second. Creates the first path towards the player

void UpdatePath()

Summary: if a path if fully built, and the player is still alive, builds the next path

void OnPathComplete(path p)

Summary: if current path is completed and we have a next path, set currentPath to next path and follow it

private void FixedUpdate()

Summary:
- If the player is still alive, calculate distance between player and enemy, if distance is greater than triggerDistance, don't follow the player

- If no path is given, do nothing

- If currentWaypoint is larger than last waypoint of path, we reached the end of the path, if not, we didn't

- calculate movementVector used to follow the path, add vector force to enemy

- Activate animator accordingly

- if distance to current waypoint is smaller than nextWaypointDistance, chase next waypoint

private void OnDrawGizmosSelected()

Summary: draws out the triggerDistance for easier setup

