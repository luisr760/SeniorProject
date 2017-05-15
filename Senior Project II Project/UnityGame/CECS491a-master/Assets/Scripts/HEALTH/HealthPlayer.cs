using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Extension of 'Health' class. See 'Health' in /scripts/properties/.
/// </summary>
public class HealthPlayer : Health {

	// Refernce to HUD's health script
	private HUDHealth healthHUD;
	// Initialized in the Unity inspector with all heart sprite images.
	public Sprite[] spritesHUDHealth;
	public AudioSource audioSource;
	public AudioClip audioClip1;
	public AudioClip audioClip2;

	HUDLives lives;

	void Start() {
		base.Start ();
		lives = GameObject.Find("HUD_LivesValue").GetComponent<HUDLives>();
		// Initialize healthHUD with game object HUD_health's HUDHealth script
		healthHUD = GameObject.Find ("HUD_health").GetComponent<HUDHealth> ();
		if (audioClip1 != null) {
			audioSource.clip = audioClip1;
			audioSource.Play ();
		}
	}

	void Update(){
		Debug.Log ("lives is..........." + lives.Lives);
	}

	public int getCurrentHealth(){
		return CurrentHealth;
	}
	/// <summary>
	/// See 'Health' class.
	/// </summary>
	public void takeDamage(int damage)
	{
		// Player doesn't take damage or Die in God Mode, obtained from Player script
		if (!GetComponentInParent<Player>().godMode) {
			base.takeDamage (damage);
			healthHUD.UpdateHealth (CurrentHealth);

			if (CurrentHealth  == 2 && audioSource != null) {
				audioSource.clip = audioClip2;
				audioSource.Play ();
				audioSource.pitch = .65f;
			}
			if (CurrentHealth == 0)
				Die ();
		}
	}

	/// <summary>
	/// See 'Health' class.
	/// </summary>
	public void increaseHealth(int increase)
	{
		base.increaseHealth (increase);
		healthHUD.UpdateHealth (CurrentHealth);

		if (CurrentHealth  == 3 && audioSource != null) {
			audioSource.clip = audioClip1;
			audioSource.Play ();
			audioSource.pitch = 1f;
		}
	}	

	/// <summary>
	/// See 'Health' class.
	/// </summary>
	public void Die()
	{

		PlayerData.playerData.setInCoinFalse ();
		GameObject checkPoint = nearestCheckpoint ();
		//HUDLives lives = GameObject.Find("HUD_LivesValue").GetComponent<HUDLives>();
		if (checkPoint != null && lives.Lives > 0) {
			transform.position = checkPoint.transform.position;
			lives.UpdateLives ();
			CurrentHealth = 5;
			healthHUD.resetHUDHealth (CurrentHealth);
			audioSource.clip = audioClip1;
			audioSource.Play ();
			audioSource.pitch = 1f;
		}else if (lives.Lives > 0) {
			GameObject start = GameObject.FindGameObjectWithTag ("Start");
			transform.position = start.transform.position;
			lives.UpdateLives ();
			CurrentHealth = 5;
			healthHUD.resetHUDHealth (CurrentHealth);
			audioSource.clip = audioClip1;
			audioSource.Play ();
			audioSource.pitch = 1f;
		}
		else {
			lives.UpdateLives ();
			base.Die ();
			string sceneName = SceneManager.GetActiveScene ().name;
			SceneManager.LoadScene (sceneName);
			PlayerData.playerData.resetLives ();
		}

	}
	public GameObject nearestCheckpoint()
	{
		GameObject[] checkpoints =GameObject.FindGameObjectsWithTag ("Checkpoint");
		GameObject nearestCheck = null;
		float shortestDistance = Mathf.Infinity;

		foreach (GameObject check in checkpoints) {
			Vector3 checkPosition = check.transform.position;
			float distance = (checkPosition - transform.position).sqrMagnitude;
			Checkpoint triggered = check.GetComponent<Checkpoint> ();
			if (distance < shortestDistance && triggered.isTriggered == true) {
				nearestCheck = check;
				shortestDistance = distance;
			}

		}
		return nearestCheck;

	}

}
