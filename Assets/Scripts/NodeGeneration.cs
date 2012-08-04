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
	
	// Use this for initialization
	void Start () {
		currentNode = lastGeneratedNode = startNode;
		
		ohmyGOD = GODObject.GetComponent<GOD>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(currentNode.transform.position, lastGeneratedNode.transform.position) < GeneratorRange)
			generateNewNodes(HowManyNodeAtATime);
	}
	
	void generateNewNodes(int NodeNum){
		
		for(int i=0; i< NodeNum; i++){
			Vector3 tempPos = new Vector3( lastGeneratedNode.transform.position.x + Random.Range(-10, 10), 
										   lastGeneratedNode.transform.position.y + Random.Range(1, 4),
										   0);
			tempNode = (GameObject)Instantiate(NodeNormalPrefab, tempPos, Quaternion.identity);
			tempNode.GetComponent<Node>().GODObject = GODObject;
		}
		lastGeneratedNode = tempNode;
	}
}
