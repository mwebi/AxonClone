using UnityEngine;
using System.Collections;

public class NodeOverlapProtection : MonoBehaviour {
	
	private GameObject ParentNode;
	private Vector3 tempVec3;
	// Use this for initialization
	void Start () {
		ParentNode = transform.parent.gameObject;
	}
	
	void OnTriggerStay(Collider other) {
		//Debug.Log("collided");
		tempVec3.x = Random.Range(-1.1f,1.1f);
		tempVec3.y = Random.Range(-1.1f,1.1f);
		tempVec3.z = 0;
		ParentNode.transform.position += tempVec3;
	}
}
