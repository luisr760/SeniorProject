using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class HUDScore : MonoBehaviour {

	// Reference to Text component
	Text scoreField;

	void Start () {
		// Initialize scoreField with Text component of HUD_scoreValue
		scoreField = GetComponentInParent<Text> ();
	}

	/// <summary>
	/// Updates the HUD score text.
	/// </summary>
	/// <param name="score">New score amount.</param>
	public void UpdateScore(int score) 
	{
		scoreField.text = "" + score;
		PlayerData.playerData.setScore(score);
	}

}
