using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour {
    public Transform target;
    private Vector3 oldTargetPosition;


    // Use this for initialization
    void Start () {
        Vector3 oldPosition = transform.position;
        oldTargetPosition = target.position;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newCameraPositionChange = new Vector3(target.position.x - oldTargetPosition.x, target.position.y - oldTargetPosition.y, target.position.z - oldTargetPosition.z);
        transform.position += newCameraPositionChange;
        oldTargetPosition = target.position;
        transform.rotation = target.rotation;
    }
}
