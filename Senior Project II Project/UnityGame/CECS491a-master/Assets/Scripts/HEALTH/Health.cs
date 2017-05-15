using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/// <summary>
/// This property gives any game object a health property. 
/// Use the Unity inspector to change HEALTH_MAX for adjusting
/// the amount of health each game entity should have.
/// <para></para>
/// <para></para>
/// Note: The player's game character has a more specific Health
/// property called HealthPlayer. This class extends functionality
/// for when the player loses/gains health or dies.
/// </summary>
/// 
public class Health : MonoBehaviour {
	
	public int HEALTH_MAX = 5; // 5 is default, set new value in Unity Inspector to overwrite  

	private int currentHealth;

	public void Start () {
		currentHealth = HEALTH_MAX;
	}

	/// <summary>
	/// Decreases the object's health by the supplied amount. Will not go below zero.
	/// The Die () method is called if health is at zero.
	/// </summary>
	/// <param name="damage">Integer amount to decrease health by.</param>
	public void takeDamage(int damage)
	{
		currentHealth = Mathf.Max(0, currentHealth - damage);
		if (currentHealth == 0)
			Die ();
	}

	/// <summary>
	/// Increases the object's health by the supplied amount. Will not go above HEALTH_MAX.
	/// </summary>
	/// <param name="increase">Integer amount to increase health by.</param>
	public void increaseHealth(int increase)
	{
		currentHealth = Mathf.Min(HEALTH_MAX, currentHealth + increase);
	}

	/// <summary>
	/// 
	/// </summary>
	public void Die () 
	{
		
	}

	/// <summary>
	/// Get object current health.
	/// </summary>
	/// <returns>Current health.</returns>
	public int CurrentHealth
	{
		get{ return currentHealth;}
		set{ currentHealth = value;}
	}

	public int getHealth(){
		return currentHealth;
	}
}
