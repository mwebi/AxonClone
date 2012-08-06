using UnityEngine;
using System.Collections;

public class ParalaxScroller : MonoBehaviour {
	
	public GameObject FollowCam;
	public bool CameraDependentScrolling;
	public float ScrollSpeedWhenNotCameraDependentScrolling;
	public float CameraSpeedToScrollerSpeedFactor;
	
	private Vector2 currentOffset;
	
	// Use this for initialization
	void Start () {
		currentOffset = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {
		if(CameraDependentScrolling){
			currentOffset.x -= FollowCam.GetComponent<FollowCamera>().getCurrentSpeed().x / CameraSpeedToScrollerSpeedFactor ;
			currentOffset.y -= FollowCam.GetComponent<FollowCamera>().getCurrentSpeed().y / CameraSpeedToScrollerSpeedFactor ;
		}else
			currentOffset.y -= ScrollSpeedWhenNotCameraDependentScrolling;
		renderer.material.SetTextureOffset("_MainTex", currentOffset);
	}
}
