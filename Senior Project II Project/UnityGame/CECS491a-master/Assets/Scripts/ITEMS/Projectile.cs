using UnityEngine;
using System.Collections;
/// <summary>
/// The any projectile that will be shot out when 
/// the player has a Power up.
/// </summary>
public class Projectile : MonoBehaviour {
	/// <summary>
	/// The initial velocity of the fireball when shot out
	/// </summary>
	public Vector2 initVelocity = new Vector2 (50,-50);
	/// <summary>
	///  Is used to add physics functionlity 
	/// </summary>
	private Rigidbody2D rigid2D;

	/// <summary>
	/// Get the components of the rigid body
	/// Includes physics components
	/// </summary>
	void Awake()
	{
		rigid2D = GetComponent<Rigidbody2D> ();
	}
	/// <summary>
	/// At the start initialize the velocity of the fireball projectile 
	/// </summary>
	void Start () {
		//Transform- used to store and manipulate the position, rotation and scale 
		var startVelocityX = initVelocity.x * transform.localScale.x;
		rigid2D.velocity = new Vector2 (startVelocityX, rigid2D.velocity.y);

	}
	/// <summary>
	/// Raises the collision enter2 d event.
	/// when the fireball collides with something it will be destroyed
	/// whether it'd be a wall, enemy or any object with a collider
	/// </summary>
	/// <param name="target">Target</param>
	void OnCollisionEnter2D(Collision2D target)
	{
		Destroy (gameObject);
	}
}
