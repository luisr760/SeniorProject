using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

	public GameObject bombAsh;
	private GameObject projectileClones;
	private Rigidbody2D rigidBomb2D;

	void Awake()
	{
		rigidBomb2D = GetComponent<Rigidbody2D> ();
	}
	void Start()
	{
		rigidBomb2D.AddForce (transform.up * 750);
		Invoke ("createExplosion", 2f);
		Destroy (gameObject, 2f);
	}
	// Use this for initialization

	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy (gameObject);
		createExplosion ();
	}
	void createExplosion()
	{
		projectileClones = Instantiate (bombAsh, transform.position, Quaternion.identity);
		Destroy (projectileClones, .5f);
	}
}
