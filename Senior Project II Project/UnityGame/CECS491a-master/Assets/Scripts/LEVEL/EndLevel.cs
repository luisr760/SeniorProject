using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// When the player reaches the end flag
/// Future implementation it will go to the
/// next level, as of now it will return to main menu
/// </summary>
public class EndLevel : MonoBehaviour {

	WWWForm form;
	/// <summary>
	/// The number of the scene
	/// </summary>
    int SceneIndex;

	private bool endLevelReached = false;

	void Update() {
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other is the player tag
	/// so we know the player collided with the 
	/// end flag.</param>
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player" && !endLevelReached) {

			// Prevent from multiple collider trigger calls from happening
			endLevelReached = true;

			int numberOfScenes = SceneManager.sceneCountInBuildSettings;
			int currentScene = SceneManager.GetActiveScene ().buildIndex;
			// If there isn't another scene to load...
			if (currentScene == numberOfScenes - 1) {
				// ... hide the 'Next Level' button from end game screen
				GameObject.Find ("Next Level").SetActive(false);
			}

			// Initialize game HUD objects
			GameObject hudInGame = GameObject.Find ("HUD - In Game");
			GameObject hudEndGame = GameObject.Find ("HUD - End Game Summary");
			GameObject hudEndGameScoreText = GameObject.Find ("End Score Text");
			GameObject hhudInventory = GameObject.Find ("InventoryUI");
			// Player Model script
			robotMove rob = GameObject.FindGameObjectWithTag("robomove").GetComponent<robotMove>();
			// Player Score script
			ScorePlayer scoreManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ScorePlayer>();
			// HUD Timer script
			HUDTime hudTime = GameObject.Find("HUD_time").GetComponent<HUDTime>();

			// Deactivate HUD and replace with end game screen
			hudInGame.SetActive (false);
			hhudInventory.SetActive (false);
			// Stretch end game screen over the viewport
			Canvas c = hudEndGame.GetComponent<Canvas> ();
			c.renderMode = RenderMode.ScreenSpaceCamera;

			// Pause game
			Time.timeScale = 0.0000f;
			// Pause player
			rob.enabled = false;

			// Update Score Text
			Text scoreText =  hudEndGameScoreText.GetComponent<Text> ();
			// Temporary score calculation... Can get up to 200 extra points for how fast level is finished.
			int score = scoreManager.GetScore () + Mathf.Max(200 - hudTime.GetOverallSeconds(), 0);
			scoreText.text = "Score " + score;

			//submit scores to db at localhost:8081/submitScore
			PlayerData.playerData.setScore(score);
			SubmitScores();
		}

	}
	/// <summary>
	/// Sets the index/number of the scene.
	/// </summary>
	/// <param name="sceneIndex">Scene number.</param>
    public void setSceneIndex(int sceneIndex)
    {
        SceneIndex = sceneIndex;
    }

	/// <summary>
	/// Corotine to start RequestSubmit
	/// </summary>
	public void SubmitScores()
	{		
		StartCoroutine("RequestSubmit");
		Debug.Log("after StartCo Submit..");
	}

	/// <summary>
	/// Submits scores to Node endpoint /submitScores
	/// </summary>
	/// <returns>The submit.</returns>
	public IEnumerator RequestSubmit(){
		Debug.Log("Inside end of level");

		Debug.Log("Name : " +PlayerData.playerData.userName);
		Debug.Log("Score after flag : " + PlayerData.playerData.score);
		form = new WWWForm();
		form.AddField("userName", PlayerData.playerData.userName);
		form.AddField("score", ""+PlayerData.playerData.score);
		form.headers ["content-type"] = "application/json";

		Dictionary<string, string> headers = new Dictionary<string,string>();
		headers.Add ("Content-Type", "application/json");

		//for testing and avoiding real login comment out-----------------------------
		//uncomment for login to work work
		WWW w = new WWW("localhost:8081/submitScore", form.data, form.headers);
		yield return w; 
		Debug.Log(w.text.ToString());
		if(string.IsNullOrEmpty(w.error)){
			//success..
			if(w.text.ToLower().Contains("error")){
				Debug.Log(w.text.ToString());
				Debug.Log("error while submitting scores");
			}else{
				Debug.Log(w.text.ToString());
				//save the user file
				PlayerData.playerData.resetScore();

			}
		}else{
			//error
			Debug.Log(w.text.ToString());
		}
		//------------------------------------------------------------------------------

	}
}
