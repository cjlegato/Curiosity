using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar : MonoBehaviour
{
	public Transform objToFind;
	Transform selfObj;
	float distance;

	// Use this for initialization
	void Start ()
	{
		selfObj = this.gameObject.transform;
		distance = Vector3.Distance (objToFind.position, selfObj.position);
		Debug.Log (distance);
	}
	
	// Update is called once per frame
	void Update ()
	{
		selfObj = this.gameObject.transform;
		distance = Vector3.Distance (objToFind.position, selfObj.position);
	}
}

