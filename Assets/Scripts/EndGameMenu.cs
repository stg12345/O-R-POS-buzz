using UnityEngine;
using System.Collections;

public class EndGameMenu : MonoBehaviour {
	public GUITexture newgame;
	//public GUITexture continuegame;
	public GUITexture leaderboard;
	//public GameObject levelmaster;
	public GUIStyle style;
	float ratio = 10;
	float finalSize ;
	public GUIText scorecard;
	public GUIText bestcard;
	//public GameObject scoreobject;
	int score,bestscore;
	GameObject googleadsobject;
	// Use this for initialization
	void Awake()
	{
		//scoreobject = GameObject.FindGameObjectWithTag("ScoreObject");
		//this.Score = scoreobject.GetComponent("score").score;

		score = PlayerPrefs.GetInt("Score");
		bestscore = PlayerPrefs.GetInt("BestScore");
	}

	void Start () {
		scorecard.text = score.ToString();
		bestcard.text = bestscore.ToString();
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
				Application.LoadLevel("MainLevelDemo");
			}
			if(leaderboard.HitTest(Input.GetTouch(0).position))
			{
				
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
	}


}
