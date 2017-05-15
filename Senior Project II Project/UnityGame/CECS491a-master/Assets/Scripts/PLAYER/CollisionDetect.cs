using UnityEngine;
using System.Collections;

public class CollisionDetect : MonoBehaviour {

	public float movingForce; 
	Vector3 startPoint;
	Vector3 origin;
	public int numberOfRays = 10;
	int i;  
	RaycastHit hitInfo;
	float lengthOfRay;
	float DistanceBetweenRays;
	float DirectionFactor;
	float DirectionFactor2;
	float margin = 0.015f;
	Ray ray;

	public BoxCollider collider;
	//public PolygonCollider2D collider;
	public Bounds bounds;
	void Start()
	{
		collider = GetComponent<BoxCollider> ();
		bounds = collider.bounds;
		lengthOfRay = collider.bounds.extents.y;
		DirectionFactor = Mathf.Sign (Vector3.up.y);

		DirectionFactor2 = Mathf.Sign (Vector3.left.y);
	}
	void Update()
	{
		startPoint = new Vector3 (collider.bounds.min.x + margin, transform.position.y, transform.position.z);
		/*if (!isCollidingVertically ()) {
			transform.Translate (Vector3.up * movingForce * Time.deltaTime * DirectionFactor);
		}*/
		if (!isCollidingHorizontal ()) {
			transform.Translate (Vector3.left * movingForce * Time.deltaTime * DirectionFactor2);
		}
	}
	/*bool isCollidingVertically()
	{
		origin = startPoint;
		DistanceBetweenRays = (collider.bounds.size.x-2 * margin)/ (numberOfRays -1);
		for (i = 0; i < numberOfRays; i++) {
			ray = new Ray (origin, Vector3.up * DirectionFactor);
			Debug.DrawRay (origin, Vector3.up * DirectionFactor,Color.yellow );
			if (Physics.Raycast (ray, out hitInfo, lengthOfRay)) {
				print ("Collided with " + hitInfo.collider.gameObject);
				DirectionFactor = -DirectionFactor;
				return true;
			}
			origin += new Vector3 (DistanceBetweenRays,0,0);
		}
		return false;
	}*/
	bool isCollidingHorizontal()
	{
		origin = startPoint;
		DistanceBetweenRays = (collider.bounds.size.x-2 * margin)/ (numberOfRays -1);
		for (i = 0; i < numberOfRays; i++) {
			ray = new Ray (origin, Vector3.left * DirectionFactor2);
			Debug.DrawRay (origin, Vector3.left * DirectionFactor2,Color.green );
			if (Physics.Raycast (ray, out hitInfo, lengthOfRay)) {
				print ("Collided with " + hitInfo.collider.gameObject);
				DirectionFactor2 = -DirectionFactor2;
				return true;
			}
			origin += new Vector3 (DistanceBetweenRays,0,0);
		}
		return false;
	}
}
