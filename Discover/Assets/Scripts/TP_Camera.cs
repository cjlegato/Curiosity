using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class TP_Camera : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget;


    // Use this for initialization
    void Awake()
    {
		distanceFromTarget = Vector3.Distance(transform.position, target.position + Vector3.up);
    }


    // Update is called once per frame
    void LateUpdate()
    {
        
        //if (Physics.Raycast(transform.position, (forward), out hit))
        //{
        //    distance = hit.distance;
        //    print(distance + " " + hit.collider.gameObject.name);
        //}

        // 325 - 20
        //Debug.Log(transform.localEulerAngles);
        if (transform.localEulerAngles.x > 270) // 325 - 360
        {
            if (Input.GetAxis("Mouse Y") < 0) // going down
            {
                //    transform.RotateAround(target.position, new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                if (transform.localEulerAngles.x > 310)
                {
					transform.RotateAround(target.position + Vector3.up, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                }
            }
            else // going up
            {
				transform.RotateAround(target.position + Vector3.up, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
            }
        }

        else // 0 - 20
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
				transform.RotateAround(target.position + Vector3.up, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
            }
            else // going up, ok to do
            {
                //    transform.RotateAround(target.position, new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                if (transform.localEulerAngles.x < -30)
                {
					transform.RotateAround(target.position + Vector3.up, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                }
            }
        }
        if (checkDistance() != distanceFromTarget)
        {
			Vector3.MoveTowards(transform.position, target.position + Vector3.up, Mathf.Abs(checkDistance() - distanceFromTarget));
        }
        transform.LookAt(target);

        fixCamera();
    }

    private float checkDistance()
    {
		return Vector3.Distance(transform.position, target.position + Vector3.up);
    }

    void fixCamera()
    {
        //if (transform.localEulerAngles.x < 325 && transform.localEulerAngles.x > 20)
        //{
        //    transform.localEulerAngles = new Vector3(10, transform.localEulerAngles.y, transform.localEulerAngles.z);
        //}
    }
}
