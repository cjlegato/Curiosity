using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour {


	public Text realText;
	public Image background;

	public float revealSpeed;
	public float displayTime;

	string currentString, finalString;
	int index;
	bool loadingText;
	AudioSource aud;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource>();
		realText.enabled = false;
		background.enabled = false;
		//SetText ("This is a test text wooooooooo.");
	}


	// Call this when you want to display text, with the argument of
	// the new text to be displayed
	public void SetText (string newText) {
		if (loadingText) {
			StopCoroutine ("LoadText");
		}
		loadingText = true;
		realText.enabled = true;
		background.enabled = true;
		finalString = newText;
		currentString = "<color=#00000000>" + finalString + "</color>";
		index = 0;
		realText.text = currentString;
		StartCoroutine ("LoadText");
	}

	// Reveals the text, one letter at a time
	IEnumerator LoadText() {
		while (index < finalString.Length) {
			if (finalString [index] == '\n') {
				index += 1;
				yield return new WaitForSeconds (.5f);
			}
			aud.pitch = Random.Range(0.7f, 1.3f);
			aud.Play();
			currentString = finalString.Substring (0, index + 1) + "<color=#00000000>" + finalString.Substring (index + 1) + "</color>";
			realText.text = currentString;
			index += 1;
			yield return new WaitForSeconds (revealSpeed);
		}
		realText.text = finalString;
		yield return new WaitForSeconds(displayTime);
		realText.enabled = false;
		background.enabled = false;
		loadingText = false;
	}
}
