using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class TP_Camera : MonoBehaviour
{
    public Transform target;


    // Use this for initialization
    void Awake()
    {
        
    }


    // Update is called once per frame
    void LateUpdate()
    {
        // 325 - 20
        if (transform.localEulerAngles.x > 270) // 325 - 360
        {
            if (Input.GetAxis("Mouse Y") < 0) // going down
            {
                //    transform.RotateAround(target.position, new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                if (transform.localEulerAngles.x > 325)
                {
                    transform.RotateAround(target.position, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                }
            }
            else // going up
            {
                transform.RotateAround(target.position, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
            }
        }

        else // 0 - 20
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                transform.RotateAround(target.position, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
            }
            else // going up, ok to do
            {
                //    transform.RotateAround(target.position, new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                if (transform.localEulerAngles.x < 20)
                {
                    transform.RotateAround(target.position, transform.right, Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
                }
            }
        }
    }
}
