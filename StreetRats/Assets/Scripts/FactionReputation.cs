using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactionReputation : MonoBehaviour
{
    private int reputationPoints = 50;
    private int reputationMin = 0;
    private int reputationMax = 100;
    private float aggroRadius;


    //reference for the bar at the top of the screen

    [SerializeField]
    private Image ReputationSliderImage;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public int GetReputationPoints()
    {
        return reputationPoints;
    }

    public void ModifyReputationPoints(int points)
    {
        //if it goes over the max
        if((reputationPoints += points) >= reputationMax) 
        {
            reputationPoints = reputationMax;
        }
        //if it goes under the min
        else if((reputationPoints += points) <= reputationMin)
        {
            reputationPoints = reputationMin;
        }
        //if its in the middle
        else
        {
            reputationPoints += points;
        }

        updateUI();
    }

    private void updateUI()
    {
        ReputationSliderImage.fillAmount = (float)reputationPoints / 100;
    }
}
