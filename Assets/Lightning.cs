using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
	float speed = 0.7f;
	// Use this for initialization
	GameObject levelmaster;
	public AudioClip lightningpickup;
	bool scoresubmitted;
	void Start () {
	levelmaster = GameObject.FindGameObjectWithTag("LevelMaster");
		scoresubmitted = false;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(new Vector2(-1,0)*Time.deltaTime*speed);
				

	/*	RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,100);
		if (hit.collider.gameObject.layer == 10)
		{

			Debug.Log(hit.collider.gameObject.layer);
			levelmaster.SendMessage("AddScore");
		}
		*/
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (scoresubmitted == false)
		{
		levelmaster.SendMessage("AddScore");
			this.scoresubmitted = true;
			audio.PlayOneShot(lightningpickup);
			Destroy(gameObject);
		}
	}
}
