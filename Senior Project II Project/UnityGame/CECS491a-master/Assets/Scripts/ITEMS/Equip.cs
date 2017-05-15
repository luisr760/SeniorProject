using UnityEngine;
using System.Collections;

/// <summary>
/// The Equip class will be used better for future development
/// It will be used to differentiate what weapon and/or power up
/// they are currently using and will be used to decide which animation
/// will be used for the character. 
/// </summary>
public class Equip : AbstractBehavior {

	/// <summary>
	/// This integer will tell what collectable id 
	/// the player has.
	/// </summary>
	private int equippedItem;

	/// <summary>
	/// Gets and sets the equipped item.
	/// </summary>
	/// <value>The equipped item.</value>
	public int EquippedItem {
		get{ return equippedItem; }
		set{ equippedItem = value; }
	}
}
