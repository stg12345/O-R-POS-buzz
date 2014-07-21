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
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
		{
			if (newgame.HitTest(Input.GetTouch(0).position))
			{
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
