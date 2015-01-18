using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using System;

public class FacebookObject : MonoBehaviour {
	public GUIText user;

	//public GUIText debuggertext;
	private string  myScore;
	private string popupMessage;
	public string myBest;
	private float popupTime;
	private float popupDuration;
	private float ChallengeDisplayTime;
	private static Dictionary<string, string> profile = null;
	public GameObject gsm;

	void Awake()
	{
		DontDestroyOnLoad(this);
		FB.Init(SetInit, OnHideUnity);
		ChallengeDisplayTime = 3.4f;
	}


	protected void SetInit()
	{
		Debug.Log("Initialized");

		if(FB.IsLoggedIn)
		{
			OnLoggedIn();

		}
#if UNITY_EDITOR
		else
		{
			FBLogin();
		}
#endif
	}


	public void facebookLogin()
	{
		if(!FB.IsLoggedIn)
		{
			FBLogin();
		}


	}

	protected void OnHideUnity(bool isGameShown)
	{
		if(isGameShown)
		{
			Time.timeScale = 1.0f;
		}
		else
		{
			Time.timeScale = 0;
		}
	}

	protected void FBLogin()
	{

		FB.Login("publish_actions,user_about_me,user_games_activity,friends_games_activity", AuthCallBack);
	}

	protected void AuthCallBack(FBResult result)
	{
		Debug.Log("Authcallback");
		if (FB.IsLoggedIn)
		{
			OnLoggedIn();
		}
	}

	void OnLoggedIn()
	{
		Util.Log("Logged in. ID: " + FB.UserId);
		
		// Reqest player info and profile picture                                                                           
		FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);  
		//LoadPictureAPI(Util.GetPictureURL("me", 128, 128),MyPictureCallback);    


	}
	void APICallback(FBResult result)                                                                                              
	{                                                                                                                              
		Util.Log("APICallback");                                                                                                
		if (result.Error != null)                                                                                                  
		{                                                                                                                          
			Util.LogError(result.Error);                                                                                           
			// Let's just try again        
			Debug.Log("reached error");
			FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);     
			return;                                                                                                                
		}                                                                                                                          
		
		profile = Util.DeserializeJSONProfile(result.Text);                                                                        
		GameStateManager.Username = profile["first_name"];

		user.text = "Welcome " + profile["first_name"];

		//debuggertext.text = "reached debugger text";
		//friends = Util.DeserializeJSONFriends(result.Text);

		//setScore(UnityEngine.Random.Range(20,40));
	}                                                                                                                              


	void MyPictureCallback(Texture texture)                                                                                        
	{                                                                                                                             
		Util.Log("MyPictureCallback");                                                                                          
		
		if (texture == null)                                                                                                  
		{                                                                                                                          
			// Let's just try again
			LoadPictureAPI(Util.GetPictureURL("me", 128, 128),MyPictureCallback);                               
			return;                                                                                                                
		}                                                                                                                          
		GameStateManager.UserTexture = texture;                                                                             
	} 

	void LoadPictureAPI (string url, LoadPictureCallback callback)
	{
		FB.API(url,Facebook.HttpMethod.GET,result =>
		       {
			if (result.Error != null)
			{
				Util.LogError(result.Error);
				return;
			}
			var imageUrl = Util.DeserializePictureURLString(result.Text);
			StartCoroutine(LoadPictureEnumerator(imageUrl,callback));
		});
	}

	delegate void LoadPictureCallback (Texture texture);

	IEnumerator LoadPictureEnumerator(string url, LoadPictureCallback callback)
	{
		WWW www = new WWW(url);
		yield return www;
		callback(www.texture);
	}




	public int GetMyBest()
	{
		int temp;
		Int32.TryParse(myBest, out temp);
		return temp;
	}



	private void onChallengeClicked()                                                                                              
	{ 
		FB.AppRequest(
			message: "Buzzinga is smashing! Check it out.",

			callback:appRequestCallback
			);                                                                                                                
		
	}                                                                                                                              
	private void appRequestCallback (FBResult result)                                                                              
	{                                                                                                                              
		Util.Log("appRequestCallback");                                                                                         
		if (result != null)                                                                                                        
		{                                                                                                                          
			var responseObject = Json.Deserialize(result.Text) as Dictionary<string, object>;                                      
			object obj = 0;                                                                                                        
			if (responseObject.TryGetValue ("cancelled", out obj))                                                                 
			{                                                                                                                      
				Util.Log("Request cancelled");                                                                                  
			}                                                                                                                      
			else if (responseObject.TryGetValue ("request", out obj))                                                              
			{                
				AddPopupMessage("Request Sent", ChallengeDisplayTime);
				Util.Log("Request sent");                                                                                       
			}                                                                                                                      
		}                                                                                                                          
	}

	public void AddPopupMessage(string message, float duration)
	{
		popupMessage = message;
		popupTime = Time.realtimeSinceStartup;
		popupDuration = duration;
	}

	public void DrawPopupMessage()
	{
		if (popupTime != 0 && popupTime + popupDuration > Time.realtimeSinceStartup)
		{
			// Show message that we sent a request
			Rect PopupRect = new Rect();
			PopupRect.width = 800;
			PopupRect.height = 100;
			PopupRect.x = Screen.width / 2 - PopupRect.width / 2;
			PopupRect.y = Screen.height / 2 - PopupRect.height / 2;
			GUI.Box(PopupRect,"");
			GUI.Label(PopupRect, popupMessage);
		}
	}

	public void onPlayClicked()
	{

	}

	private void onBragClicked()                                                                                                 
	{                                                                                                                            
		Util.Log("onBragClicked");                                                                                            
		FB.Feed(                                                                                                                 
		        linkCaption: "I just scored " + GameStateManager.Score.ToString() + " ! Can you beat it?",               
		        picture: "http://www.friendsmash.com/images/logo_large.jpg",                                                     
		        linkName: "Checkout my Buzzinga greatness!",                                                                 
		        link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")       
		        );                                                                                                               
	}



	void OnGUI()
	{
		/*if (GameStateManager.UserTexture != null)
		{
			GUI.DrawTexture( (new Rect(8,10, 100, 100)), GameStateManager.UserTexture);
		}*/
		/*if (GUI.Button(new Rect(28,20, 100, 50),"Play"))
		{
			onPlayClicked();
		}*/
		/*if (FB.IsLoggedIn)                                                   
		{                                                                    
			if (GUI.Button (new Rect(138,20, 100, 50),"Challenge"))                   
			{                                                                
				onChallengeClicked();                                        
			}                                                                
		}*/
		/*
		if (GameStateManager.Score > 0)                             
		{                                                           
			if (GUI.Button(new Rect(248,20,100,50),"Brag"))                    
			{                                                       
				onBragClicked();                                    
			}                                                       
		} */ 
		/*if(GUI.Button( new Rect(100,50,100,50),"StartAds"))
		{
			Instantiate(googleadobject, new Vector2(50,50),Quaternion.identity);
		}

		if(GUI.Button(new Rect(500,50,200,100),"Story"))
		   {
			//Use this to add friends before hand
			string[] friendlist = new string [2] {"1151650321"," 100001260892367"};
			if (FB.IsLoggedIn)
			{
					FB.AppRequest(
					message: "Come play this great game!", 
					to  :friendlist,
					filters : null,
					excludeIds : null,
					maxRecipients : null,
					data: "{\"challenge_score\":" + "45" + "}",
					title: "Friend Smash Challenge!",
					callback: appRequestCallback
					);

			}
		}

		if(GUI.Button(new Rect(10,20,100,100),"Logout"))
		   {
			FB.Logout();
		}*/
	}
}
