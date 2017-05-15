using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portLvlOne : MonoBehaviour {

	public bool isTriggered;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player") {
			isTriggered = true;
			Debug.Log ("port is triggered");
			SceneManager.LoadScene ("491aGame 1");
		}
	}

}
