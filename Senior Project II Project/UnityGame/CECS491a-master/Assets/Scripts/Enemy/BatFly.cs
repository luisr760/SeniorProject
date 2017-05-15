using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFly : MonoBehaviour {
	
	private HealthPlayer player;
	private float timeElapsed = 0f;
	public float flyDelay = 5f;
	Vector2 original;
	Vector2 playerFirst;
	int count;
	bool reached;
	public float stop;
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthPlayer> ();
		//reached = false;
		original = transform.position;
		//stop = transform.position.y - 6f;
	}
	void Update()
	{
		if (/*transform.position.y != stop &&*/ Mathf.Abs (transform.position.x - player.transform.position.x) <= 10f /*&& transform.position.x - player.transform.position.x >= 0*/) {
			
			//transform.position = Vector2.MoveTowards (transform.position, new Vector2 (transform.position.x, stop), .2f);
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, .05f);
		} else {
			transform.position = Vector2.MoveTowards (transform.position,original, .05f);
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			player.takeDamage (1);
		}
	}

}
