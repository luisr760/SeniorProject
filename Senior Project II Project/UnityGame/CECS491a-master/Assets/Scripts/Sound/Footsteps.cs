using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	public AudioClip footstepSound;
	public double STEP_RATE = 0.5;

	private double stepTimer = 0;

	private bool toggled = true;

	// Use this for initialization
	void Start () {
		stepTimer = STEP_RATE;
	}
	
	// Update is called once per frame
	void Update () {
		if (toggled) {
			// Get player movement
			Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			// Check if moving vertically
			if (input.x == 1 || input.x == -1) {
				// Countdown step timer
				stepTimer -= Time.deltaTime;
				// Loop step timer back to STPE_RATE starting number and play sound when countdown hits zero
				if (stepTimer < 0) {
					stepTimer = STEP_RATE;
					AudioSource.PlayClipAtPoint (footstepSound, transform.position);
				}
			} else if (input.x == 0) {
				// If player has stopped moving horizontally, reset timer
				stepTimer = STEP_RATE;
			}
		} else {
			stepTimer = STEP_RATE;
		}
	}

	public void isToggled(bool state) {
		toggled = state;
	}

}
