using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	
	//settings
	public bool isStartNode;
	public float yOffsetForFadeOut;
	public Material FadedMaterial;
	public Material ClickedMaterial;
	
	public GameObject GODObject;
	private GOD ohmyGOD;
	
	public bool isClickable;
	private bool doFadeOut;
	private bool doFadeToClickedMaterial;
	
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
		
		
		if(isStartNode){
			renderer.material = ClickedMaterial;
			isClickable= false;
		}else
			isClickable= true;
	}
	
	void Update(){
		if(transform.position.y <= ohmyGOD.NodeGenerationScript.currentNode.transform.position.y+yOffsetForFadeOut
			&& isClickable)
		{
			doFadeOut = true;
			isClickable = false;
		}
		fadeOut();
		fadeToClickedMatrial();
	}
	
	void fadeOut(){
		if(doFadeOut)
			renderer.material.Lerp(renderer.material, FadedMaterial, 0.1f);
	}
	
	void fadeToClickedMatrial(){
		if(doFadeToClickedMaterial)
			renderer.material.Lerp(renderer.material, ClickedMaterial, 0.2f);
	}
	
	public void StartToFadeToClickedMaterial(bool onoff){
		doFadeToClickedMaterial = onoff;
	}
	
	void OnMouseUpAsButton() {
        ohmyGOD.PlayerScript.NodeClicked(this);
		isClickable = false;
    }
}
