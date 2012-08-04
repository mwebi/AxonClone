using UnityEngine;
using System.Collections;

public class RangeCircle : MonoBehaviour {
	
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ohmyGOD.NodeGenerationScript.currentNode.transform.position;
	}
}
