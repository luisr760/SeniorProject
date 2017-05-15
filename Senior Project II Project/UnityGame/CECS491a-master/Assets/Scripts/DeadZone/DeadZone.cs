using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour {

	private Player player;
	private HUDHealth hudHealth;
	private GameObject start;
	private HUDLives lives;
	private HealthPlayer health;
	void Start () 
	{
		player = GameObject.Find ("Player").GetComponent<Player> ();
		hudHealth = GameObject.Find("HUD_health").GetComponent<HUDHealth>();
		start = GameObject.Find("GameStart");
		lives = GameObject.Find("HUD_LivesValue").GetComponent<HUDLives>();
		health = GameObject.Find("Player").GetComponent<HealthPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && player.IsJetting == false) {
			GameObject checkPoint = player.nearestCheckpoint();
			if (checkPoint != null && lives.Lives > 1) {
				player.transform.position = checkPoint.transform.position;
				lives.UpdateLives ();
				health.CurrentHealth = 5;
				hudHealth.resetHUDHealth (health.CurrentHealth);
			} else if (lives.Lives > 1) {
				Debug.Log ("Hello LIVEs");
				player.transform.position = start.transform.position;
				lives.UpdateLives ();
				health.CurrentHealth = 5;
				hudHealth.resetHUDHealth (health.CurrentHealth);
			} else {
				lives.UpdateLives ();
				string currentScene = SceneManager.GetActiveScene ().name;
				Debug.Log (currentScene);
				SceneManager.LoadScene (currentScene);
				PlayerData.playerData.resetLives ();
			}

		}	
	}
}
