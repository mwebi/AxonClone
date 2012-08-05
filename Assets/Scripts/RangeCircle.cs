using UnityEngine;
using System.Collections;

public class RangeCircle : MonoBehaviour {
	
	//Settings
	public float RangeDecreaseSpeed;
	public float RangeBoostForClick;
	public float MaxRange;
	
	
	//Props
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	public float currentRange;  //radius of circle/sphere
	private Vector3 decreaseVector;
	private Vector3 lastestMaxScale;
	private Vector3 RangeDecreaseSpeedVector;
	private Vector3 RangeBoostForClickVector;
	
		
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
		transform.position = ohmyGOD.NodeGenerationScript.currentNode.transform.position;
		decreaseVector = new Vector3();
		lastestMaxScale = transform.localScale;
		RangeDecreaseSpeedVector = new Vector3(RangeDecreaseSpeed,RangeDecreaseSpeed,RangeDecreaseSpeed);
		RangeBoostForClickVector = new Vector3(RangeBoostForClick,RangeBoostForClick,RangeBoostForClick);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ohmyGOD.NodeGenerationScript.currentNode.transform.position;
		
		if(currentRange > 0.1)
		{
			//decreaseVector consists of a dynamic (diff of lastestMaxScale and current scale) and a fixed (RangeDecreaseSpeedVector) speed component 
			decreaseVector = transform.localScale - (lastestMaxScale - transform.localScale)*0.5f*Time.deltaTime - RangeDecreaseSpeedVector * Time.deltaTime;
			transform.localScale = decreaseVector;
		}
		currentRange=transform.localScale.x / 2;
		
		//check for gameover
		if(currentRange <= 0.1)
			ohmyGOD.RestartButtonObject.SetActiveRecursively(true);
	}
	
	public void NewCurrentNode()
	{
		if(currentRange < MaxRange)
			transform.localScale += RangeBoostForClickVector;
		lastestMaxScale = transform.localScale;
	}
}
