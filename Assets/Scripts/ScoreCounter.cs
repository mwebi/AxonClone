using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public GameObject GODObject;
	private GOD ohmyGOD;
	
	private int currentScore;
	private GUIText ScoreCounterText;
	
	// Use this for initialization
	void Start () {
		ohmyGOD = GODObject.GetComponent<GOD>();
		currentScore = 0;
		ScoreCounterText = GetComponent<GUIText>();
	}
	
	public void newScore(float distanceOfNewNodeAndCurrentNode){
		distanceOfNewNodeAndCurrentNode *= 100;
		currentScore += (int)distanceOfNewNodeAndCurrentNode;
		ScoreCounterText.text = currentScore.ToString();
	}
}
