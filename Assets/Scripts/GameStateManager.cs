using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using System;

public class GameStateManager : MonoBehaviour {
	public static Texture UserTexture;
	public static string Username;
	public static int Score;
	public static int myBest;
	FacebookObject facebookobject;
	// Use this for initialization

	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	void Start () {
		facebookobject = (FacebookObject) GameObject.FindGameObjectWithTag("FacebookObject").GetComponent("FacebookObject");
		}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine("bestScoreUpdater");
	}

	public void setScore(int s)
	{
		Debug.Log("setScore Method");
		// Saving player score
		int score = s;
		//myBest = s;
		var ScoreData =  new Dictionary<string, string>() {{"score", score.ToString()}};
		FB.API("/me/scores", Facebook.HttpMethod.POST, publishActionCallback, ScoreData);
		
	}
	
	public void getScore()
	{
		Debug.Log("getScoreMethod");

		FB.API(FB.AppId+"/scores", Facebook.HttpMethod.GET, CallbackMyScore);
	}
	
	void CallbackMyScore(FBResult result)
	{
		Debug.Log("CallBackMyScore method");
		List<object> scoresList = Util.DeserializeScores(result.Text);
		foreach(object score in scoresList)
		{
			var entry = (Dictionary<string,object>) score;
			var user = (Dictionary<string,object>) entry["user"];
			string name = (string)user["name"];
			string  myScore = ""+entry["score"];
			string userId = (string)user["id"];
			if (string.Equals(userId,FB.UserId))
			{
				if(myScore.Equals("0"))
				{
					myBest= 10000;
					Debug.Log(name+"OK"+myBest+"score:"+myScore);
				}
				else
				{
					myBest = Int32.Parse(myScore);
					Debug.Log(name+"OK"+myBest+"score:"+myScore);
				}
				//myBest = myScore;

			}
			Debug.Log(name+"OK"+myBest+"score:"+myScore);
		}
	}
	
	void publishActionCallback(FBResult result)
	{
		
	}

	public void AddScoreFbLoggedIn()
	{

		Score += 1;
		//scorecard1.text = score.ToString();
		//Debug.Log(score);
		//Score = score.ToString();

		//scoreobject.SendMessage("UpdateScore",Score);
		//PlayerPrefs.SetInt("Score",score);
		if(FB.IsLoggedIn)
		{
			if(Score > 0 && myBest < Score)
			{
				myBest = Score;
				setScore(Score);
			}
		}
	}

	public void AddScore()
	{
		Score += 1;
	}

	IEnumerable bestScoreUpdater()
	{

		if(FB.IsLoggedIn)
		{	//bestscore = facebookobject.GetMyBest();
			getScore();
			Debug.Log(myBest + "is my best score");
		}

		yield return new WaitForSeconds(5);


	}


}
