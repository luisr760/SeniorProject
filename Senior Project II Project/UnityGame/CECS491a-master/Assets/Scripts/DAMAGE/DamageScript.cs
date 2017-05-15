using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {
	public int damage;
	public robotMove rob;
	private Player player;

	void Start() {
	
		rob = GameObject.FindGameObjectWithTag("robomove").GetComponent<robotMove>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {

			var player = other.GetComponent<Player> ();
			player.knockback = 1;
			player.knockbackCount = 0.1f;
			player.knockbackLength = 0.1f;

			if (transform.localScale.x < 0) {
				player.knockFromRight = false;
				Debug.Log ("Right");
				Debug.Log (transform.localScale.x);
			} else if (transform.localScale.x > 0) {
				player.knockFromRight = true;
				Debug.Log ("Left");
				Debug.Log (transform.localScale.x);
			}

			other.GetComponent<HealthPlayer> ().takeDamage (damage);
			rob.Damage ();
		}
	}
}
