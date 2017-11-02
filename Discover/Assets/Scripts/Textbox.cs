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

	// Use this for initialization
	void Start () {
		
		realText.enabled = false;
		background.enabled = false;
		SetText ("This is a test text wooooooooo.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Call this when you want to display text, with the argument of
	// the new text to be displayed
	void SetText (string newText) {
		realText.enabled = true;
		background.enabled = true;
		finalString = newText;
		currentString = "<color=#00000000>" + finalString + "</color>";
		index = 0;
		realText.text = currentString;
		StartCoroutine("LoadText");
	}

	// Reveals the text
	IEnumerator LoadText() {
		while (index < finalString.Length) {
			currentString = finalString.Substring(0, index) + "<color=#00000000>" + finalString.Substring(index) + "</color>";
			realText.text = currentString;
			index += 1;
			yield return new WaitForSeconds(revealSpeed);
		}
		yield return new WaitForSeconds(displayTime);
		realText.enabled = false;
		background.enabled = false;
	}
}
