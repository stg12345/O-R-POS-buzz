using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {
	public float speed = 0.7f;
	public GameObject  tailob;
	GameObject levelmaster;
	Vector2 pipe_loc;
	// Use this for initialization
	void Start () {
		levelmaster = GameObject.FindGameObjectWithTag("LevelMaster");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector2(-1,0)*Time.deltaTime*speed);

	}

	IEnumerator SaveLocation()
	{
		yield return new WaitForSeconds(1);
		pipe_loc = transform.position;
	}

	void UpdatePosition()
	{
		transform.position = pipe_loc;
	}

	void UpdateSpeed(float f)
	{
		this.speed = f;
	}
	/* GameObject getTailOb()
	{
		return this.tailob;
	}
*/

	/*public GameObject getFrontOb()
	{
		return this.tailob;
	}*/


	/*public void RetrievePosition()
	{
		foreach (Transform t in transform)
		{
			if(t.name == "TailOb")
			{
				levelmaster.SendMessage("ChangePosition", (Vector2) t.position);
			}
		}
		Debug.Log("RetPos");

	}*/
}
	
