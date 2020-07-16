using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    //Classic attributes
    [HideInInspector]
    public Transform target; //Player position
    public float speed = 2f; //Enemy walking speed
    public float nextWaypointDistance = 1f; //When Enemy is this close to waypoint, waypoint is seen as reached, go after the next waypoint
    public Animator animator;
    public float triggerDistance = 5f;
    [HideInInspector]
    public bool allowedToMove = true;


    //Attributes used for A* pathfinding
    private Path path;
    private int currentWaypoint = 0; //Current waypoint of current path
    private bool reachedEndOfPath = false; //Did we reach the end of the path?

    private Seeker seeker; //Class from datapacket
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        this.seeker = GetComponent<Seeker>();
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.target = GameObject.Find("Player").transform;

        InvokeRepeating("UpdatePath", 0f, 1f); //Update path every 0.5 seconds, value can be changed accordingly
        this.seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    private void UpdatePath()
    {
        if (this.seeker.IsDone() && this.target != null) //If seeker is done updating the path, update the path again
        {
            this.seeker.StartPath(this.rb.position, this.target.position, OnPathComplete);
        }

    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            this.path = p;
            this.currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float distanceToTarget = 0f;
        Vector2 force = Vector2.zero;

        if (this.target != null)
        {

            if (this.target != null)
                distanceToTarget = Vector3.Distance(this.target.position, this.transform.position);  //saves the distance between Player and Enemy

            if (this.path == null) //If we don't have a path, do nothing
                return;

            if (this.currentWaypoint >= this.path.vectorPath.Count) //Current waypoint greater than amount of waypoints => We are at the end
            {
                this.reachedEndOfPath = true; //We reached the end
                return;
            }
            else
            {
                this.reachedEndOfPath = false; //We didn't reach the end yet
            }


            Vector2 direction = ((Vector2)this.path.vectorPath[currentWaypoint] - this.rb.position).normalized; //Next waypoint - currentPositon gives us vector to the waypoint
            if (this.allowedToMove == true && this.target != null && distanceToTarget <= this.triggerDistance)
            {
                force = direction * this.speed * Time.deltaTime; //force that moves the enemy, normalized direction Vector times the speed
            }
            else if (this.allowedToMove == false || this.target == null || distanceToTarget >= this.triggerDistance)
            {
                force = Vector2.zero;
            }

            this.animator.SetFloat("Horizontal", force.x);
            this.animator.SetFloat("Vertical", force.y);
            this.animator.SetFloat("Speed", force.sqrMagnitude);

            this.rb.AddForce(force); //Moves the enemy

            float distance = Vector2.Distance(this.rb.position, this.path.vectorPath[currentWaypoint]);

            if (distance < this.nextWaypointDistance) //If we are near enough by the next waypoint
            {
                this.currentWaypoint++; //go to the next waypoint
            }

        }


    }

    private void OnDrawGizmosSelected() //Visualizes the trigger distance for testing
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, this.triggerDistance);

    }

}