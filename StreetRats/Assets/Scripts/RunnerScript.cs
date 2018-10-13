using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerScript : EnemyStats
{
    private int cheeseAmount;
    [SerializeField] private GameObject[] cheeseList;
    private GameObject closestCheese;
    private bool pickupCheese;

	// Use this for initialization
	void Start ()
    {
        //Starts moving towards the closest cheese
        Move(TrackCheese());
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(pickupCheese)
        {
            cheeseAmount++;
            Destroy(closestCheese);
            Move(TrackCheese());
            pickupCheese = false;
        }

        //TO DO LATER: if they have so much cheese they run back to their faction
	}

    private void Move(Vector3 target)
    {
        
    }

    private Vector3 TrackCheese()
    {
        Vector3 runnerLocation = this.transform.position;

        //find cheese game objects
        cheeseList = GameObject.FindGameObjectsWithTag("Cheese");
        print(cheeseList);

        //first item in the list starts as the closest
        closestCheese = cheeseList[0];

        //find closest one in the list
        for(int index = 1; index < cheeseList.Length; index++)
        {
            //if the distance between the runner and the cheese in the list is less, change the closest cheese
            if(Vector3.Distance(closestCheese.transform.position, runnerLocation) > Vector3.Distance(cheeseList[index].transform.position, runnerLocation))
            {
                closestCheese = cheeseList[index];
            }
        }

        //return location of closest one
        return closestCheese.transform.position;
    }
}
