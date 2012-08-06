using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	public GameObject NodeBelowButton;
	
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
	}
	
	void OnMouseUpAsButton() {
        ohmyGOD.RangeCircleScript.doDecrease = true;
		ohmyGOD.PlayerScript.NodeClicked( NodeBelowButton.GetComponent<Node>() );
		this.gameObject.SetActiveRecursively(false);
    }
}
