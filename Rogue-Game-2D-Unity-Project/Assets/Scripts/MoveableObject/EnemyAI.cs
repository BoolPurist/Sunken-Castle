using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    //Classic attributes
    public Transform target; //Player position
    public float speed = 2f; //Enemy walking speed
    public float nextWaypointDistance = 1f; //When Enemy is this close to waypoint, waypoint is seen as reached, go after the next waypoint
    public Animator animator;
    public float triggerDistance = 5f;
    [HideInInspector]
    public bool allowedToMove = true;


    //Attributes used for A* pathfinding
    Path path;
    int currentWaypoint = 0; //Current waypoint of current path
    bool reachedEndOfPath = false; //Did we reach the end of the path?

    Seeker seeker; //Class from datapacket
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        InvokeRepeating("UpdatePath", 0f, 1f); //Update path every 0.5 seconds, value can be changed accordingly
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && this.target != null) //If seeker is done updating the path, update the path again
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.target != null)
        {
            float distanceToTarget = 0f;
            Vector2 force = Vector2.zero;

            if (target != null)
                distanceToTarget = Vector3.Distance(target.position, transform.position);  //saves the distance between Player and Enemy

            if (path == null) //If we don't have a path, do nothing
                return;

            if (currentWaypoint >= path.vectorPath.Count) //Current waypoint greater than amount of waypoints => We are at the end
            {
                reachedEndOfPath = true; //We reached the end
                return;
            }
            else
            {
                reachedEndOfPath = false; //We didn't reacht the end yet
            }


            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; //Next waypoint - currentPositon gives us vector to the waypoint
            if (allowedToMove == true && target != null && distanceToTarget <= triggerDistance)
            {
                force = direction * speed * Time.deltaTime; //force that moves the enemy, normalized direction Vector times the speed
            }
            else if (allowedToMove == false || target == null || distanceToTarget >= triggerDistance)
            {
                force = Vector2.zero;
            }

            animator.SetFloat("Horizontal", force.x);
            animator.SetFloat("Vertical", force.y);
            animator.SetFloat("Speed", force.sqrMagnitude);

            rb.AddForce(force); //Moves the enemy

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance) //If we are near enough by the next waypoint
            {
                currentWaypoint++; //go to the next waypoint
            }

        }


    }

    void OnDrawGizmosSelected() //Visualizes the trigger distance for testing
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerDistance);

    }


    //COMMENTS FOR DEVELOPMENT

    //animator.SetFloat("Horizontal", movement.x);
    //animator.SetFloat("Vertical", movement.y);
    //animator.SetFloat("Speed", movement.sqrMagnitude);

}