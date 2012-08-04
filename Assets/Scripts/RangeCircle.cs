using UnityEngine;
using System.Collections;

public class RangeCircle : MonoBehaviour {
	
	//Settings
	public float RangeDecreaseSpeed;
	public float RangeBoostForClick;
	
	
	//Props
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	public float currentRange;
	private Vector3 decreaseVector;
		
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
		transform.position = ohmyGOD.NodeGenerationScript.currentNode.transform.position;
		decreaseVector = new Vector3();
		
		//HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
	}
	
	// Update is called once per frame
	void Update () {
		
		if(currentRange > 0.3)
		{
			decreaseVector.x = transform.localScale.x - RangeDecreaseSpeed;
			decreaseVector.y = transform.localScale.y - RangeDecreaseSpeed;
			decreaseVector.z = transform.localScale.z - RangeDecreaseSpeed;
			transform.localScale = decreaseVector;
		}
		currentRange=transform.localScale.magnitude;
		
		
		//if(currentRange <= 0.1)
			//gameover
	}
	
	public void NewCurrentNode()
	{
		transform.position = ohmyGOD.NodeGenerationScript.currentNode.transform.position;
		transform.localScale *= RangeBoostForClick;
	}
}
