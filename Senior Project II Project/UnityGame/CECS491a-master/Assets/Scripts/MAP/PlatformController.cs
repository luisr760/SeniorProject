using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformController : RayCastController {

	public LayerMask passengerMask;


	public Vector3[] localWayPoints;
	Vector3[] globalWayPoints;

	public float speed;
	int fromWayPointIndex;
	float percentBetweenWayPoints;

	// Use this for initialization
	void Start () {
		base.Start();

		globalWayPoints = new Vector3[localWayPoints.Length];
		for(int i =0; i<localWayPoints.Length; i++){
			globalWayPoints[i] = localWayPoints[i] +transform.position;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		UpdateRaycastOrigins();
		Vector3 velocity = CalculatePlatformMovement();

		MovePassengers(velocity);
		transform.Translate(velocity);
	
	}

	Vector3 CalculatePlatformMovement(){
		int toWayPointIndex = fromWayPointIndex +1;
		float distanceBetweenWayPoints = Vector3.Distance(globalWayPoints[fromWayPointIndex],globalWayPoints[toWayPointIndex]);
		percentBetweenWayPoints += Time.deltaTime*speed/distanceBetweenWayPoints;

		Vector3 newPos = Vector3.Lerp(globalWayPoints[fromWayPointIndex], globalWayPoints[toWayPointIndex], percentBetweenWayPoints);

		if(percentBetweenWayPoints >=1){
			percentBetweenWayPoints =0;
			fromWayPointIndex++;
			if(fromWayPointIndex >= globalWayPoints.Length-1){
				fromWayPointIndex =0;
				System.Array.Reverse(globalWayPoints);
			}
				
		}
		return newPos- transform.position;

	}

	void MovePassengers(Vector3 velocity){
		HashSet<Transform> movedPassengers = new HashSet<Transform>();

		float directionX =  Mathf.Sign(velocity.x);
		float directionY = Mathf.Sign(velocity.y);

		//vert moving platform

		if(velocity.y !=0){
			float rayLength = Mathf.Abs(velocity.y)+skinWidth;

			for(int i=0; i<verticalRayCount; i++){
				Vector2 rayOrigin = (directionY==-1)?raycastOrigins.bottomLeft:raycastOrigins.topLeft;
				rayOrigin +=Vector2.right *(verticalRaySpacing*i);
				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up*directionY, rayLength,passengerMask);

				if(hit){
					if(!movedPassengers.Contains(hit.transform)){
						movedPassengers.Add(hit.transform);
						float pushX = (directionY ==1)?velocity.x:0;
						float pushY = velocity.y -(hit.distance-skinWidth)*directionY;

						hit.transform.Translate(new Vector3(pushX,pushY));
					}
				}
			}
		}


		if(velocity.x!=0){
			float rayLength = Mathf.Abs(velocity.x) + skinWidth;

			for(int i=0; i< horizontalRayCount; i++){
				Vector2 rayOrigin = (directionX ==-1)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight;
				rayOrigin += Vector2.up*(horizontalRaySpacing*i);
				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, passengerMask);

				if(hit){
					if(!movedPassengers.Contains(hit.transform)){
						movedPassengers.Add(hit.transform);
						float pushX = velocity.x -(hit.distance-skinWidth)*directionX;
						float pushY = 0;

						hit.transform.Translate(new Vector3(pushX,pushY));
					}
				}
			}
		}

		if(directionY ==-1 || velocity.y==0 && velocity.x !=0){

			float rayLength = skinWidth *2;

			for(int i =0; i<verticalRayCount; i++){
				Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right *(verticalRaySpacing * i);
				RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);

				if(hit){
					if(!movedPassengers.Contains(hit.transform)){
						movedPassengers.Add(hit.transform);
						float pushX = velocity.x;
						float pushY = velocity.y;

						hit.transform.Translate(new Vector3(pushX, pushY));
					}
				}
			}
		}


	}

	void OnDrawGizmos(){
		if(localWayPoints !=null){
			Gizmos.color = Color.red;
			float size = .3f;

			for(int i=0; i<localWayPoints.Length; i++){
				Vector3 globalWaypointPos = (Application.isPlaying)?globalWayPoints[i]:localWayPoints[i] + transform.position;
				Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
				Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
			}
		}

	}

}