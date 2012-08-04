using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	
	Color inactiveColor;
	Color activeColor;
	
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	public bool isClickable;
	
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
		
		inactiveColor.r = 100;
		activeColor.r = 255;
		
		isClickable= true;
	}
	
	public void SetColorForCurrent(bool onoff){
		if(onoff)
			renderer.material.color = activeColor;
		else
			renderer.material.color = inactiveColor;
	}
	
	void OnMouseUpAsButton() {
        //SendMessage("NodeClicked", this, SendMessageOptions.DontRequireReceiver);
		
		ohmyGOD.PlayerScript.NodeClicked(this);
		isClickable = false;
    }
}
