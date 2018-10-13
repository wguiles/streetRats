using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour {


    private Transform playerController;
	void Start () 
    {
        playerController = transform.parent;
	}
	
	// Update is called once per frame
	void Update () 
    {
		 transform.up = new Vector3(Input.GetAxis("AttackX"), Input.GetAxis("AttackY"));
    }


}
