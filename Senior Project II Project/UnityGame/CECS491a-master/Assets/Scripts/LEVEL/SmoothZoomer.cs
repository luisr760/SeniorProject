using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothZoomer : MonoBehaviour {

	public Camera theMainCamera;
	public float newCameraZoom = 3;

	private float startZoom = 0;
	private float t = 0;

	private bool zooming = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (zooming) {
			t += Time.deltaTime;
			theMainCamera.orthographicSize = Mathf.SmoothStep (startZoom, newCameraZoom, t * 2);
			if (theMainCamera.orthographicSize == newCameraZoom) {
				zooming = false;
			}
		} else {
			t = 0;
		}
	}
		
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player") {
			startZoom = theMainCamera.orthographicSize;
			zooming = true;
		}
	}
}
