using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	//Settings
	public float CameraSpeed;
	public float YOffset;
	
	//Properties
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	private Vector3 CameraMovementDirection;
	private Vector3 YOffsetVector;
	private Vector3 currentSpeed;
	
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();

		transform.position = new Vector3(ohmyGOD.NodeGenerationScript.currentNode.transform.position.x, 
										 ohmyGOD.NodeGenerationScript.currentNode.transform.position.y,
										 transform.position.z);
		YOffsetVector = new Vector3(0, YOffset, 0);
		
		currentSpeed = new Vector3();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		CameraMovementDirection = ohmyGOD.NodeGenerationScript.currentNode.transform.position - transform.position;
		CameraMovementDirection.z = 0;
		if(CameraMovementDirection.magnitude > 0.05){
			currentSpeed = CameraMovementDirection.normalized * CameraMovementDirection.magnitude* CameraSpeed * Time.deltaTime;
			transform.position += currentSpeed;
			transform.position += YOffsetVector;
		}
	}
	
	public Vector3 getCurrentSpeed(){
		return currentSpeed;
	}
}
