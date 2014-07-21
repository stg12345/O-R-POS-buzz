using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelMaster : MonoBehaviour {
	//public GameObject beginner;
	int counter;
 	public	GameObject lastInstantiated;
	GameObject ParentPipe;
	Vector2 iPosition;
	public GameObject[] p = new GameObject[2];
	public Vector2 ball_loc;
	public GameObject ballprefab;
	int ballcounter = 1;
	//public GameObject jumpobj;
	int score = 0;
	public string Score = "0";
	//public List<GameObject> currentobjects = new List<GameObject>();
	public GameObject lightning;
	//public GUIText scorecard1;
	//public GUIText scorecard2;
	public Texture scoreboard;
	public GameObject scrollupimg;
	public GameObject scrolldownimg;
	public GameObject scrollimg;
	bool gamebegan = false;
	public GUIStyle SCStyle; //Score Styling for numbers
	//Vector2 offset = new Vector2(2,2 );
	float ratio = 10;
	TextAsset highscore;
	//public GameObject scoreobject;
	private int bestscore;

//	string FileLoc = "\Resources\HighScores.txt";
	// Use this for initialization
	void Awake()
	{
		PlayerPrefs.SetInt("Score",score);
		bestscore = PlayerPrefs.GetInt("BestScore");

	}
	void Start () {

		counter = 4;
		Time.timeScale = 1;
		ParentPipe = GameObject.FindGameObjectWithTag("ParentPipe");
		//lastInstantiated = GameObject.FindGameObjectWithTag("LastInstantiated");
		//scorecard = (GUIText)GameObject.FindGameObjectWithTag("scorecard");
		float finalSize = (float)Screen.width/ratio;
		//scorecard1.fontSize = (int) finalSize;
		//scorecard1.pixelOffset =  new Vector2(Screen.width/offset.x, Screen.height/offset.y);
		//scoreboard.transform.position = new Vector2(Screen.width/, Screen.height*0.2f);
		 SCStyle.fontSize = (int) finalSize;


	}
	
	// Update is called once per frame
	void Update () 
	{

		if(counter < 4)
		{
			GetPosition();

			InstantiatePipe();
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
				Application.LoadLevel("MainMenu");
		  }
			if(gamebegan == true)
			{
				Destroy(scrollupimg);
				Destroy(scrollimg);
				Destroy(scrolldownimg);
			}
		}

	}
	void OnPauseGame()
	{
		/*
    Object[] objects = FindObjectsOfType (typeof(GameObject));
    foreach (GameObject go in objects) {
    go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
    }
    */
	}

	void OnResumeGame()
	{

	}

	void ReduceCounter()
	{
		this.counter -= 1;
		Debug.Log (counter);
	}
	void SetGameBeganVariable()
	{
		this.gamebegan = true;
		Object[] pipeobjects = FindObjectsOfType (typeof(Pipe));
		foreach (GameObject go in pipeobjects) {
			go.SendMessage ("UpdateSpeed");
		}

	}
	void InstantiatePipe()
	{	
		//Debug.Log("IP");
		int r = Random.Range(0,2);
		Debug.Log(lastInstantiated.transform.position);
		lastInstantiated = Instantiate(p[r], iPosition, Quaternion.identity) as GameObject;
		//currentobjects.Add(lastInstantiated);
		this.counter +=1;
	}

	void GetPosition()
	{
		//lastInstantiated.SendMessage("RetrievePosition");

		foreach (Transform t in lastInstantiated.transform)
		{	
			if(t.tag == "TailOb")
			{	Debug.Log(t.position);
				//levelmaster.SendMessage("ChangePosition", (Vector2) t.position);
				iPosition = t.position;

			}
		}
	}

	void GetBallLoc(Vector3 BL)
	{
		ball_loc = (Vector2) BL;

	}
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

	void JumpObjManager()
	{
		//jumpobj.SetActive(true);
	}

	void LoadLoserBaby()
	{
		Application.LoadLevel("LoserBaby");
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
			PlayerPrefs.SetInt("bestscore", bestscore);

		}
	}

	void OnGUI()
	{

		GUI.Label(new Rect(Screen.width*0.2f, Screen.height*0.08f, Screen.width*0.2f, Screen.height*0.1f),Score,new GUIStyle (SCStyle));
	}

	/*void ChangePosition(Vector2 v)
	{
		iPosition = v;
		Debug.Log("Change Pos");
	}*/



}