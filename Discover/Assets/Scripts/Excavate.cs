using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excavate : MonoBehaviour
{
    public Animator ani;
	AudioSource aud;

    // Use this for initialization
    void Start()
    {
		aud = GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        //If E button is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Play Animation
			ani.Play("drill");
			aud.Play();
            Vector3 direction = transform.TransformDirection(Vector3.forward);
            RaycastHit objecthit;
            //Ray Cast Foreward, one rock unit
            if (Physics.Raycast(transform.position, direction, out objecthit, 10))
            {
                //If raycast returns true with a "destructable"
                if (objecthit.transform.gameObject.tag == "destructable")
                {
                    //Play Particle effect
                    //After animation is done Destroy that thing
                    Destroy(objecthit.transform.gameObject);
                }
            }
        }
    }
}
