using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoveOnPath : MonoBehaviour {


	public Editorpath PathToFollow;
	public int CurrentWayPointID =0;
	public float speed;
	private float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public string pathName;

	Vector3 lastP;
	Vector3 currP;
	public LayerMask passengerMask;
	public Vector3 move;
	// Use this for initialization


	// Use this for initialization
	public virtual void Start () {
		
		//PathToFollow = GameObject.Find(pathName).GetComponent<Editorpath>();
		lastP = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
		transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime*rotationSpeed);

		//if you want to impl rotation
		//var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position-transform.position);
		//transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*rotationSpeed);


		//go to the end of the waypoint list
		if(distance <= reachDistance){
			CurrentWayPointID++;
		}

		//start over or put where you want it to go next
		//for now, just start over
		if(CurrentWayPointID >= PathToFollow.path_objs.Count)
		{
			CurrentWayPointID = 0;
		}

	}

}

