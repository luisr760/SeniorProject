using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script gets the 'canvas' component attached to the 'HUD' game object
/// then updates its render mode property to overlay over the screen space.
/// This could be done using the inspector before runtime but the overlay would
/// then be hard to adjust. This allows the HUD to be moved away from other game
/// objects for easy editing while still overlaying the screen at runtime.
/// </summary>
public class OverlayInitializer : MonoBehaviour {

	void Start () {

		Canvas c = GetComponentInParent<Canvas> ();
		c.renderMode = RenderMode.ScreenSpaceCamera;

		// Temporarily doing CreateLayout() here for the inventory,
		// otherwise slot locations are miscalculated
		GameObject inventory = GameObject.Find("InventoryUI");
		// Only call CreateLayout() if this game object owns the inventoryUI game object
		if (inventory.transform.parent.name == transform.name) {
			inventory.GetComponent<Inventory> ().CreateLayout ();
		}
	}
}
