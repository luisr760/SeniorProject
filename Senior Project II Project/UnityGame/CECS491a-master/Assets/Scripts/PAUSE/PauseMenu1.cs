using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu1 : MonoBehaviour {

	public GameObject PauseUI;

	private  bool paused = false;
	//magical player freeze for your pause, your are welcome!
	public robotMove rob;
	GameObject[] power;
	private int size = 0;
	void Start(){

		PauseUI.SetActive (false);
		//get object by tag and then its component
		//rob = GetComponent<robotMove>();
 		rob = GameObject.FindGameObjectWithTag("robomove").GetComponent<robotMove>();
  }

	void Update(){

		power = GameObject.FindGameObjectsWithTag ("Item");
		size = power.Length;

		if (Input.GetButtonDown ("Pause")) {		
			paused = !paused;
			power = GameObject.FindGameObjectsWithTag ("Item");
			size = power.Length;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0.0001f;
			AudioListener.pause = true;
			rob.enabled = !rob.enabled;//pause player
			for (int i = 0; i < power.Length; i++) {
				power [i].SetActive (false);
			}

		}

		if (!paused) {
		
			PauseUI.SetActive (false);
			Time.timeScale = 1;
			AudioListener.pause = false;
			if(rob.enabled == false)
				rob.enabled = true; //pause player
		
		}

		for (int i = 0; i < size; i++) {
			power [i].SetActive (true);
		}

	}

	public void Resume() {

		paused = false;

	}

	public void Restart() {

		Application.LoadLevel (Application.loadedLevel);

	}

	public void MainMenu(int level){

		Application.LoadLevel (level);

	}

	public void Quit(){

		Application.Quit ();
		
	}
		
}
