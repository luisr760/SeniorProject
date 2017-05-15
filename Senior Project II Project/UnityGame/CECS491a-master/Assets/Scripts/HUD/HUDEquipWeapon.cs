using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDEquipWeapon : MonoBehaviour {

	Text weaponField;

	// Weapon Names
	public static string WEAPON_1 = "Fireball";
	public static string WEAPON_2 = "Ninja Star";
	public static string WEAPON_3 = "Grenade";
	void Start () {

		// Initialize weaponField with Text component of HUD_equipText
		weaponField = transform.FindChild("HUD_equipText").GetComponent<Text>();

	}

	/// <summary>
	/// Updates the HUD weapon equipped text.
	/// </summary>
	/// <param name="weapon">Formatted names are available as static fields in HUDEquipWeapon.</param>
	public void UpdateWeapon(string weapon) 
	{
		weaponField.text = weapon;
	}

}
