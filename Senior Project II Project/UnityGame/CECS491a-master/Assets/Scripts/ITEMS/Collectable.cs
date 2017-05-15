using UnityEngine;
using System.Collections;


/// <summary>
/// The Collectable class is used as the parent class
/// for any kind of collectable. Whether it'd be a weapon
/// or item.
/// </summary>
public class Collectable : MonoBehaviour {

	/// <summary>
	/// The target tag player will be used if the player 
	/// interacted with a collectable.
	/// </summary>
	public string targetTag = "Player";

	/// <summary>
	/// Raises the trigger enter2d event.
	/// This calls the OnCollect method which will do
	/// whatever the collectable item does and then destroy because 
	/// it was picked up or used
	/// </summary>
	/// <param name="target">target parameter is the collider that
	/// interacts with the collectable. In most cases the target will
	/// be the player</param>
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == targetTag) {
			OnCollect (target.gameObject);
			OnDestroy ();
		}
	}

	/// <summary>
	/// The OnCollect will be used when player interacts
	/// with a collectable. When collected it will do whatever
	/// the child class decide to override this method with.
	/// </summary>
	/// <param name="target"></param>
	protected virtual void OnCollect(GameObject target){
	}

	/// <summary>
	/// Will destroy the collectable item when it
	/// needs to be destroyed.Usually when collected.
	/// </summary>
	protected virtual void OnDestroy (){
		Destroy (gameObject);
	}

}
