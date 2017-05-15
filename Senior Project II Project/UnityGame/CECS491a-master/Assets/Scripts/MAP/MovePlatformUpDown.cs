using UnityEngine;
using System.Collections;

public class MovePlatformUpDown : MonoBehaviour {

	private Vector3 positionA;
	private Vector3 positionB;
	private Vector3 nextPosition;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Transform childTransform;

	[SerializeField]
	private Transform transformB;

	void Start() {
		positionA = childTransform.localPosition;
		positionB = transformB.localPosition;
		nextPosition = positionB;
	}

	void Update() {
		Move ();
	}

	void Move() {
		childTransform.localPosition = Vector3.MoveTowards (childTransform.localPosition, nextPosition, speed * Time.deltaTime);

		if (Vector3.Distance (childTransform.localPosition, nextPosition) <= 0.1) {
			ChangeDestination();
		}
	}

	private void ChangeDestination() {
		nextPosition = nextPosition != positionA ? positionA : positionB;
	}
}