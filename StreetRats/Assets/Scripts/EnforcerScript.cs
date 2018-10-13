using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforcerScript : EnemyStats
{
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Move(Vector3 target)
    {
        //Enforcer patrols


        //if the player is in their aggro range they attack


    }

    private Vector3 TrackPlayer()
    {
        return player.transform.position;
    }
}
