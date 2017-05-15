using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Editorpath : MonoBehaviour {

	public Color rayColor = Color.white;
	public List<Transform> path_objs = new List<Transform>();
	Transform[] arr;

	void OnDrawGizmos(){
		Gizmos.color= rayColor;
		arr = GetComponentsInChildren<Transform>();
		path_objs.Clear();

		foreach(Transform path in arr){

			if(path != this.transform){
				path_objs.Add(path);
			}
		}

		for(int i =0; i < path_objs.Count; i++){
			Vector3 position = path_objs[i].position;
			if(i>0){
				Vector3 prev = path_objs[i-1].position;
				Gizmos.DrawLine(prev, position);
				Gizmos.DrawWireSphere(position, 0.3f);
			}
		}

	}

}
