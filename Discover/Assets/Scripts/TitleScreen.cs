using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

	public GameObject[] titleScreenObjects;
	public float fadeTime;
	public Textbox textBox;
	bool titleScreen = true;
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKey && titleScreen) {
			titleScreen = false;
			foreach(GameObject obj in titleScreenObjects) {
				StartCoroutine("Fade", obj);
			}
			textBox.SetText("MESSAGE FROM NASA:\nHi Curiosity, we sent you some upgrades to help you in your search for water. They landed nearby, go grab them!");
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
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
