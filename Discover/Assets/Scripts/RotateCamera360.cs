using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera360 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        { // if right mouse button is held
          transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * 150 * Time.deltaTime);
        }
    }
}
