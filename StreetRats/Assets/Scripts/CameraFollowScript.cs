using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public Transform follow;


    public float smoothSpeed = 10f;

    public Vector3 offSet;

    private void LateUpdate()
    {
        Vector3 desiredPosition = follow.position + offSet;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
