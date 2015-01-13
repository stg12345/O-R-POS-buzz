using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelMaster : MonoBehaviour {
	//public GameObject beginner;
	public int counter;
 	public	GameObject lastInstantiated;
	GameObject ParentPipe;
	//Vector2 iPosition;
	public GameObject[] p = new GameObject[2];
	public Vector2 ball_loc;
	public GameObject ballprefab;
	int ballcounter = 1;
	bool gameover = false;
	//public GameObject jumpobj;
	int score;
	public string Score = "0";
	//public List<GameObject> currentobjects = new List<GameObject>();
	public GameObject lightning;
	//public GUIText scorecard1;
	//public GUIText scorecard2;
	public Texture scoreboard;
	public GameObject scrollupimg;
	public GameObject scrolldownimg;
	public GameObject scrollimg;
	public static string Username;
	public static Texture UserTexture;
	bool gamebegan = false;
	public GUIStyle SCStyle; //Score Styling for numbers
	//Vector2 offset = new Vectorload2(2,2 );
	float ratio = 10;
	TextAsset highscore;
	//public GameObject scoreobject;
	public int bestscore;
	public Object[] pipeobjectsarray;
	float stopspeed=0;
	float startspeed = 0.7f;
	public GameObject googleadsobject;

//	string FileLoc = "\Resources\HighScores.txt";
	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this);
		bestscore = PlayerPrefs.GetInt("BestScore");

	}
	void Start () {
		score = 0;
		counter = 4;
		Time.timeScale = 1;
		//ParentPipe = GameObject.FindGameObjectWithTag("ParentPipe");
		//lastInstantiated = GameObject.FindGameObjectWithTag("LastInstantiated");
		//scorecard = (GUIText)GameObject.FindGameObjectWithTag("scorecard");
		float finalSize = (float)Screen.width/ratio;
		//scorecard1.fontSize = (int) finalSize;
		//scorecard1.pixelOffset =  new Vector2(Screen.width/offset.x, Screen.height/offset.y);
		//scoreboard.transform.position = new Vector2(Screen.width/, Screen.height*0.2f);
		 SCStyle.fontSize = (int) finalSize;
	 	pipeobjectsarray = FindObjectsOfType (typeof(Pipe));
		foreach (Pipe go in pipeobjectsarray) {
			go.SendMessage ("UpdateSpeed",stopspeed);
	}
		googleadsobject = GameObject.FindGameObjectWithTag("GoogleAdsObject");
		googleadsobject.SendMessage("requestInterstitialAd", SendMessageOptions.DontRequireReceiver);
	}
	// Update is called once per frame
	void Update () 
	{

		if(counter < 4)
		{
			Vector2 ipos = GetPosition();
			InstantiatePipe(ipos);
		}
		if (Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
		  	{
			/*	if(jumpobj.active)
	 		  	{
					TimeScaleManager(0);
					jumpobj.SetActive(true);
		      	}
			if(jumpobj.active)
			{
				TimeScaleManager(1);
				jumpobj.SetActive(false);
			}
				return;*/
				gameover = true;
				Application.LoadLevel("MainMenu");
		  }
		}
			if(gamebegan == true)
			{
				GameObject.DestroyObject(scrollupimg);
				GameObject.DestroyObject(scrollimg);
				GameObject.DestroyObject(scrolldownimg);
			}


	}
	/*void OnPauseGame()
	/*{
		/*
    Object[] objects = FindObjectsOfType (typeof(GameObject));
    foreach (GameObject go in objects) {
    go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
    }
	
	}*/

	void ReduceCounter()
	{
		this.counter -= 1;
	
	}

	void setGameOver()
	{
		this.gameover = true;

	}

	void SetGameBeganVariable()
	{
		this.gamebegan = true;

		foreach (Pipe go in pipeobjectsarray) {
			go.SendMessage ("UpdateSpeed", startspeed);
		}

	}
	void InstantiatePipe(Vector2 v2)
	{	

		if(counter == 3)
		{
		//Debug.Log("IP");
		Debug.Log ("counter" +counter);
		int r = Random.Range(0,2);
		Debug.Log(lastInstantiated.transform.position);
		lastInstantiated = Instantiate(p[r], v2, Quaternion.identity) as GameObject;
		this.counter +=1;
		//currentobjects.Add(lastInstantiated);
		}


	}

	Vector2 GetPosition()
	{
		//lastInstantiated.SendMessage("RetrievePosition");
		Vector2 ipos = new Vector2(0,0);
		foreach (Transform t in lastInstantiated.transform)
		{	
			if(t.tag == "TailOb")
			{	Debug.Log(t.position);
				//levelmaster.SendMessage("ChangePosition", (Vector2) t.position);
				//iPosition = t.position;
				ipos = t.position;
			}

		}
		return ipos;
	}

	/*void GetBallLoc(Vector3 BL)
	{
		ball_loc = (Vector2) BL;

	}*/
	/*void GameResume()
	{
		if(ballcounter < 1)
		{
			ballcounter += 1;
			Instantiate (ballprefab, ball_loc, Quaternion.identity);

			//jumpobj.SetActive(false);
			
		}

		/*for(int i =0; i<= currentobjects.Count;i++)
		{
			//currentobjects[i].SendMessage("
		}
			
	}
	/*void BallsReducer()
	{
		ballcounter -= ballcounter;
	}*/

	/*void CurrentObjectManager()
	{
		currentobjects.RemoveAt(0);
		//Sort the list
		for(int i = 0; i <= currentobjects.Count; i++)
		{
			currentobjects[i-1] = currentobjects[i];
		}*/

	/*void JumpObjManager()
	{
		//jumpobj.SetActive(true);
	}*/

	void LoadLoserBaby()
	{
		//googleadsobject.SendMessage("requestInterstitialAd", SendMessageOptions.DontRequireReceiver);
		//googleadsobject.SendMessage("RequestBanner", SendMessageOptions.DontRequireReceiver);

		Application.LoadLevel("LoserBaby");
		googleadsobject.SendMessage("displayInterstitialAd", SendMessageOptions.DontRequireReceiver);

	}

	void AddScore()
	{
		score += 1;
		//scorecard1.text = score.ToString();
		//Debug.Log(score);
		Score = score.ToString();

		//scoreobject.SendMessage("UpdateScore",Score);
		PlayerPrefs.SetInt("Score",score);
		if(bestscore < score)
		{
			bestscore = score;
			PlayerPrefs.SetInt("BestScore", bestscore);
			PlayerPrefs.Save();
		}
	}

	public void resetScore()
	{
		this.score = 0;
	}


	void OnGUI()
	{

		if(gameover ==  false)
		{
			GUI.Label(new Rect(Screen.width*0.2f, Screen.height*0.08f, Screen.width*0.2f, Screen.height*0.1f),Score, (SCStyle));
		}
	}

	/*void ChangePosition(Vector2 v)
	{
		iPosition = v;
		Debug.Log("Change Pos");
	}*/



}