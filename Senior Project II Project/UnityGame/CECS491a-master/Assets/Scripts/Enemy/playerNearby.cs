using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNearby : MonoBehaviour {

	public Player player;
	public GameObject fEnemy;
	public Animator animator;
	public Animation anim;
	public GameObject projectile;
	public GameObject LQ;
	private float timeElapsed = 0f;
	public float projectileDelay = 5f;
	void Wake()
	{
		animator = GetComponent<Animator> ();
		anim = GetComponent<Animation> ();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
		//projectile = GameObject.FindGameObjectWithTag("spikey");
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x - player.transform.position.x < 15) 
		{


			if (timeElapsed > projectileDelay) {
				ChangeAnimationState (1);
				while (anim.IsPlaying ("throwingMainLQ")) {
				
				}

				createSpikeBall ();
				timeElapsed = 0;
			}
			timeElapsed += Time.deltaTime;

		}

		//ChangeAnimationState (0);


	}
	void ChangeAnimationState(int value){
		animator.SetInteger("idle", value);
	}
	void createSpikeBall()
	{
		GameObject fire_point = GameObject.Find ("LQfirepoint");
		GameObject projectileClones= Instantiate (projectile, fEnemy.transform.position, Quaternion.identity) as GameObject;
		bool positive = transform.localScale.x < 0;
		bool negative = transform.localScale.x > 0;
		//if (positive) {

			//Debug.Log (positive);
			projectileClones.transform.localScale = fEnemy.transform.localScale;
			Destroy (projectileClones, 2.5f);
		//}
		/*if (positive) {

			//Debug.Log (negative);
			projectileClones.transform.localScale = transform.localScale;
			Destroy (projectileClones, 2.5f);
		}*/
	}

}
