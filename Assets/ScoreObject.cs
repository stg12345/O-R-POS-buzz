using UnityEngine;
using System.Collections;

public class ScoreObject : MonoBehaviour {
	public string score;

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateScore(string sc)
	{
		this.score = sc;
	}
	void ReturnScore()
	{

	}
}
