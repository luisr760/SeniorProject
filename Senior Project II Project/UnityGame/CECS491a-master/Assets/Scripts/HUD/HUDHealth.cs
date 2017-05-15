using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealth : MonoBehaviour {

	// Reference to image component owned by the HUD's health object.
	private Image imageHUDHealth;
	// Initialized in the Unity inspector with all heart sprite images.
	public Sprite[] spritesHUDHealth;

	void Start () {
		// Initialize imageHUDHealth with Image component of HUD_health
		imageHUDHealth = GameObject.Find ("HUD_health").GetComponent<Image> ();
	}
		
	/// <summary>
	/// Updates the HUD health image. A sprite sheet corresponds to the 6 different
	/// health amounts.
	/// </summary>
	/// <param name="health">New health amount. Value can be 0 through 5 (or number of sprite sheet images)</param>
	public void UpdateHealth(int health) 
	{
		Debug.Log ("Updated Health");
		if (health >= 0 || health <= spritesHUDHealth.Length)
			imageHUDHealth.sprite = spritesHUDHealth [health];
	}
	public void resetHUDHealth(int newHealth)
	{
		imageHUDHealth.sprite = spritesHUDHealth [newHealth];
	}
}
