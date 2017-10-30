using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Moving", true);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetBool ("Moving", false);
		}
	}
}
