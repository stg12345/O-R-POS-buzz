using UnityEngine;
using System.Collections;

public class AdCaller : MonoBehaviour {
	GameObject googleadsobject;
	// Use this for initialization
	void Start () {
		googleadsobject = GameObject.FindGameObjectWithTag("GoogleAdsObject");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
