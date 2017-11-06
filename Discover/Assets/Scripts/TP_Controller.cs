using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Controller : MonoBehaviour {

    public static CharacterController CharacterController;
    public Animator ani;
    public static TP_Controller Instance;

    // Use this for initialization
    void Awake () {
        CharacterController = GetComponent<CharacterController>(); // get the character controller component
        Instance = this; // store a reference to this controller class
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main == null) // if there is no main camera
        {
            return; // don't update so there's no null references
        }
        GetLocomotionInput();

        TP_Motor.Instance.UpdateMotor(); // force motor to update
	}

    void GetLocomotionInput ()
    {
        var deadZone = 0.1f;
        TP_Motor.Instance.MoveVector = Vector3.zero; // recalculate each frame, so zero the move vector first
        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
        {
            // Add value of vertical (forward/back) to Z
            ani.SetBool("Moving", true);
            TP_Motor.Instance.MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));
            TP_Motor.Instance.vert_axis = Input.GetAxis("Vertical");
        } 
        else
        {
            ani.SetBool("Moving", false);
        }
        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            // Add value of horizontal input (left/right) to X
            TP_Motor.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            TP_Motor.Instance.horiz_axis = Input.GetAxis("Horizontal");
        }
    }
}
