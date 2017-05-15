using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDetect : MonoBehaviour {

	private BatFly bat;
	private Player player;
	private GameObject batObj;
	void Start () 
	{
		bat = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatFly> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

	}
	

	void OnTriggerEnter2D(Collider2D other)
	{/*
		if (other.gameObject.tag == "Player") 
		{
			batObj = bat.batObj;
			Vector2 playerPos = player.transform.position;
			batObj.transform.position = Vector2.MoveTowards (batObj.transform.position, player.transform.position, .2f);
		}*/
	}
	/*
	void OnTriggerStay2D(Collider other)
	{
		if (other.gameObject.tag == "Player") {

			 
			Vector2 playerPos = player.transform.position;
			float playerX = playerPos.x;
			float playerY = playerPos.y;
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, .2f);
	

			if (bat.BatStart.x == player.transform.position.x && bat.BatStart.x == player.transform.position.y) {
				transform.position = Vector2.MoveTowards (transform.position, bat.BatStart, .2f);
			}
		}
	}*/
}
