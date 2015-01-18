using UnityEngine;
using System.Collections;

public class HomePage : MonoBehaviour {
	public GUITexture playbutton;
	public GUITexture ratingstar;
	public GUITexture leaderboard;
	public GUITexture facebookbutton;
	GameObject facebookobject;
	//public AudioClip mainmenumusic;
	// Use this for initialization

	void Start () {
		audio.Play();
		facebookobject = GameObject.FindGameObjectWithTag("FacebookObject");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
		{
			if (playbutton.HitTest(Input.GetTouch(0).position))
			{
				//testtouch.text = "touched";
				Application.LoadLevel("MainLevelDemo");
			}
			if(leaderboard.HitTest(Input.GetTouch(0).position))
			{
				Application.LoadLevel("LeaderBoardScene");
			}

			if(ratingstar.HitTest(Input.GetTouch(0).position))
			{
				Application.OpenURL ("http://www.google.com");
			}

			if(facebookbutton.HitTest(Input.GetTouch(0).position))
			{
				audio.Play();
				facebookobject.SendMessage("facebookLogin",SendMessageOptions.DontRequireReceiver);
			}

		if (Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}
#if UNITY_EDITOR
		if(Input.GetKey(KeyCode.E))
		   {
			Application.LoadLevel("MainLevelDemo");
			}
#endif

	

	}}