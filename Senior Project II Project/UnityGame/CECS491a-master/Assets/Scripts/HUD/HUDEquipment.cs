using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDEquipment : MonoBehaviour {

	Text equipmentField;

	// Equipment Names
	public static string JETPACK = "Jetpack";

	void Start () {

		// Initialize equipmentField with Text component of HUD_equipText
		equipmentField = transform.FindChild("HUD_equipText").GetComponent<Text>();
	}

	/// <summary>
	/// Updates the HUD equipment equipped text.
	/// </summary>
	/// <param name="equipment">Formatted names are available as static fields in HUDEquipment.</param>
	public void UpdateEquipment(string equipment) 
	{
		equipmentField.text = equipment;
	}
}
