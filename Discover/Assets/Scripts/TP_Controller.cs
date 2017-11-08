using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Controller : MonoBehaviour {

    public static CharacterController CharacterController;
    public Animator ani;
    public static TP_Controller Instance;

	AudioSource aud;
	bool moving = false;
    // Use this for initialization
    void Awake () {
		Cursor.visible = false;
        CharacterController = GetComponent<CharacterController>(); // get the character controller component
        Instance = this; // store a reference to this controller class
		aud = GetComponents<AudioSource>()[4];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Camera.main == null) // if there is no main camera
        {
            return; // don't update so there's no null references
        }
        GetMotionInput();

        TP_Motor.Instance.UpdateMotor(); // force motor to update
	}

    void GetMotionInput ()
    {
		//aud.volume = Input.GetAxis ("Vertical") * .23f;
		var deadZone = 0.1f;
        float forwardBackward = 1;
        TP_Motor.Instance.MoveVector = Vector3.zero; // recalculate each frame, so zero the move vector first
        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
        {
			if (!moving) {
				StopCoroutine ("Pause");
				StartCoroutine ("Play");
				moving = true;
			}
			forwardBackward = Input.GetAxis("Vertical") / Mathf.Abs(Input.GetAxis("Vertical"));
            // Add value of vertical (forward/back) to Z
			if (forwardBackward == 1) {
				ani.SetBool("Moving", true);
			} else if (forwardBackward == -1) {
				ani.SetBool("Reverse", true);
			}
            TP_Motor.Instance.MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));
            TP_Motor.Instance.vert_axis = Input.GetAxis("Vertical");
        } 
        else
        {
			if (moving) {
				StopCoroutine ("Play");
				StartCoroutine ("Pause");
				moving = false;
			}
			ani.SetBool("Moving", false);
			ani.SetBool("Reverse", false);
        }
        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            // Add value of horizontal input (left/right) to X
            TP_Motor.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal") * 2 * forwardBackward, 0, 0);
            TP_Motor.Instance.horiz_axis = Input.GetAxis("Horizontal");
        }
    }

	IEnumerator Play() {
		aud.Play ();
		aud.volume = 0f;
		while (aud.volume < 0.23f) {
			aud.volume += Time.deltaTime;
			yield return new WaitForFixedUpdate ();
		}
	}

	IEnumerator Pause() {
		while (aud.volume > 0f) {
			aud.volume -= Time.deltaTime;
			yield return new WaitForFixedUpdate ();
		}
		aud.Pause ();
	}
}
