using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (counter());

	}

	public IEnumerator counter()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel("MainMenu");
	}
}
