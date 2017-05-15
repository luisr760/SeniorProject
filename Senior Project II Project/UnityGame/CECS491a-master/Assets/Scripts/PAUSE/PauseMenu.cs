using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public Transform canvas;


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pause();
		}
	}

	public void pause()
	{
		if (canvas.gameObject.activeInHierarchy == false)
		{
			canvas.gameObject.SetActive(true);

			Time.timeScale = 0;
		}
		else
		{
			canvas.gameObject.SetActive(false);
			Time.timeScale = 1;
		}
	}
}