using UnityEngine;
using System.Collections;

public class DestroyPlane : MonoBehaviour {
	 GameObject levelmaster;
	// Use this for initialization
	void Start () {
		levelmaster = GameObject.FindGameObjectWithTag("LevelMaster");
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.layer == 8)
		{
		Destroy(other.gameObject);
		//Debug.Log ("collision"); 
			levelmaster.SendMessage("ReduceCounter",1);
		}
		if(other.gameObject.layer == 9)
		{
			Destroy(other.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("Exit");
	}
}
