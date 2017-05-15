﻿using UnityEngine;
using System.Collections;

public class RayCastController : MonoBehaviour {


	public LayerMask collisionMask;
	public LayerMask weaponsMask;
	public LayerMask enemyMask;

	public const float skinWidth = .015f;
	public int horizontalRayCount =4;
	public int verticalRayCount= 4;

	[HideInInspector]
	public float horizontalRaySpacing;
	[HideInInspector]
	public float verticalRaySpacing;

	[HideInInspector]
	public BoxCollider2D collider;
	//public PolygonCollider2D collider;
	public RaycastOrigins raycastOrigins;
	//[HideInInspector]


	public virtual void Start(){
		collider = GetComponent<BoxCollider2D>();
		//collider = GetComponent<PolygonCollider2D>();
		CalculateRaySpacing();

	}

	public void UpdateRaycastOrigins(){

		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth*-2);

		raycastOrigins.bottomLeft= new Vector2(bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight =  new Vector2(bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft= new Vector2(bounds.min.x, bounds.max.y);
		raycastOrigins.topRight= new Vector2(bounds.max.x, bounds.max.y);

	}

	public void CalculateRaySpacing(){
		Bounds bounds = collider.bounds;
		bounds.Expand(skinWidth*-2);

		horizontalRayCount = Mathf.Clamp(horizontalRayCount,2,int.MaxValue);
		verticalRayCount = Mathf.Clamp(verticalRayCount,2,int.MaxValue);

		horizontalRaySpacing = bounds.size.y/(horizontalRayCount-1);
		verticalRaySpacing = bounds.size.x/(verticalRayCount-1);
	}


	public struct RaycastOrigins{
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}
}