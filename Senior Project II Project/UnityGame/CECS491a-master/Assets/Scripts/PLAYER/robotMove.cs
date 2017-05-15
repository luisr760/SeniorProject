using UnityEngine;
using System.Collections;

public class robotMove : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D rb;
	public float speedX;
	public float speedY;
	public Vector3 velocity;
	bool pause;
	/// <summary>
	/// A reference to the inventory
	/// </summary>
	public Inventory inventory;
	// Use this for initialization
	private bool jetpackEquipped = false;
	public AnimatorOverrideController jetpackController;

	void Wake(){
		animator = GetComponent<Animator>();
	}
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.U)) {
			ChangeAnimationState (10);
		}
		else if (Input.GetAxisRaw ("Horizontal") == 1) {
			transform.localScale = new Vector3 (1, 1, 1);
			// Check if player is going up
			if (Input.GetAxisRaw ("Vertical") == 1 && jetpackEquipped) {
				ChangeAnimationState (2);
				GetComponentInParent<Footsteps> ().isToggled (false);
			} else {
			// Else player is walking
				ChangeAnimationState (1);
				GetComponentInParent<Footsteps> ().isToggled (true);
			}
		// Player going left
		} else if (Input.GetAxisRaw ("Horizontal") == -1) {
			transform.localScale = new Vector3 (-1, 1, -1);
			// Check if player is going up
			if (Input.GetAxisRaw ("Vertical") == 1 && jetpackEquipped) {
				GetComponentInParent<Footsteps> ().isToggled (false);
				ChangeAnimationState (2);
			} else {
			// Else player is walking
				ChangeAnimationState (1);
				GetComponentInParent<Footsteps> ().isToggled (true);
			}
		} else if (Input.GetAxisRaw ("Vertical") == 1 && jetpackEquipped) {
			ChangeAnimationState (2);
		} else {
			// Standing still
			ChangeAnimationState(0);
		}
	}

	void ChangeAnimationState(int value){
				animator.SetInteger("AnimState", value);
	}

	public void Damage() {
	
		gameObject.GetComponent<Animation>().Play("red_flash");
	
	}

	public void JetpackEquipped(bool state) {
		if (state == true) {
			animator.runtimeAnimatorController = jetpackController;
			GetComponentInParent<Player> ().Jetpacking (true);
		}
		jetpackEquipped = state;
	}
}
