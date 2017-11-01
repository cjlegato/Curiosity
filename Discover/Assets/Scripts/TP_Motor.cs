using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Motor : MonoBehaviour {

    public static TP_Motor Instance;
    public float MoveSpeed = 10f;
    public Vector3 MoveVector { get; set; }

	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	public void UpdateMotor() {
        SnapAlignCharacterWithCamera();
        ProcessMotion();

    }

    void ProcessMotion()
    {
        MoveVector = transform.TransformDirection(MoveVector); // transforms user input from local to world space
        if (MoveVector.magnitude > 1)
        {
            MoveVector = Vector3.Normalize(MoveVector); // normalize the vector
        }
        MoveVector *= MoveSpeed; // increase magnitude by speed
        MoveVector *= Time.deltaTime; // spread out over seconds
        TP_Controller.CharacterController.Move(MoveVector); // send back to the controller to make it move
    }

    void SnapAlignCharacterWithCamera()
    {
        float x_val = MoveVector.x;
        MoveVector -= new Vector3(MoveVector.x, 0, 0);
        if (x_val != 0 && MoveVector.z >= 0) // if we are moving
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + x_val, transform.eulerAngles.z); // rotate the player with the camera
        } 
        else // going backwards, wheels should go the other way
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - x_val, transform.eulerAngles.z); // rotate the player with the camera
        }
    }
}
