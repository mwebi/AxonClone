using UnityEngine;
using System.Collections;

public class RangeCircle : MonoBehaviour {
	
	//Settings
	public float RangeDecreaseSpeed;
	public float RangeBoostForClick;
	
	
	//Props
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	public float currentRange;  //radius of circle/sphere
	private Vector3 decreaseVector;
	private Vector3 lastestMaxScale;
		
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
		transform.position = ohmyGOD.NodeGenerationScript.currentNode.transform.position;
		decreaseVector = new Vector3();
		lastestMaxScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(currentRange > 0.1)
		{
			decreaseVector.x = transform.localScale.x - RangeDecreaseSpeed * Time.deltaTime;
			decreaseVector.y = transform.localScale.y - RangeDecreaseSpeed * Time.deltaTime;
			decreaseVector.z = transform.localScale.z - RangeDecreaseSpeed * Time.deltaTime;
			transform.localScale = decreaseVector;
		}
		currentRange=transform.localScale.x / 2;
		
		
		//if(currentRange <= 0.1)
			//gameover
	}
	
	public void NewCurrentNode()
	{
		transform.position = ohmyGOD.NodeGenerationScript.currentNode.transform.position;
		transform.localScale *= RangeBoostForClick;
		lastestMaxScale = transform.localScale;
	}
}
