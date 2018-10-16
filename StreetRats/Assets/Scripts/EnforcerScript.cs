using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnforcerScript : EnemyStats
{
    private GameObject player;
    private int rng;
    private NavMeshAgent agent;
    private bool reachedPatrolPoint;
    private bool isAttacking;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        reachedPatrolPoint = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        //Determines if they reached a patrol point
        //if()
        //{
        //    reachedPatrolPoint = true;
        //}

        //Picks new patrol point when they reach one
		if(reachedPatrolPoint)
        {
            Patrol();
            reachedPatrolPoint = false;
        }

        //if they are attacking
        if(isAttacking)
        {
            Attack();
        }
         
	}

    public void Patrol()
    {
        //Enforcer patrols
        //Choses a random patrol point
        int rngMax = GetPatrolPoints().Length + 1;
        rng = Random.Range(0, rngMax);

        //Moves to that patrol point
        agent.destination = GetPatrolPoints()[rng]. transform.position;
    }

    private Vector3 TrackPlayer()
    {
        return player.transform.position;
    }

    //Follow player when they move in range
    private void OnCollisionStay()
    {
        agent.destination = TrackPlayer();
    }

    //Patrols when player is out of range
    private void OnCollisionExit()
    {
        Patrol();
    }

    //Attacks the player
    private void Attack()
    {
        
    }
}
