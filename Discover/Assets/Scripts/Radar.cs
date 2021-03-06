using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
	public Transform objToFind;
	Transform selfObj;
	public Text radarText;
	float distance;

	// Use this for initialization
	void Start ()
	{
		selfObj = this.gameObject.transform;
		distance = Vector3.Distance (objToFind.position, selfObj.position);
		radarText.text = "Water Detected : " + distance.ToString("F2") + " \n(In Meters)";
	}
	
	// Update is called once per frame
	void Update ()
	{
		selfObj = this.gameObject.transform;
		distance = Vector3.Distance (objToFind.position, selfObj.position);
		radarText.text = "Water Detected : " +  distance.ToString("F2") + " \n(In Meters)";
	}
}

