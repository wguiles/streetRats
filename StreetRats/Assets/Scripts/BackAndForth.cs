using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour {

    public float moveSpeed = 1f;
    public enum moveType { moveHorizontal, moveVertical };
    public moveType move;
    public float maxLimit;
    public float minLimit;

	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (move == moveType.moveHorizontal)
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0f, 0f));

            if (transform.position.x >= maxLimit)
            {
                transform.position = new Vector3(maxLimit, transform.position.y, transform.position.z);
                changeDirection();
            }
            else if (transform.position.x <= minLimit)
            {
                transform.position = new Vector3(minLimit, transform.position.y, transform.position.z);
                changeDirection();
            }
            
        }
        else if (move == moveType.moveVertical)
        {
            transform.Translate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));

            if (transform.position.y >= maxLimit)
            {
                transform.position = new Vector3(transform.position.x, maxLimit, transform.position.z);
                changeDirection();
            }
            else if (transform.position.y <= minLimit)
            {
                transform.position = new Vector3(transform.position.x, minLimit, transform.position.z);
                changeDirection();
            }
        }
    }

    private void changeDirection()
    {
        moveSpeed *= -1f;
    }
}
