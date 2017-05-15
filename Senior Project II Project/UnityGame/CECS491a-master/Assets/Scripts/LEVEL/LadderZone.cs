using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {

	Player thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<Player> ();
	}


	void OnTriggerEnter2D (Collider2D other) {

		if (other.name == "Player") {
		
			thePlayer.onLadder = true;
			Debug.Log ("ON LADDER");

		}

	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.name == "Player") {

			thePlayer.onLadder = false;
			Debug.Log ("OFF LADDER");
		}

	}
}
