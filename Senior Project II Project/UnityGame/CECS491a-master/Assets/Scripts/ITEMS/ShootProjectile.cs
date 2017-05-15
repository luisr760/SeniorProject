using UnityEngine;
using System.Collections;

/// <summary>
/// This class will be used to manage 
/// and create the projeciles that will be shot out 
/// when powerup has been collected
/// </summary>
public class ShootProjectile : AbstractBehavior {

	/// <summary>
	/// The projectile delay so player
	/// can not spam fireballs.
	/// </summary>
	public float projectileDelay = .5f;
	/// <summary>
	/// The projectile that will be shot out
	/// </summary>
	public GameObject currentProjectile;

	public GameObject oldProjectile;
	/// <summary>
	/// To keep track of time for when the next time 
	/// you can shoot the fireball
	/// </summary>
	private float timeElapsed = 0f;
	/// <summary>
	/// Be used to grab any components of the player
	/// </summary>
	public GameObject player;
	// Update is called once per frame
	/// <summary>
	/// This will create the fireball projectile when the 
	/// J button is pressed
	/// </summary>
	public GameObject fire;

	public float camShakeAmount = 0.1f;
	public float camShakeLength = 0.1f;
	public GameObject camera;
	private CameraShake camShake;

	void Start() {
		
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		camShake = camera.GetComponent<CameraShake> ();

		if (camShake == null) {
			Debug.LogError ("No CameraShake script found on Camera object.");

		}
	}

	void Update () 
	{

		if (currentProjectile != null) {
			//Button pressed then fire
			var canFire = inputState.GetButtonValue (inputButtons [0]);
			//if enough time has passed then you can shoot another fireball
			if (canFire && timeElapsed > projectileDelay) {
				createProjectile (transform.position);
				timeElapsed = 0;
				camShake.Shake (camShakeAmount, camShakeLength);
			}
			timeElapsed += Time.deltaTime;
		}

	}
	/// <summary>
	/// Creates the fireball projectile
	/// </summary>
	/// <param name="position">The position where the 
	/// projectile will be spawed</param>
	public void createProjectile(Vector2 position)
	{
		fire = GameObject.Find ("FirePoint");
		player = GameObject.Find ("Blue_no1");
		//Debug.Log (player.transform.position * player.transform.localScale.x);
		var projectileClones = Instantiate (currentProjectile, fire.transform.position, Quaternion.identity) as GameObject;
		bool positive = transform.localScale.x < 0;
		bool negative = transform.localScale.x > 0;
		if (positive) {

			//Debug.Log (positive);
			projectileClones.transform.localScale = player.transform.localScale;
			Destroy (projectileClones, 2.5f);
		}
		if (negative) {

			//Debug.Log (negative);
			projectileClones.transform.localScale = player.transform.localScale;
			Destroy (projectileClones, 2.5f);
		}
		//Debug.Log (projectileClones.transform.localScale.x);
	}

}
