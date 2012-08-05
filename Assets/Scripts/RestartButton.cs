using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseUpAsButton() {
        Application.LoadLevel("AxonCloneIngame");
    }
}
