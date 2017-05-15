using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDLives : MonoBehaviour {

	private int lives;
	Text livesField;

	void Start () {
		lives = PlayerData.playerData.getLives ();
		livesField = GetComponentInParent<Text> ();
		livesField.text = lives.ToString();
	}
	
	public void UpdateLives() 
	{
		if (lives > 0) {
			lives -= 1;
			livesField.text = lives.ToString ();
			PlayerData.playerData.setLives (lives);
		}
	}
	public int Lives {
		get{ return lives;}
		set{ lives = value;}
	}
}
