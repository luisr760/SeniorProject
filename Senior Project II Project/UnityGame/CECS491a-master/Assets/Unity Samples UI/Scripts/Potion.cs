using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("Potion");
		Destroy (gameObject);
	}
}
