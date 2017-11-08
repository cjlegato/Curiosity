using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excavate : MonoBehaviour
{
    public Animator ani;
	public GameObject particles;
	AudioSource drill;
	AudioSource destroy;

    // Use this for initialization
    void Start()
    {
		drill = GetComponents<AudioSource>()[0];
		destroy = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        //If E button is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Play Animation
			ani.Play("drill");
			drill.Play();
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
					StartCoroutine("Break", objecthit.transform.gameObject);
                }
            }
        }
    }

	IEnumerator Break(GameObject rock) {
		yield return new WaitForSeconds(1f);
		destroy.Play();
		GameObject boom = Instantiate(particles, rock.transform.position + Vector3.up, rock.transform.rotation);
		Destroy(rock);
		yield return new WaitForSeconds(3f);
		Destroy(boom);
	}
}
