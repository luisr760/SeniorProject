using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float fallDelay;

	void Start() {

		rb2d = GetComponent<Rigidbody2D> ();
		Debug.Log (rb2d);
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.GetComponent<Collider2D>().CompareTag ("Player")) {
			Debug.Log ("HELLO FALL");
			StartCoroutine (fall ());
		}
	
	}

	IEnumerator fall() {
	
		yield return new WaitForSeconds (fallDelay);
		rb2d.bodyType = RigidbodyType2D.Dynamic;
		GetComponent<Collider2D> ().isTrigger = true;
		yield return 0;
	}

}
