using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine(WaitTime());
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Application.LoadLevel("MainLevelDemo");
		}
	}


}
