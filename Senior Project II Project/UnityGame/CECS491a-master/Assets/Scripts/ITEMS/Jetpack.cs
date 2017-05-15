using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : Collectable {

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
		robotMove rMove = target.GetComponentInChildren<robotMove> ();
		rMove.JetpackEquipped (true);
		GameObject.Find ("HUD_equipPanel_equipment").GetComponent<HUDEquipment> ().UpdateEquipment(HUDEquipment.JETPACK);
	}
}
