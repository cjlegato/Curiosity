using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class TP_Camera : MonoBehaviour {

    private CharacterController John;
    public Transform target;

	// Use this for initialization
	void Awake () {
    Vector3 newPosition = new Vector3(target.position.x, target.position.y + 5, target.position.z + 5);
    transform.position = newPosition;
	}


	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        if (Input.GetMouseButton(1)) { // if right mouse button is held
            transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * 150 * Time.deltaTime);
            transform.RotateAround(transform.parent.position, new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * 150 * Time.deltaTime);
        }
	}

}
