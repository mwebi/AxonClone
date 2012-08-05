using UnityEngine;
using System.Collections;

public class NeuronLine : MonoBehaviour {
	
	//Settings
	public float Speed;
	public float TimeIntervall;
	
	//Props
	private LineRenderer NeuronLineRenderer;
	
	private Vector3 direction;
	private float currentSpeed;
	private Vector3 positionToReach;
	private Vector3 newPostion;
	private Vector3 lastPostion;
	private float timeUntilNextStep;
	private int segments;
	
	
	// Use this for initialization
	void Start () {
		NeuronLineRenderer = GetComponent<LineRenderer>();
		segments=0;
		lastPostion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilNextStep -= Time.deltaTime;
		if(timeUntilNextStep <= 0){
			timeUntilNextStep = TimeIntervall;
			
			float distanceToPositionToReach = Vector3.Distance(positionToReach, lastPostion);
			if(distanceToPositionToReach > 0.1f){
				currentSpeed = distanceToPositionToReach/Speed;
				newPostion = lastPostion + direction.normalized*currentSpeed;
				if(lastPostion != newPostion){
					segments++;
					NeuronLineRenderer.SetVertexCount(segments);
					
					NeuronLineRenderer.SetPosition(segments-1, newPostion);
					lastPostion = newPostion;
				}
			}
		}
	}
	
	public void NewNodeActivated(Node newNodeScript){
		positionToReach = newNodeScript.gameObject.transform.position;
		direction = positionToReach - lastPostion;
	}
}
