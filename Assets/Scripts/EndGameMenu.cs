using UnityEngine;
using System.Collections;

public class EndGameMenu : MonoBehaviour {
	public GUITexture newgame;
	//public GUITexture continuegame;
	public GUITexture leaderboard;
	public GUITexture facebookshare;
	//public GameObject levelmaster;
	public GUIStyle style;
	float ratio = 10;
	float finalSize ;
	public GUIText scorecard;
	public GUIText bestcard;
	//public GameObject scoreobject;
	int score,bestscore;
	GameObject googleadsobject;
	FacebookObject facebookobject;
	GameStateManager gamestatemanager;
	// Use this for initialization
	void Awake()
	{
		//scoreobject = GameObject.FindGameObjectWithTag("ScoreObject");
		//this.Score = scoreobject.GetComponent("score").score;

		/*
		if(FB.IsLoggedIn)
		{
		facebookobject = (FacebookObject) GameObject.FindGameObjectWithTag("FacebookObject").GetComponent("FacebookObject");
		
		}
		else
		{
			bestscore = 0;
		}
		*/
		gamestatemanager = (GameStateManager) GameObject.FindGameObjectWithTag("GameStateManager").GetComponent("GameStateManager");
		facebookobject = (FacebookObject) GameObject.FindGameObjectWithTag("FacebookObject").GetComponent("FacebookObject");
	}

	void Start () {
		scorecard.text = GameStateManager.Score.ToString();
		if(GameStateManager.myBest == 10000)
		{
			bestcard.text = "Login to save";
		}
		else if(GameStateManager.myBest < 10000)
		{
			bestcard.text = GameStateManager.myBest.ToString();
		}

		finalSize = (float) Screen.width/ratio;
		bestcard.fontSize = (int) finalSize;
		scorecard.fontSize = (int) finalSize;
		googleadsobject = GameObject.FindGameObjectWithTag("GoogleAdsObject");
		googleadsobject.SendMessage("destroyInterstitialAd", SendMessageOptions.DontRequireReceiver);
		if(googleadsobject != null)
		{
			googleadsobject.SendMessage("RequestBanner", SendMessageOptions.DontRequireReceiver);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
		{
			if (newgame.HitTest(Input.GetTouch(0).position))
			{
				googleadsobject.SendMessage("addPlayCount",SendMessageOptions.DontRequireReceiver);
				googleadsobject.SendMessage("hideBannerAd",SendMessageOptions.DontRequireReceiver);
				googleadsobject.SendMessage("destroyBannerAd",SendMessageOptions.DontRequireReceiver);
				//Reset Game Score
				GameStateManager.Score = 0;
				//Retrieving score from facebook
				gamestatemanager.getScore();

				Application.LoadLevel("MainLevelDemo");
			}
			if(leaderboard.HitTest(Input.GetTouch(0).position))
			{
				
			}
			if(facebookshare.HitTest(Input.GetTouch(0).position))
			{
				facebookobject.onBragClicked();
			}


			/*if (continuegame.HitTest(Input.GetTouch(0).position))
			{
				//levelmaster.SendMessage("GameResume");

			}*/
		}
		if (Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
		#if UNITY_EDITOR
		if(facebookshare.HitTest(Input.mousePosition))
		{
			Debug.Log("facebookShare");
			facebookobject.onBragClicked();
		}
		#endif
	}


}
