﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera360 : MonoBehaviour {

    public Transform target;
    private Vector3 oldTargetPosition;
    private Quaternion rotation;

    private Vector3 pivotPoint;
    private Vector3 cameraPoint;
    private Vector3 direction;
    public float x = 0;
    public float y = 0;

    private float originalDistance;


    // Use this for initialization
    void Awake () {
        Vector3 oldPosition = new Vector3(target.position.x, target.position.y + 5, target.position.z - 5);
        transform.position = oldPosition;
        oldTargetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.LookAt(target);
        rotation = transform.rotation;
        originalDistance = checkDistance();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        float distance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            bool goodDistance = assertDistance();
            if (!goodDistance)
            {
                resetCamera();
            }
        }


        Vector3 newCameraPositionChange = new Vector3(target.position.x - oldTargetPosition.x, target.position.y - oldTargetPosition.y, target.position.z - oldTargetPosition.z);
        transform.position += newCameraPositionChange;
        oldTargetPosition = target.position;

        transform.RotateAround(target.position, new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * 150 * Time.deltaTime);

        transform.LookAt(target);   

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (Camera.main.fieldOfView < 100)
            {
                Camera.main.fieldOfView += 2;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (Camera.main.fieldOfView > 40)
            {
                Camera.main.fieldOfView -= 2;
            }
        }
    }

    bool assertDistance()
    {
        return originalDistance == checkDistance();
    }

    void resetCamera()
    {
        //Vector3 oldPosition = new Vector3(target.position.x, target.position.y + 5, target.position.z - 5);
        //transform.position = oldPosition;
        //oldTargetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
        //transform.LookAt(target);
    }


    private float checkDistance()
    {
        return Vector3.Distance(transform.position, target.position);
    }
}
