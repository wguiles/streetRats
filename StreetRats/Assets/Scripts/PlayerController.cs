﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{


    public enum MovementType { standard, scurry, auto };


    [Header("General")]
    public MovementType moveType;
    public float speed;
    private int cheeseAmount;


    private float direction = 1.0f;
    private GameObject gunChild;

  

    [Header("Dash")]
    public float dashSpeed;
    public float dashTime;
    public float dashRechargeTime;
    private Vector3 dashDirection;
    private bool isDashing = false;
    private bool canDash   = true;




    void Start () 
    {
        gunChild = transform.GetChild(0).gameObject;

        if (moveType == PlayerController.MovementType.scurry)
        {
            gunChild.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!isDashing)
        {
            if (moveType == PlayerController.MovementType.standard)
            {
                transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime);


                if (Input.GetButtonDown("A Button") || Input.GetButtonDown("A Button Windows"))
                {
                    gunChild.SetActive(true);
                }
                else if (Input.GetButtonUp("A Button") && canDash || Input.GetButtonUp("A Button Windows") && canDash)
                {
                    dashDirection = gunChild.transform.up;
                    StartCoroutine(Dashing());
                    //transform.position += gunChild.transform.up * 5f;
                }

            }
            else if (moveType == PlayerController.MovementType.scurry)
            {
                ScurryMovement();
            }
            else if (moveType == PlayerController.MovementType.auto)
            {
                AutoMovement();
            }
        }
        else
        {
            Dash();
        }

	}

    private void Dash()
    {
        transform.Translate(dashDirection * Time.deltaTime * dashSpeed);
    }

    private void ScurryMovement()
    {

        
        float horizontalPos = Input.GetAxis("Horizontal");
        float verticalPos   = Input.GetAxis("Vertical");


        if (horizontalPos > 0.0f && Mathf.Abs(verticalPos) < 0.8f)
        {
            //moving right
            Debug.Log("Moving right");
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f) * speed * Time.deltaTime * direction);
        }

        else if (horizontalPos < 0.0f && Mathf.Abs(verticalPos) < 0.8f)
        {
            Debug.Log("Moving left");
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f) * speed * Time.deltaTime * direction);
        }

        else if (verticalPos > 0.0f && Mathf.Abs(horizontalPos) < 0.8f)
        {
            //moving up
            transform.Translate(new Vector3(0f, verticalPos) * speed * Time.deltaTime * direction);
            Debug.Log("Moving up");
        }

        else if (verticalPos < 0.0f && Mathf.Abs(horizontalPos) < 0.8f)
        {
            //moving down
            transform.Translate(new Vector3(0f, verticalPos) * speed * Time.deltaTime * direction);
            Debug.Log("Moving down");
        }

        if (Input.GetButtonDown("A Button") || Input.GetButtonDown("A Button Windows"))
        {
            direction = 0.0f;
            gunChild.SetActive(true);
        }
        else if (Input.GetButtonUp("A Button") && canDash || Input.GetButtonUp("A Button Windows") && canDash)
        {

            direction = 1.0f;
            gunChild.SetActive(false);

            dashDirection = gunChild.transform.up;
            StartCoroutine(Dashing());
            //transform.position += gunChild.transform.up * 5f;
        }
    }


    private Vector3 moveDirection;

    private void AutoMovement()
    {


        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.8f || Mathf.Abs(Input.GetAxis("Vertical")) >= 0.5f)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        }

        transform.Translate(moveDirection * speed * Time.deltaTime * direction);

        if (Input.GetButtonDown("A Button") || Input.GetButtonDown("A Button Windows"))
        {
            Time.timeScale = 0.3f;
            //direction = 0f;
            gunChild.SetActive(true);
        }
        else if (Input.GetButtonUp("A Button") || Input.GetButtonDown("A Button Windows"))
        {
            Time.timeScale = 1.0f;
            //direction = 1f;
            dashDirection = gunChild.transform.up;
            StartCoroutine(Dashing());
            moveDirection = gunChild.transform.up;
            //transform.position += gunChild.transform.up * 5f;
        }

    }

    private IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        StartCoroutine(RechargeDash());

    }

    private IEnumerator RechargeDash()
    {
        yield return new WaitForSeconds(dashRechargeTime);
        canDash = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dank" && isDashing)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cheese")
        {
            cheeseAmount ++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Mice_Hideout")
        {
            while (cheeseAmount > 0)
            {
                cheeseAmount--;
                GameObject.Find("FactionReputation").GetComponent<FactionReputation>().ModifyReputationPoints(1);
            }

        }
        else if (other.gameObject.tag == "Rats_Hideout")
        {

            while (cheeseAmount > 0)
            {
                cheeseAmount--;
                GameObject.Find("FactionReputation").GetComponent<FactionReputation>().ModifyReputationPoints(-1);
            }
          
        }
    }

    private void jump()
    {

    }
}
