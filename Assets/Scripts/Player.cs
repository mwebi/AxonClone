using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void NodeClicked(Node clickedNodeScript){
		//check if node is in the range of the circle
		if(Vector3.Distance(ohmyGOD.NodeGenerationScript.currentNode.transform.position, clickedNodeScript.gameObject.transform.position) 
							< ohmyGOD.RangeCircleScript.currentRange)
		{
			//check if the node is clickable
			if(clickedNodeScript.isClickable)
			{
				ohmyGOD.NodeGenerationScript.currentNode.GetComponent<Node>().SetColorForCurrent(false);
				ohmyGOD.NodeGenerationScript.currentNode = clickedNodeScript.gameObject;
				ohmyGOD.NodeGenerationScript.currentNode.GetComponent<Node>().SetColorForCurrent(true);
				ohmyGOD.RangeCircleScript.NewCurrentNode();
			}
		}
			
			
	}
}
