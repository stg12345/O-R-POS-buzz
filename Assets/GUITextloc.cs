using UnityEngine;
using System.Collections;

public class GUITextloc : MonoBehaviour {
	Vector2 viewportPosition ;
	// Use this for initialization
	void Start () {
		viewportPosition = new Vector2(100,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
	}
}
