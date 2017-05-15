using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {
	public int damage;

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Debug.Log ("Spike Script");
			other.GetComponent<HealthPlayer> ().takeDamage (damage);
			//StartCoroutine (other.GetComponent<PlayerManager> ().Knockback (0.02f, 50, other.GetComponent<PlayerManager> ().transform.position));
		}
	}
}
