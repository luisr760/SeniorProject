using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This is for te firball power up collectable
/// the player may interact in the map to gain
/// projectile powers.
/// </summary>
public class PowerUps: Collectable {

	HUDEquipWeapon equipWeaponHUD;

	void Start() {
		// Will be changed to Equip property soon.
		equipWeaponHUD = GameObject.Find ("HUD_equipPanel_weapon").GetComponent<HUDEquipWeapon> ();
	}

	/// <summary>
	/// The equip ID for this collectable
	/// will be used to determine what animation to use
	/// if we decide to add one. 
	/// </summary>
	public int equipID;
	/// <summary>
	/// The projectile that will be shot out.
	/// </summary>
	public GameObject projectile;
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update () {
		rotateProjectile ();
	}
	/// <summary>
	/// This will be used when the fireball power up is collected
	/// by the player it will now set a valid projectile so the player can
	/// shoot when certain button is pressed.
	/// </summary>
	/// <param name="target">
	/// The target is usually the player object
	/// And will be used to get the Components/Scripts it has 
	/// to be mainpulated</param>
	override protected void OnCollect(GameObject target)
	{
		// Will be changed to Equip property soon.
		if(equipID == 1) 
			equipWeaponHUD.UpdateWeapon (HUDEquipWeapon.WEAPON_1);
		if(equipID == 2)
			equipWeaponHUD.UpdateWeapon (HUDEquipWeapon.WEAPON_2);
		if(equipID == 3)
			equipWeaponHUD.UpdateWeapon (HUDEquipWeapon.WEAPON_3);
		target.GetComponent<ScorePlayer> ().ScoreAdd (ScorePlayer.POINTS_HEALTH);
		target.GetComponent<ScorePlayer> ().ScoreAdd (ScorePlayer.POINTS_HEALTH);

		var collected = target.GetComponent<Equip> ();
		if (collected != null) {
			collected.EquippedItem = equipID;
		}
		var shootAvailable = target.GetComponent<ShootProjectile> ();
		if (shootAvailable != null) {
			shootAvailable.currentProjectile = projectile;
		}
	}
	/*
	 * This will rotate the projectile clockwise each frame 1 degree
	 * 
	*/
	void rotateProjectile()
	{
		transform.Rotate (Vector3.forward * -1);
	}
}
