using UnityEngine;
using System.Collections;

public class GOD : MonoBehaviour {
	
	public GameObject NodeGeneratorObject;
	[HideInInspector] public NodeGeneration NodeGenerationScript;
	
	public GameObject RangeCircleObject;
	[HideInInspector]public RangeCircle RangeCircleScript;
	
	public GameObject PlayerObject;
	[HideInInspector]public Player PlayerScript;
	
	public GameObject ScoreCounterObject;
	[HideInInspector]public ScoreCounter ScoreCounterScript;
	
	public GameObject RestartButtonObject;
	[HideInInspector]public RestartButton RestartButtonScript;

	public GameObject NeuronLineObject;
	[HideInInspector]public NeuronLine NeuronLineScript;
	
	public GameObject NeuronLineRendererPrefab;
	
	// Use this for initialization
	void Start () {
		NodeGenerationScript = NodeGeneratorObject.GetComponent<NodeGeneration>();
		RangeCircleScript = RangeCircleObject.GetComponent<RangeCircle>();
		PlayerScript = PlayerObject.GetComponent<Player>();
		ScoreCounterScript = ScoreCounterObject.GetComponent<ScoreCounter>();
		RestartButtonScript = RestartButtonObject.GetComponent<RestartButton>();
		NeuronLineScript = NeuronLineObject.GetComponent<NeuronLine>();
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
}
