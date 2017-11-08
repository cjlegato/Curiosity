using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour {


	public Text realText;
	public GameObject background;
	string currentString, finalString;

	// Use this for initialization
	void Start () {
		realText.enabled = false;
		background.GetComponent<Image>().enabled = false;
	}


	// Call this when you want to display text, with the argument of
	// the new text to be displayed
	public void SetText (string newText) {
		loadingText = true;
		realText.enabled = true;
		background.GetComponent<Image>().enabled = true;
		finalString = newText;
		currentString = "<color=#00000000>" + finalString + "</color>";
		index = 0;
		realText.text = currentString;
	}
}
