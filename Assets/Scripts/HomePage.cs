using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class HomePage : MonoBehaviour {
	public GUITexture playbutton;
	public GUITexture ratingstar;
	public GUITexture leaderboard;
	public GUITexture facebookbutton;
	GameObject facebookobject;
	public GUIText googleloginstate;

	//public AudioClip mainmenumusic;
	// Use this for initialization

	void Start () {
		audio.Play();
		PlayGamesPlatform.Activate();
		googleloginstate.enabled = false;

		facebookobject = GameObject.FindGameObjectWithTag("FacebookObject");
		Social.localUser.Authenticate((bool success) => 
		                              {
			if(!success)
			{
				StartCoroutine(popUpTest("Google Login failed..",5));
			}
			
			else
			{
				StartCoroutine(popUpTest("Google Logged in Successfully!",5));
			}
		});
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
				PlayGamesPlatform.Instance.ShowLeaderboardUI(GameStateManager.leaderboardid);
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
		if (playbutton.HitTest(Input.mousePosition))
		{
			//testtouch.text = "touched";
			Application.LoadLevel("MainLevelDemo");
		}

		if(Input.GetKey(KeyCode.L))
		{
			Application.LoadLevel("LeaderboardScene");
		}
		#endif

	

	}

IEnumerator popUpTest(string msg, float delay)
	{
		googleloginstate.fontSize =  Screen.width/30;
		googleloginstate.text = msg;
		googleloginstate.enabled = true;
		yield return new WaitForSeconds(delay);
		googleloginstate.enabled = false;
	}

}