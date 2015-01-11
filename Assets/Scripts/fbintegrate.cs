using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fbintegrate : MonoBehaviour {
//	public GUIText loggedin;
	/*
	Facebook.HideUnityDelegate onHideUnity;
	Facebook.InitDelegate onInitComplete;
	//Facebook FB = new Facebook();
	string authresponse = null;
	public GUISkin MenuSkin;  
	public Rect LoginButtonRect;
	public GUIText onloggedin;
	enum LoadingState 
	{
		WAITING_FOR_INIT,
		WAITING_FOR_INITIAL_PLAYER_DATA,
		DONE
	};

	private static List<object>                 friends         = null;
	private static Dictionary<string, string>   profile         = null;
	private static List<object>                 scores          = null;
	private static Dictionary<string, Texture>  friendImages    = new Dictionary<string, Texture>();
	
	private LoadingState loadingState = LoadingState.WAITING_FOR_INIT;
	// Use this for initialization
	void Start () {

			
	}
	void Awake() {
		// Initialize FB SDK              
		enabled = false;                  
		FB.Init(SetInit, OnHideUnity); 
	}
	// Update is called once per frame
	void Update () {
	
		if(FB.IsLoggedIn)
		{
			Debug.Log("Logged in");
			//loggedin.text = onInitComplete.ToString();
		}
		else
		{
			Debug.Log("Not yet");
			//loggedin.text = "no, not yet big guy!";
		}
	}

	void OnGUI()
	{
		GUI.skin = MenuSkin;
		if (GUI.Button(new Rect(50,50,220,60),"Facebook Init"))
		    {
		    FB.Init( onInitComplete, onHideUnity, authresponse);
		}
		if (GUI.Button(new Rect(100,100,220,60),"Facebook Login"))
		{
			FB.Login("email,publish_actions", LoginCallback);

		}
		if (!FB.IsLoggedIn)                                                                                              
		{                                                                                                                
			GUI.Label((new Rect(179 , 11, 287, 160)), "Login to Facebook", MenuSkin.GetStyle("text_only"));             
			if (GUI.Button(LoginButtonRect, "", MenuSkin.GetStyle("button_login")))                                      
			{                                                                                                            
				FB.Login("email,publish_actions", LoginCallback);                                                        
			}                                                                                                            
		}    
	}



	void LoginCallback(FBResult result)
	{
		Util.Log("LoginCallback");                                                          
		
		if (FB.IsLoggedIn)                                                                     
		{                                                                                      
			OnLoggedIn();                                                                      
		}               
	}
	private void SetInit()                                                                       
	{
		Util.Log("SetInit");
		enabled = true; // "enabled" is a property inherited from MonoBehaviour
		if (FB.IsLoggedIn) 
		{
			Util.Log("Already logged in");
			OnLoggedIn();
			loadingState = LoadingState.WAITING_FOR_INITIAL_PLAYER_DATA;
		}
		else
		{
			loadingState = LoadingState.DONE;
		}
	}                                                                                   
	
	private void OnHideUnity(bool isGameShown)                                                   
	{                                                                                            
		Util.Log("OnHideUnity");                                                              
		if (!isGameShown)                                                                        
		{                                                                                        
			// pause the game - we will need to hide                                             
			Time.timeScale = 0;                                                                  
		}                                                                                        
		else                                                                                     
		{                                                                                        
			// start the game back up - we're getting focus again                                
			Time.timeScale = 1;                                                                  
		}                                                                                        
	}    
	void OnLoggedIn()                                                                          
	{                                                                                          
		/*Util.Log("Logged in. ID: " + FB.UserId);
		
		// Reqest player info and profile picture                                                                           
		FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);  
		LoadPicture(Util.GetPictureURL("me", 128, 128),MyPictureCallback);   */
//	}                   

/*	void APICallback(FBResult result)                                                                                              
	{                                                                                                                              
		Util.Log("APICallback");                                                                                                
		if (result.Error != null)                                                                                                  
		{                                                                                                                          
			Util.LogError(result.Error);                                                                                           
			// Let's just try again                                                                                                
			FB.API("/me?fields=id,first_name,friends.limit(100).fields(first_name,id)", Facebook.HttpMethod.GET, APICallback);     
			return;                                                                                                                
		}                                                                                                                          
		
		profile = Util.DeserializeJSONProfile(result.Text);                                                                        
		LevelMaster.Username = profile["first_name"];                                                                         
		friends = Util.DeserializeJSONFriends(result.Text);                                                                        
	}                                                                                                                              
	
	void MyPictureCallback(Texture texture)                                                                                        
	{                                                                                                                              
		Util.Log("MyPictureCallback");                                                                                          
		
		if (texture == null)                                                                                                  
		{                                                                                                                          
			// Let's just try again
			LoadPicture(Util.GetPictureURL("me", 128, 128),MyPictureCallback);                               
			return;                                                                                                                
		}                                                                                                                          
		LevelMaster.UserTexture = texture;                                                                             
	}*/   
}
