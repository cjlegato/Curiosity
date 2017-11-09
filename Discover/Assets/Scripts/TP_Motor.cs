using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Reference for elements of movement controls: https://www.3dbuzz.com/training/view/3rd-person-character-system/simple-character-system
public class TP_Motor : MonoBehaviour {

    public static TP_Motor Instance;
    public float MoveSpeed = 0.00000000001f;
    public Vector3 MoveVector { get; set; }
    public Rigidbody robotRigidBody;
    public float vert_axis;
    public float horiz_axis;


    // Use this for initialization
    void Awake () {
        Instance = this;
        // idea reference : https://forum.unity.com/threads/how-to-prevent-the-car-from-tilting-flipping-or-constrain-it-to-x-z-axes.76488/
        robotRigidBody = GetComponent<Rigidbody>(); // get the reference to the rigid body
        robotRigidBody.centerOfMass = new Vector3(0, -2, 0);
    }
	
	// Update is called once per frame
	public void UpdateMotor() {
        SnapAlignCharacterWithCamera();
        ProcessMotion();


    }

    void ProcessMotion()
    {
        Vector3 levelVector = Vector3.ProjectOnPlane(transform.TransformDirection(Vector3.forward.normalized), new Vector3(0, 1, 0));
        MoveVector = transform.TransformDirection(MoveVector); // transforms user input from local to world space
        if (MoveVector.magnitude > 1)
        {
            MoveVector = Vector3.Normalize(MoveVector); // normalize the vector
        }
        MoveVector *= MoveSpeed; // increase magnitude by speed
        MoveVector *= Time.deltaTime; // spread out over seconds

        if (MoveVector != Vector3.zero)
        {
            robotRigidBody.MovePosition(robotRigidBody.position + MoveVector);
        }
    }

    void SnapAlignCharacterWithCamera()
    {
        Vector3 levelVector = Vector3.ProjectOnPlane(transform.TransformDirection(Vector3.forward.normalized), new Vector3(0, 1, 0));
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

        robotRigidBody.AddForce(transform.TransformDirection(Vector3.forward.normalized) - levelVector);

    }
}
