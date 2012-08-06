using UnityEngine;
using System.Collections;

public class NodeGeneration : MonoBehaviour {
	
	//Settings
	public int GeneratorRange;
	public int HowManyNodeAtATime;
	public GameObject NodeNormalPrefab;

	
	//Properties
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	public GameObject LineStartNode;
	public GameObject GeneratorStartNode;
	public GameObject currentNode;
	
	private GameObject lastGeneratedNode;
	private GameObject lastGeneratedOriginNode;
	private GameObject tempNode;
	private Vector3 tempPos;
	
	private bool canGenerateNewNodes;
	
	public static string SpecialNodeTag = "SpecialNode";
	
	// Use this for initialization
	void Start () {
		currentNode  = LineStartNode;
		lastGeneratedNode = lastGeneratedOriginNode = GeneratorStartNode;
		
		ohmyGOD = GODObject.GetComponent<GOD>();
		tempPos = new Vector3();
		
		canGenerateNewNodes = true;
	}
	
	// Update is called once per frame
	void Update () {
		//if(Vector3.Distance(currentNode.transform.position, lastGeneratedOriginNode.transform.position) < GeneratorRange)
		if(Mathf.Abs(currentNode.transform.position.y - lastGeneratedOriginNode.transform.position.y) < GeneratorRange)
			generateNewNodes(HowManyNodeAtATime);
	}
	
	public void SetCanGenerateNewNodes(bool newValue){
		canGenerateNewNodes = newValue;
	}
	
	void generateNewNodes(int NodeNum){
		
		if(!canGenerateNewNodes)
			return;
		
		//special first node 
		tempPos.x = currentNode.transform.position.x + Random.Range(-0.1f, 0.1f);
		tempPos.y = currentNode.transform.position.y + Random.Range(0.9f, 1.2f);
	    tempPos.z = 0;
		avoidOverlapping ();
			
		tempNode = (GameObject)Instantiate(NodeNormalPrefab, tempPos, lastGeneratedNode.transform.rotation);
		tempNode.tag = SpecialNodeTag;
		tempNode.GetComponent<Node>().GODObject = GODObject;
		
		lastGeneratedNode = lastGeneratedOriginNode= tempNode;
		
		for(int i=0; i < NodeNum-1; i++){
			tempPos.x = lastGeneratedNode.transform.position.x + Random.Range(-8.5f, 8.5f);
			tempPos.y = lastGeneratedNode.transform.position.y + Random.Range(1.2f, 3.4f);
		    tempPos.z = 0;
			
			if(Vector3.Distance(tempPos, lastGeneratedNode.transform.position) < 1.4f){
				i--;
				continue;
			}
			
			//search for too near neighbours
			avoidOverlapping ();
			
			tempNode = (GameObject)Instantiate(NodeNormalPrefab, tempPos, lastGeneratedNode.transform.rotation);
			tempNode.GetComponent<Node>().GODObject = GODObject;
		}
		
		lastGeneratedNode = tempNode;
		lastGeneratedNode.tag = SpecialNodeTag;
		SetCanGenerateNewNodes(false);
	}
	
	void avoidOverlapping ()
	{
		bool otherWasHit = true;
		while(otherWasHit){
			otherWasHit = false;
			//up, down, left, right
			if(Physics.Raycast(tempPos, Vector3.up, 1.2f)){
				tempPos.y += 2.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.down, 1.2f)){
				tempPos.y += 1.62f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.left, 1.2f)){
				tempPos.x += 1.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.right, 1.2f)){
				tempPos.x += 2.62f;
				otherWasHit = true;
			}
			//top-right, top-left, bottom-right, bottom-left
			else if(Physics.Raycast(tempPos, Vector3.up-Vector3.left, 1.2f)){
				tempPos.y += 2.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.up-Vector3.right, 1.2f)){
				tempPos.y += 1.62f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.down-Vector3.left, 1.2f)){
				tempPos.x += 1.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.down-Vector3.right, 1.2f)){
				tempPos.x += 2.62f;
				otherWasHit = true;
			}
		}
	}
}
