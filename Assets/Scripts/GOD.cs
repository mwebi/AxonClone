using UnityEngine;
using System.Collections;

public class GOD : MonoBehaviour {
	
	public GameObject NodeGeneratorObject;
	[HideInInspector] public NodeGeneration NodeGenerationScript;
	
	public GameObject RangeCircleObject;
	[HideInInspector]public RangeCircle RangeCircleScript;
	
	public GameObject PlayerObject;
	[HideInInspector]public Player PlayerScript;
	
	// Use this for initialization
	void Start () {
		NodeGenerationScript = NodeGeneratorObject.GetComponent<NodeGeneration>();
		RangeCircleScript = RangeCircleObject.GetComponent<RangeCircle>();
		PlayerScript = PlayerObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
}
