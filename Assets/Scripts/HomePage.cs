using UnityEngine;
using System.Collections;

public class HomePage : MonoBehaviour {
	public GUITexture playbutton;
	public GUITexture ratingstar;
	public GUITexture leaderboard;
	//public AudioClip mainmenumusic;
	// Use this for initialization
	void Start () {
		audio.Play();
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

			}

			if(ratingstar.HitTest(Input.GetTouch(0).position))
			{
				Application.OpenURL ("http://www.google.com");
			}
		}
		if (Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}

	/* void OnGUI()
	{
		//GUI.skin = mainmenugui;
		if(GUI.Button(new Rect(50,50,100,20),"Hello"))
			GT.SetActive(true);
	}*/
}
