using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTime : MonoBehaviour {

	// Reference to Text component
	Text timeField;
	private int overallSeconds = 0;

	void Start () {
		// Initialize timeField with Text component of HUD_time
		timeField = GetComponentInParent<Text> ();
	}

	/// <summary>
	/// Updates the HUD time text. Automatically formats.
	/// </summary>
	/// <param name="time">Float value of time in seconds to update HUD with. 
	/// This method will auto format the time value to fit into ##:##:## </param>
	public void UpdateTime(float time)
	{
		overallSeconds = (int) time;

		int minutes = 0;
		int seconds = 0;
		int milliseconds = 0;

		seconds = Mathf.FloorToInt (time);


		if (time >= 60) {
			minutes = Mathf.FloorToInt (seconds / 60);
			seconds -= minutes * 60;
			milliseconds =  Mathf.FloorToInt (100 * (time - Mathf.Floor (time)));

			// A zero is put in if seconds is less than 10
			string zeroSpace = "";
			if (seconds < 10) {
				zeroSpace = "0";
			} else {
				zeroSpace = "";	
			}
			// A zero is put in if if milliseconds is less than 10
			string zeroSpaceMilli = "";
			if (milliseconds < 10) {
				zeroSpaceMilli = "0";
			} else {
				zeroSpaceMilli = "";	
			}

			timeField.text = minutes + ":" + zeroSpace + seconds + ":" + zeroSpaceMilli + milliseconds;
		} else {
			seconds = seconds % 60;
			milliseconds =  Mathf.FloorToInt (100 * (time - Mathf.Floor (time)));

			// A zero is put in if if milliseconds is less than 10
			string zeroSpace = "";
			if (milliseconds < 10) {
				zeroSpace = "0";
			} else {
				zeroSpace = "";	
			}

			timeField.text = seconds + ":" + zeroSpace + milliseconds;
		}
	}

	public int GetOverallSeconds() {
		return overallSeconds;
	}
}
