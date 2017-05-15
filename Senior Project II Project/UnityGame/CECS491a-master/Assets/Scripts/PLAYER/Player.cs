using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour {

	float gravity;// = -20;
	public float moveSpeed = 8;
	private float flySpeed = 15; // used for god mode flying

	public float jumpVelocity;// = 8;
	float velocityXSmoothing;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded =.1f;
	public Vector3 velocity;


	// God mode allows player to effectively fly and not take damage (NYI)
	public bool godMode = false;

	// Jetpack flying!!!
	private bool jetpacking = false;
	private float currentJetpackSpeed = 0;
	private float jetpackAcceleration = 16;
	private float jetpackMaxSpeed = 8;

	// Track how long player has been alive. Will be used 
	// for score boost when finishing level or leaderboard.
	private float timeAlive = 0.0f;
	// Refernce to HUD's time text
	private HUDTime timeHUD;
	private HealthPlayer health;
	private HUDLives lives;

	/// <summary>
	/// A reference to the inventory
	/// </summary>
	public Inventory inventory;
	private Rigidbody2D rb2d;
	private GameObject enemy;

	Scene scene; 

	CharacterControl controller;
	private bool died;
	//Health 
	//Weapons

	public bool onLadder;
	private float climbSpeed;
	private float climbVelocity;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	void Start () {
		scene = SceneManager.GetActiveScene ();
		// Initialize timeHUD with game object HUD_time's HUDTime script
		timeHUD = GameObject.Find ("HUD_time").GetComponent<HUDTime> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		enemy = GameObject.FindGameObjectWithTag ("robomove");
		health = GameObject.Find("Player").GetComponent<HealthPlayer> ();
		lives = GameObject.Find("HUD_LivesValue").GetComponent<HUDLives>();
		//add components
		controller = GetComponent<CharacterControl>();
		gravity =-28;
		godMode = false;

		if (scene.name.Equals ("491aGame 1") ) {
			if (PlayerData.playerData.getFromCoinRoom()) {
				HUDHealth healthHUD = GameObject.Find ("HUD_health").GetComponent<HUDHealth> ();
				GameObject player = GameObject.Find ("Player");
				transform.position = new Vector3 (176, 9, 0);


				//Time.timeScale = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		Scene scene = SceneManager.GetActiveScene ();
		if (scene.name.Equals ("CoinRoom")) {
			PlayerData.playerData.setInCoinRoom ();
			//Debug.Log ("this is the level" + scene.name);
		}


			
		if (Input.GetButtonDown ("Teleport")) {
			GameObject player = GameObject.Find ("Player");
			player.transform.Translate (new Vector3 (290, 9, 0));
			Time.timeScale = 0;
		}	


		if (Input.GetButtonDown ("GodMode")) {
			godMode = !godMode;
		}	

		if (knockbackCount <= 0) {
			if (controller.collisions.above) {//controller.weaponsMask.Equals("Fireball")){
			
		    }

			if (controller.collisions.above || controller.collisions.below) {
				velocity.y = 0;
			}

			if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
				velocity.y = jumpVelocity;
			}
			/*
            if (velocity.y <= -55 && !jetpacking) {
                died = true;
                HUDHealth healthHUD = GameObject.Find("HUD_health").GetComponent<HUDHealth>();
                GameObject checkPoint = nearestCheckpoint();
                GameObject start = GameObject.Find("GameStart");
                if (checkPoint != null && lives.Lives > 0) {
                    transform.position = checkPoint.transform.position;
                    lives.UpdateLives();
                    health.CurrentHealth = 5;
                    healthHUD.resetHUDHealth(health.CurrentHealth);
                    //HUDLives lives = GameObject.Find("HUD_LivesValue").GetComponent<HUDLives>;
                } else if (lives.Lives > 0) {
                    Debug.Log("Hello LIVEs");
                    transform.position = start.transform.position;
                    lives.UpdateLives();
                    health.CurrentHealth = 5;
                    healthHUD.resetHUDHealth(health.CurrentHealth);
                }
            }*/

			Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			if (godMode) {
				// Let player move up and down using up/down keys while in god mode
				velocity.y = flySpeed * input.y;
				// Player moves without horizontal acceleration when in god mode
				velocity.x = flySpeed * input.x;
			} else {
				if (jetpacking && input.y == 1) {
					if (velocity.y < jetpackMaxSpeed) {
						velocity.y += jetpackAcceleration * Time.deltaTime;
					}
				} else {
					// Only apply gravity when not in God Mode
					velocity.y += gravity * Time.deltaTime;
				}
				// And only apply horizontal acceleration when not in God Mode
				float targetVelocityX = input.x*moveSpeed;
				velocity.x= Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, 
					(controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
			}

			if (onLadder) {

				velocity.y = flySpeed * input.y;

			}

			controller.Move (velocity * Time.deltaTime);
		} else {
		
			if (knockFromRight) {
			
				rb2d.velocity = new Vector2 (-knockback, knockback);

			}

			if (!knockFromRight) {

				rb2d.velocity = new Vector2 (knockback, knockback);

			}

			knockbackCount -= Time.deltaTime;
		
		}

		timeAlive += Time.deltaTime;
		timeHUD.UpdateTime (timeAlive);
		died = false;
	}

	/// <summary>
	/// Handles the player's collision
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Item") //If we collide with an item that we can pick up
		{
			Debug.Log (other.GetComponent<Item>());
			inventory.AddItem(other.GetComponent<Item>()); //Adds the item to the inventory.
		}
	}
	public GameObject nearestCheckpoint()
	{
		GameObject[] checkpoints =GameObject.FindGameObjectsWithTag ("Checkpoint");
		GameObject nearestCheck = null;
		float shortestDistance = Mathf.Infinity;

		foreach (GameObject check in checkpoints) {
			Vector3 checkPosition = check.transform.position;
			float distance = (checkPosition - transform.position).sqrMagnitude;
			Checkpoint triggered = check.GetComponent<Checkpoint> ();
			if (distance < shortestDistance && triggered.isTriggered == true) {
				nearestCheck = check;
				shortestDistance = distance;
			}

		}
		return nearestCheck;

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "portal") {

			Debug.Log ("finally, a collision : " + col.gameObject.name);
			Debug.Log ("finally, a collision : " );
		}

		Debug.Log (col.collider.name);
		Debug.Log (col.collider.gameObject.name);
		//Debug.Log (col.GetType);
	}

	public void Jetpacking (bool state) {
		jetpacking = state;
	}
	public bool IsJetting
	{
		get{ return jetpacking;}
	}
}
