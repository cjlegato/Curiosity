using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Animator ani;
    public float jumpforce;
    bool isGrounded;
    Rigidbody rb;
    AudioSource jump;
    AudioSource fall;
    bool falling;
    public bool canJump = false;

    // Use this for initialization
    void Start()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
        jump = GetComponents<AudioSource>()[2];
        fall = GetComponents<AudioSource>()[3];
        falling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < -1.0f && isGrounded == false)
        {
            //Play falling animation
            ani.Play("fall");
            falling = true;
        }
        else
        {
            falling = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            //Add some Vertical Velocity
            float x = rb.velocity.x;
            float z = rb.velocity.z;
            rb.velocity = new Vector3(x, 0, z);
            rb.AddForce(0, jumpforce, 0);
            jump.Play();
            isGrounded = false;
            //Play jump animation
            ani.Play("jump");
        }
        isGrounded = isonGround(rb);
        if(isGrounded && falling)
        {
            fall.Play();
            ani.Play("land");
            //Play landing animation
        }
    }

    bool isonGround(Rigidbody rb)
    {
        RaycastHit ray;
        if (Physics.Raycast(rb.transform.position + Vector3.up * 0.5f, Vector3.down, out ray, 0.9f))
        {
            if (ray.transform.gameObject.tag == "Terrain")
            {
                return true;
            }
        }
        return false;
    }
}
