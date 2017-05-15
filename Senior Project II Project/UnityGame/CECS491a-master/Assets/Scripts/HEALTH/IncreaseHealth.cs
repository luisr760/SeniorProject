using UnityEngine;
using System.Collections;
/// <summary>
/// Will be used to attach to a potion prefab
/// so it can increase the players health
/// </summary>
public class IncreaseHealth : Collectable {
	/// <summary>
	/// The number to decide the increase of health
	/// The initiliazation is done in the Unity IDE.
	/// </summary>
	public int increase;

	/// <summary>
	/// Oncollecting the potion it will
	/// get the players health component and call increase health and 
	/// increase the health by the number.
	/// </summary>
	/// <param name="target">to check and make it is the player that interacted 
	/// with it</param>
	override protected void OnCollect(GameObject target)
	{
		if (target.tag == "Player") {
			target.GetComponent<ScorePlayer> ().ScoreAdd (ScorePlayer.POINTS_HEALTH);
			target.GetComponent<HealthPlayer> ().increaseHealth (increase);
		}
	}
}
