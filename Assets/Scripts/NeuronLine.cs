using UnityEngine;
using System.Collections;

public class NeuronLine : MonoBehaviour {
	
	//Settings
	public float Speed;
	public int MaxBranchNumber;
	public float BranchSpeed;
	public float MotherStartWidth;
	public float MotherEndWidth;
	public float MotherStartWidthIncreasePerNode;
	public float BranchStartWidth;
	public float BranchEndWidth;
	public float CurveSpeed;
	public float BranchCurveSpeed;
	public float TimeIntervall;
	
	//Props
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	private LineRenderer NeuronLineRenderer;
	
	private Vector3 directionDirectFromLastNodeToNextNode;
	private Vector3 targetDirection;
	private Vector3 lastDirection;
	private Vector3 currentDirectionOfLine;
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
	
	private float currentLineStartWidth;
	
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
			
			currentLineStartWidth = MotherStartWidth;
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
			
			float minThreshold = distanceFromStartToEnd*Random.Range(0.3f,0.6f);
			float maxThreshold = distanceFromStartToEnd*Random.Range(0.2f,0.3f);
			
			if(distanceFromStart > minThreshold
					&& distanceToPositionToReach > maxThreshold
					//&& Vector3.Angle(positionToReach - lastPosition, currentDirection) > 5
					&& !spawnedBranch
					&& branchDepth < MaxBranchNumber
					&& distanceFromStartToEnd > 0.1f )
				spawnBranch();
				
			if(distanceToPositionToReach > 0.1f){
				currentSpeed = distanceToPositionToReach*Speed;
				//newPostion = lastPosition + direction.normalized*currentSpeed*Time.deltaTime;
				
				currentDirectionOfLine = Vector3.Lerp(currentDirectionOfLine, positionToReach - lastPosition, distanceFromStart*CurveSpeed*Time.deltaTime );
				
				newPostion = lastPosition + currentDirectionOfLine.normalized*currentSpeed*Time.deltaTime;
				
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
		
		newNeuronLine.GetComponent<NeuronLine>().setupNewBranch(GODObject, lastPosition, currentDirectionOfLine, lastDirection, lastPositionToReach , branchDepth, BranchStartWidth, BranchEndWidth, MaxBranchNumber);
	}
	
	public void setupNewBranch(GameObject ourGOD, Vector3 currentPos, Vector3 parentLineCurrentDirection, Vector3 parentLineLastDirection, Vector3 LastNodePos ,int depthOfParent, float lineStartWidth, float lineEndWidth, int maxBranches){
		branchDepth = depthOfParent + 1;
		MaxBranchNumber = maxBranches;
		spawnedBranch = false;
		Speed = BranchSpeed;
		CurveSpeed = BranchCurveSpeed;
		
		GODObject = ourGOD;
		ohmyGOD = GODObject.GetComponent<GOD>();
		
		GetComponent<LineRenderer>().SetWidth(lineStartWidth, lineEndWidth);
		
		transform.position = currentPos;
		lastPosition = currentPos;
		
		Vector3 randomDirection = new Vector3 ( Random.Range (-1.2f, 1.2f), Random.Range (0.3f, 0.8f), 0);
		
		positionToReach = currentPos + randomDirection;
		lastPositionToReach = lastPosition;//LastNodePos;
		
		lastDirection = directionDirectFromLastNodeToNextNode;
		directionDirectFromLastNodeToNextNode = positionToReach - lastPositionToReach;
		currentDirectionOfLine=parentLineCurrentDirection;
	}
	
	public void NewNodeActivated(Node newNodeScript){
		lastPositionToReach = positionToReach;
		positionToReach = newNodeScript.gameObject.transform.position;

		lastDirection = directionDirectFromLastNodeToNextNode;
		directionDirectFromLastNodeToNextNode = positionToReach - lastPositionToReach;
		
		if(currentDirectionOfLine == Vector3.zero)
			currentDirectionOfLine=directionDirectFromLastNodeToNextNode;
		
		if(branchDepth == 0)
			spawnedBranch = false;
		
		currentLineStartWidth += MotherStartWidthIncreasePerNode;
		GetComponent<LineRenderer>().SetWidth(currentLineStartWidth, MotherEndWidth);
	}
	
}
