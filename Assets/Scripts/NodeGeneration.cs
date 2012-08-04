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
	
	public GameObject startNode;
	public GameObject currentNode;
	private GameObject lastGeneratedNode;
	private GameObject tempNode;
	private ArrayList tempNodeList;
	private Vector3 tempPos;
	
	// Use this for initialization
	void Start () {
		currentNode = lastGeneratedNode = startNode;
		
		ohmyGOD = GODObject.GetComponent<GOD>();
		tempPos = new Vector3();
		tempNodeList = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(currentNode.transform.position, lastGeneratedNode.transform.position) < GeneratorRange)
			generateNewNodes(HowManyNodeAtATime);
	}

void generateNewNodes(int NodeNum){
		tempNodeList.Clear();
		
		for(int i=0; i < NodeNum; i++){
			tempPos.x = lastGeneratedNode.transform.position.x + Random.Range(-4.5f, 4.5f);
			tempPos.y = lastGeneratedNode.transform.position.y + Random.Range(1.2f, 3.4f);
		    tempPos.z = 0;
			
			//search for too near neighbours
			avoidOverlapping ();
			
			tempNode = (GameObject)Instantiate(NodeNormalPrefab, tempPos, Quaternion.identity);
			tempNode.GetComponent<Node>().GODObject = GODObject;
			tempNodeList.Add(tempNode);
		}
		
		lastGeneratedNode = tempNode;
	}
	
	void avoidOverlapping ()
	{
		bool otherWasHit = true;
		while(otherWasHit){
			otherWasHit = false;
			//up, down, left, right
			if(Physics.Raycast(tempPos, Vector3.up, 1)){
				tempPos.y += 2.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.down, 1)){
				tempPos.y += 1.62f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.left, 1)){
				tempPos.x += 1.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.right, 1)){
				tempPos.x += 2.62f;
				otherWasHit = true;
			}
			//top-right, top-left, bottom-right, bottom-left
			else if(Physics.Raycast(tempPos, Vector3.up-Vector3.left, 1)){
				tempPos.y += 2.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.up-Vector3.right, 1)){
				tempPos.y += 1.62f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.down-Vector3.left, 1)){
				tempPos.x += 1.55f;
				otherWasHit = true;
			}
			else if(Physics.Raycast(tempPos, Vector3.down-Vector3.right, 1)){
				tempPos.x += 2.62f;
				otherWasHit = true;
			}
		}
	}
}
