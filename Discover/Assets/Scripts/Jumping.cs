using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Animator ani;
    Vector3 jump;
    public float jumpforce;
    bool isGrounded;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Add some Vertical Velocity
            float x = rb.velocity.x;
            float z = rb.velocity.z;
            rb.velocity = new Vector3(x, 0, z);
            rb.AddForce(0, jumpforce, 0);
            isGrounded = false;
            //Play jump animation
            //ani.SetBool("JumpingUP", true);
            //At top play fall animation
            //ani.SetBool("JumpingUP", false);
            //ani.SetBool("JumpingDOWN", true);
            //At bottom play hit animation
            //ani.SetBool("JumpingDOWN", false);
            //ani.SetBool("hitground", true);
        }
        isGrounded = isonGround(rb);
    }

    bool isonGround(Rigidbody rb)
    {
        RaycastHit ray;
        if (Physics.Raycast(rb.transform.position + Vector3.up * 0.5f, Vector3.down, out ray, 0.75f))
        {
            if (ray.transform.gameObject.tag == "Terrain")
            {
                return true;
            }
        }
        return false;
    }
}
