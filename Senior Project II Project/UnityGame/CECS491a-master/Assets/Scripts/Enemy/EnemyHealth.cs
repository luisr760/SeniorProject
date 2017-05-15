using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health;
	private Player player;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) {
			Destroy (gameObject);
		}	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.tag == "fireball") {
			Debug.Log ("Hello");
			if(health <= 0){
				Destroy (gameObject);
			}

			health--;
		}
		if (other.gameObject.tag == "ninjastar") {
			Debug.Log ("Hello");
			if(health <=0){
				Destroy (gameObject);
			}
				
			health--;
		}
		if (other.gameObject.tag == "bomb") {
			if(health <=0){
				Destroy (gameObject);
			}
			health-= 3;
		}
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<HealthPlayer> ().takeDamage (1);
		}
	}


}
