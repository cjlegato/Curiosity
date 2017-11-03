using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public enum triggerType {Jump, Drill, Radar, Win}
	public triggerType Type;
	public Textbox textbox;

	//This checks if the player enters the trigger
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			switch (Type) {
			case triggerType.Jump:
				JumpTrigger ();
				break;
			case triggerType.Drill:
				DrillTrigger ();
				break;
			case triggerType.Radar:
				RadarTrigger ();
				break;
			case triggerType.Win:
				WinTrigger ();
				break;
			}
		}
	}

	//Starting here is what to do for each specific trigger, usually consisiting of a text box and changing
	// a bool somewhere probably

	void JumpTrigger() {
		textbox.SetText ("-HYDRAULIC BOOSTER-\nNASA has sent you a new upgrade, allowing you to jump.");
	}

	void DrillTrigger() {
		textbox.SetText ("-EXTRATERRESTRIAL EXCAVATION DEVICE-\nNASA has sent you a new upgrade, giving you the ability to drill through weaker rocks.");
	}

	void RadarTrigger() {
		textbox.SetText ("-DIHYDROGEN MONOXIDE DETECTION SYSTEM-\nNASA has sent you a new upgrade, which will tell you your current distance from a source of water.");
	}

	void WinTrigger() {
		textbox.SetText ("MESSAGE FROM NASA:\nCongratulations Curiosity, you have found a source of water! But your job is still not done, as there is still much more to discover on Mars. Good Luck!");
	}
}
