using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {

	public AudioClip goldCollectSound;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	/// <summary>
	/// Called by parent class Collectable. Handles collider interaction.
	/// </summary>
	/// <param name="target">The game object that intersected the item. (The player)</param>
	override protected void OnCollect(GameObject target)
	{
		// Adds score
		target.GetComponent<ScorePlayer> ().ScoreAdd (ScorePlayer.POINTS_COIN);
		// Plays coin collect sound
		AudioSource.PlayClipAtPoint(goldCollectSound, Camera.main.transform.position);
	}
}
