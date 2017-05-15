using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player is only game object that retains information on score. This class
/// provides methods for changing and tracking the score. Anytime this occurs, 
/// the class will also inform HUD_scoreValue object to update itself with the 
/// new score.
/// </summary>
public class ScorePlayer : MonoBehaviour {

	// Reference to text component owned by the HUD's scoreValue object.
	private HUDScore scoreHUD;
	// Actual score of game object
	private int score;
	HUDLives lives;
	// SCORE VALUES
	public static int POINTS_HEALTH = 5;
	public static int POINTS_COIN = 10;
	public static int POINTS_ENEMY_KILL_SMALL = 10;
	public static int POINTS_ENEMY_KILL_MEDIUM = 15;
	public static int POINTS_ENEMY_KILL_LARGE = 20;
	public static int POINTS_ENEMY_KILL_BOSS = 40;

	void Start () {
		// Initialize scoreHUD with game object HUD_scoreValue's HUDScore component.
		scoreHUD = GameObject.Find ("HUD_scoreValue").GetComponent<HUDScore> ();
		lives = GameObject.Find ("HUD_LivesValue").GetComponent<HUDLives> ();
		if (lives.Lives > 0) {
			score = PlayerData.playerData.getScore();
			scoreHUD.UpdateScore(PlayerData.playerData.getScore());
		}
	}

	void Update(){
		if (lives.Lives == 0) {
			score = 0;
			PlayerData.playerData.resetScore ();
			scoreHUD.UpdateScore (PlayerData.playerData.getScore ());
		}
	}

	/// <summary>
	/// Increase score by the given amount.
	/// </summary>
	/// <param name="amount">Integer value to increase score by.</param>
	public void ScoreAdd (int amount)
	{
		score += amount;
		updateScoreHUD ();
	}

	/// <summary>
	/// Set the score to the given value.
	/// </summary>
	/// <param name="amount">Integer value to set score to.</param>
	public void ScoreSet (int amount)
	{
		score = amount;
		updateScoreHUD ();
	}

	/// <summary>
	/// Decrease score by the given amount.
	/// </summary>
	/// <param name="amount">Integer value to decrease score by.</param>
	public void ScoreReduce (int amount)
	{
		score -= amount;
		updateScoreHUD ();
	}

	/// <summary>
	/// Gets the current score.
	/// </summary>
	/// <returns>The score.</returns>
	public int GetScore() {
		return score;
	}

	/// <summary>
	/// Calls the UpdateScore method in HUDScore with this classes current score variable. 
	/// Called by ScoreAdd, ScoreSet, and ScoreReduce.
	/// </summary>
	private void updateScoreHUD() 
	{
		scoreHUD.UpdateScore (score);
	}

}
