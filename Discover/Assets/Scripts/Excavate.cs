using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excavate : MonoBehaviour
{
    public Animator ani;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //If E button is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Play Animation
            ani.SetBool("Drilling", true);
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
        if (ani.GetBool("Drilling") == true)
        {
                if (ani.GetCurrentAnimatorStateInfo(0).length > ani.GetCurrentAnimatorStateInfo(0).normalizedTime)
            {
                ani.SetBool("Drilling", false);
            }
        }
    }
}
