using UnityEngine;
using System.Collections;

public class NodeOverlapProtection : MonoBehaviour {
	
	private GameObject ParentNode;
	private Vector3 tempVec3;
	
	public static string OverLapSphereTag = "OverLapSphere";
	
	// Use this for initialization
	void Start () {
		ParentNode = transform.parent.gameObject;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag != OverLapSphereTag)
			return;
		
		if ( other.transform.parent.gameObject.tag != NodeGeneration.SpecialNodeTag){
			Destroy(other.transform.parent.gameObject);
			ParentNode.tag = NodeGeneration.SpecialNodeTag;
		}
		else if(ParentNode.tag != NodeGeneration.SpecialNodeTag){
			Destroy(ParentNode);
		}
		else{
			if(Random.value > 0.5f){ 
				tempVec3.x = 1;
				tempVec3.y = 1;
			}else{
				tempVec3.x = -1;
				tempVec3.y = 1;
			}
			tempVec3.z = 0;
			ParentNode.transform.position += tempVec3;
		}
	}
}
