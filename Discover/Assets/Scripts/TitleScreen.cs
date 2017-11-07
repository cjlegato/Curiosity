using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

	public GameObject[] titleScreenObjects;
	public Transform player;
	public GameObject camera;
	public float rotateSpeed;
	public float fadeTime;

	bool titleScreen = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (titleScreen) {
			camera.transform.RotateAround(player.position, Vector3.up, rotateSpeed * Time.deltaTime);
		}

		if (Input.anyKey) {
			titleScreen = false;
			foreach(GameObject obj in titleScreenObjects) {
				StartCoroutine("Fade", obj);
			}
		}
	}

	IEnumerator Fade(GameObject obj) {
		Text text = obj.GetComponent<Text>();
		if (text != null) {
			while (text.color.a > 0) {
				//float newa = text.color.a - (1/fadeTime);
				text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (1/fadeTime) * Time.deltaTime);
				yield return new WaitForFixedUpdate();
			}
		}
	}
}
