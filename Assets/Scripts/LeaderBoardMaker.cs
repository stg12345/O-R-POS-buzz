using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderBoardMaker : MonoBehaviour {

	public GameObject photo, name, score;
	public Rect photorect;
	public Rect namerect;
	public Rect scorerect;
	public GUIStyle guistyle;
	public float ratio;
	// Use this for initialization
	void Start () {
		getLeaderBoard();
		photorect = new Rect (Screen.width * 5/100, Screen.height *10/100, Screen.width * 10/100,Screen.height *20/100);
		namerect = new Rect (Screen.width * 23/100, Screen.height *10/100, Screen.width * 40/100,Screen.height *50/100);
		scorerect = new Rect (Screen.width * 72/100, Screen.height *10/100, Screen.width * 10/100,Screen.height *10/100);

		float finalSize = (float)Screen.width/ratio;
		//scorecard1.fontSize = (int) finalSize;
		//scorecard1.pixelOffset =  new Vector2(Screen.width/offset.x, Screen.height/offset.y);
		//scoreboard.transform.position = new Vector2(Screen.width/, Screen.height*0.2f);
		guistyle.fontSize = (int) finalSize;
	}
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.LoadLevel("MainMenu");
			}
		}
	}

	void OnGUI()
	{
		GUI.Label(photorect,"Photo",guistyle);
		GUI.Label(namerect,"Full Name Here",guistyle);
		GUI.Label(scorerect,"Score",guistyle);
	}

	void getLeaderBoard()
	{
		FB.API("app/scores", Facebook.HttpMethod.GET, CallbackAllScores);
	}

	void CallbackAllScores(FBResult result)
	{
		//FriendScores = new List<object>();
		List<object> FriendScoresList = Util.DeserializeScores(result.Text);

		foreach(object score in FriendScoresList)
		{
			bool fbScoreExists = false;
			var entry = (Dictionary<string,object>) score;
			var user = (Dictionary<string,object>) entry["user"];
			string name = (string)user["name"];
			string userId = (string)user["id"];
			Debug.Log(name+":"+userId);
	}
}
}