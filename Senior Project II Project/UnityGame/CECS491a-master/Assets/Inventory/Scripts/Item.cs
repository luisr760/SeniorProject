using UnityEngine;
using System.Collections;

public enum ItemType {NINJASTAR, FIREBALL, GRENADE};

public class Item : MonoBehaviour 
{
    /// <summary>
    /// The current item type
    /// </summary>
    public ItemType type;

	public ShootProjectile current;

	public GameObject[] projectilePrefabs;

	public HUDEquipWeapon equip;

    /// <summary>
    /// The item's neutral sprite
    /// </summary>
    public Sprite spriteNeutral;

    /// <summary>
    /// The item's highlighted sprite
    /// </summary>
    public Sprite spriteHighlighted;

    /// <summary>
    /// The max amount of times the item can stack
    /// </summary>
    public int maxSize;

    /// <summary>
    /// Uses the item
    /// </summary>
    public void Use()
    {
		
        switch (type) //Checks which kind of item this is
        {
		case ItemType.NINJASTAR:
			current = GameObject.Find ("Player").GetComponent<ShootProjectile> ();
			equip = GameObject.FindGameObjectWithTag ("Equip").GetComponent<HUDEquipWeapon> ();
			Debug.Log ("Current: " + current.currentProjectile);
			Debug.Log (projectilePrefabs [1]);
			current.currentProjectile = projectilePrefabs [1];
			equip.UpdateWeapon ("Ninja Star");
			Debug.Log ("I just used a ninja star");
            break;
		case ItemType.FIREBALL:
			current = GameObject.Find ("Player").GetComponent<ShootProjectile> ();
			equip = GameObject.FindGameObjectWithTag ("Equip").GetComponent<HUDEquipWeapon> ();
			Debug.Log ("Current: " + current.currentProjectile);
			Debug.Log (projectilePrefabs [0]);
			current.currentProjectile = projectilePrefabs [0];
			equip.UpdateWeapon ("Fireball");
			Debug.Log("I just used a fireball");
            break;
		case ItemType.GRENADE:
			current = GameObject.Find ("Player").GetComponent<ShootProjectile> ();
			equip = GameObject.FindGameObjectWithTag ("Equip").GetComponent<HUDEquipWeapon> ();
			current.currentProjectile = projectilePrefabs [2];
			equip.UpdateWeapon ("Grenade");
			break;
        }

	

    }

}
