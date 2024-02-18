using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public GameOver gameOver;

    public LayerMask whatIsGround, whatIsPlayer;
    // ~~~Chelle's contribution~~~
    Animator animator;
    AudioSource audioSource;
    public AudioClip alertSound;
    bool playedAlready;
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~

    //Patrolling
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    //Vector3 enemy; (Didn't work)

    //States
    public float sightRange;
    public bool playerInSightRange, isChasingPlayer;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        // ~~~Chelle's contribution~~~
        playedAlready = false;
        audioSource = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    private void Update()
    {


        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
        {
            // ~~~Chelle's contribution~~~
            if (playedAlready == false)
                audioSource.PlayOneShot(alertSound);
            playedAlready = true;
            animator.SetBool("Chase", true);
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ChasePlayer();
        }
        else
        {
            // ~~~Chelle's contribution~~~
            animator.SetBool("Chase", false);
            playedAlready = false;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~
            Patrolling();
        }
    }

    //This code finds the Waypoints placed on the map
    private void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
        Debug.Log("Updating the Location");
    }
    //This code resets the Waypoint Index for patrolling
    private void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
    //This code allows the enemy to patroll
    private void Patrolling()
    {
        //If the player was in a previous chasing state, it updates the destination to the previous logic
        if (isChasingPlayer == true)
        {
            UpdateDestination();
            isChasingPlayer = false;
        }
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
            Debug.Log("Still Patrolling");
        }

    }

    //This code allows the enemy to Chase
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Debug.Log("Chasing the Player");
        isChasingPlayer = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            gameOver.Setup();
            Debug.LogWarning("I did it");
        }
    }
}