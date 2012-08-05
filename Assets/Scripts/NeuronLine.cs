using UnityEngine;
using System.Collections;

public class NeuronLine : MonoBehaviour {
	
	//Settings
	public float Speed;
	public float BranchSpeed;
	public float BranchStartWidth;
	public float BranchEndWidth;
	public float CurveSpeed;
	public float BranchCurveSpeed;
	public float TimeIntervall;
	
	//Props
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	private LineRenderer NeuronLineRenderer;
	
	private Vector3 direction;
	private Vector3 targetDirection;
	private Vector3 lastDirection;
	private Vector3 currentDirection;
	private Vector3 randomDeviation;
	
	private float currentSpeed;
	private Vector3 lastPositionToReach;
	public Vector3 positionToReach;
	private Vector3 newPostion;
	private Vector3 lastPosition;
	private float timeUntilNextStep;
	private int segments;
	
	
	bool spawnedBranch;
	int branchDepth;
	
	// Use this for initialization
	void Start () {
		NeuronLineRenderer = GetComponent<LineRenderer>();
		ohmyGOD = GODObject.GetComponent<GOD>();
		segments=0;
				
		spawnedBranch = false;
		if(branchDepth == 0){
			positionToReach = lastPosition;
			lastPosition = transform.position;
			lastPositionToReach = lastPosition;
			
		}
		setStartPositionAsFirstSegment();
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilNextStep -= Time.deltaTime;
		if(timeUntilNextStep <= 0){
			timeUntilNextStep = TimeIntervall;
			
			float distanceToPositionToReach = Vector3.Distance(positionToReach, lastPosition);
			float distanceFromStart = Vector3.Distance(lastPositionToReach, lastPosition);
			float distanceFromStartToEnd = Vector3.Distance(positionToReach,lastPositionToReach);
			
			float minThreshold;
			float maxThreshold;
			if(branchDepth == 0){
				minThreshold = distanceFromStartToEnd*0.50f;
				maxThreshold = distanceFromStartToEnd*0.25f;
			}else{
				minThreshold = distanceFromStartToEnd*0.40f;
				maxThreshold = distanceFromStartToEnd*0.25f;
			}
			
			if(distanceFromStart > minThreshold
					&& distanceToPositionToReach > maxThreshold
					//&& Vector3.Angle(positionToReach - lastPosition, currentDirection) > 5
					&& !spawnedBranch
					&& branchDepth < 7
					&& distanceFromStartToEnd > 0.1f )
				spawnBranch();
				
			if(distanceToPositionToReach > 0.1f){
				currentSpeed = distanceToPositionToReach*Speed;
				//newPostion = lastPosition + direction.normalized*currentSpeed*Time.deltaTime;
				
				currentDirection = Vector3.Lerp(currentDirection, positionToReach - lastPosition, distanceFromStart*CurveSpeed*Time.deltaTime );
				
				newPostion = lastPosition + currentDirection.normalized*currentSpeed*Time.deltaTime;
				
				if(lastPosition != newPostion){
					segments++;
					NeuronLineRenderer.SetVertexCount(segments);
					
					NeuronLineRenderer.SetPosition(segments-1, newPostion);
					lastPosition = newPostion;
				}
			}
		}
	}
	void setStartPositionAsFirstSegment(){
		segments++;
		NeuronLineRenderer.SetVertexCount(segments);
		
		NeuronLineRenderer.SetPosition(0, transform.position);
	}
	void spawnBranch(){
		spawnedBranch = true;
		GameObject newNeuronLine = (GameObject)Instantiate(ohmyGOD.NeuronLineRendererPrefab, lastPosition, Quaternion.identity);
		
		newNeuronLine.GetComponent<NeuronLine>().setupNewBranch(GODObject, lastPosition, currentDirection, lastDirection, lastPositionToReach , branchDepth, BranchStartWidth, BranchEndWidth);
	}
	
	public void setupNewBranch(GameObject ourGOD, Vector3 currentPos, Vector3 parentLineCurrentDirection, Vector3 parentLineLastDirection, Vector3 LastNodePos ,int depthOfParent, float lineStartWidth, float lineEndWidth){
		branchDepth = depthOfParent + 1;
		spawnedBranch = false;
		Speed = BranchSpeed;
		CurveSpeed = BranchCurveSpeed;
		
		GODObject = ourGOD;
		ohmyGOD = GODObject.GetComponent<GOD>();
		
		GetComponent<LineRenderer>().SetWidth(lineStartWidth, lineEndWidth);
		
		transform.position = currentPos;
		lastPosition = currentPos;
		
		Vector3 randomDirection = new Vector3 ( Random.Range (-1.3f, 1.3f), Random.Range (0.3f, 0.8f), 0);
		
		positionToReach = currentPos + randomDirection;
		lastPositionToReach = lastPosition;//LastNodePos;
		
		lastDirection = direction;
		direction = positionToReach - lastPositionToReach;
		currentDirection=parentLineCurrentDirection;
	}
	
	public void NewNodeActivated(Node newNodeScript){
		lastPositionToReach = positionToReach;
		positionToReach = newNodeScript.gameObject.transform.position;

		lastDirection = direction;
		direction = positionToReach - lastPositionToReach;
		
		if(currentDirection == Vector3.zero)
			currentDirection=direction;
		
		if(branchDepth == 0)
			spawnedBranch = false;
	}
	
}
