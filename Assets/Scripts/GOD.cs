using UnityEngine;
using System.Collections;

public class GOD : MonoBehaviour {
	
	public GameObject NodeGeneratorObject;
	public NodeGeneration NodeGenerationScript;
	
	// Use this for initialization
	void Start () {
		NodeGenerationScript = NodeGeneratorObject.GetComponent<NodeGeneration>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
