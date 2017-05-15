using UnityEngine;
using System;
using System.Collections;
/// <summary>
/// This enemy class will check if the enemy was hit 
/// by a fireball and be destroyed once it is dead
/// </summary>
public class Enemy : MonoBehaviour {
	/// <summary>
	/// The damage/health the enemy will have
	/// </summary>
	public int damage;
	private Player player;
	public Rigidbody2D rb2d;
	public robotMove rob;
	public HealthPlayer health;
	public float camShakeAmount = 0.1f;
	public float camShakeLength = 0.1f;
	public GameObject camera;
	private CameraShake camShake;

	void Start() {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		health = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthPlayer> ();
		rb2d = GetComponent<Rigidbody2D> ();
		rob = GameObject.FindGameObjectWithTag("robomove").GetComponent<robotMove>();

		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		camShake = camera.GetComponent<CameraShake> ();

		if (camShake == null) {
			Debug.LogError ("No CameraShake script found on Camera object.");

		}

	}
	/// <summary>
	/// This will have check if the enemy was hit buy a fireball
	/// and decrease the enemy health/damage and once it equals 0 then
	/// destroy the enemy, enemy is dead
	/// </summary>
	/// <param name="other">Other is to check if the object 
	/// colliding with it is a fireball
	/// </param>
	void Update()
	{
		if(damage  <= 0){
			Destroy (gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "fireball") {
			Debug.Log ("Hello");
			camShake.Shake (camShakeAmount, camShakeLength);
			if(damage <= 0){
				Destroy (gameObject);
			}
			if (gameObject.tag == "Enemy") {
				gameObject.GetComponent<Animation> ().Play ("enemy_flash");
			} else {
				gameObject.GetComponent<Animation> ().Play ("box_flash");
			}
			damage--;
		}
		if (other.gameObject.tag == "ninjastar") {
			Debug.Log ("Hello");
			camShake.Shake (camShakeAmount, camShakeLength);
			if(damage <=0){
				Destroy (gameObject);
			}

			if (gameObject.tag == "Enemy") {
				gameObject.GetComponent<Animation> ().Play ("enemy_flash");
			} else {
				gameObject.GetComponent<Animation> ().Play ("box_flash");
			}

			damage--;
		}
		if (other.gameObject.tag == "bomb") {
			camShake.Shake (camShakeAmount, camShakeLength);
			if(damage <=0){
				Destroy (gameObject);
			}
			if (gameObject.tag == "Enemy") {
				gameObject.GetComponent<Animation> ().Play ("enemy_flash");
			} else {
				gameObject.GetComponent<Animation> ().Play ("box_flash");

			}

			damage-= 3;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {

			var player = other.GetComponent<Player> ();
			player.knockback = 8;
			player.knockbackCount = 0.1f;
			player.knockbackCount = player.knockbackLength;

			if (transform.localScale.x < 0) {
				player.knockFromRight = false;
				Debug.Log ("Right");
				Debug.Log (transform.localScale.x);
			} else if (transform.localScale.x > 0) {
				player.knockFromRight = true;
				Debug.Log ("Left");
				Debug.Log (transform.localScale.x);
			}
			Debug.Log ("COLLISON!");
			Debug.Log (player);
			rob.Damage ();
			other.GetComponent<HealthPlayer> ().takeDamage (1);
		}
	}

}
