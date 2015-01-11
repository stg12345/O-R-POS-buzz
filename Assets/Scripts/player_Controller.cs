using UnityEngine;
using System.Collections;

public class player_Controller : MonoBehaviour {
	//Vector2 MagnitudeVector;
	float Speed = 20;
	private Animator animator;
	public bool GameOver = false;
	public LevelMaster levelmaster;
	Vector2 ball_loc;
	//public AudioClip fast;
	public AudioClip gameoverbuzz;
	//public AudioClip slow;
	Collider2D Other;
	bool gamebeginmsgsent;
	// Use this for initialization
	void Start () {
		/*animator = this.GetComponent<Animator>();

		if(GameOver == false)
		{
			//animator.SetInteger("BallState",0);

		}*/

	}
	
	// Update is called once per frame
	void Update () {
		/**/


}
	void FixedUpdate()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
		{
			if(!gamebeginmsgsent == true)
			{
				levelmaster.SendMessage("SetGameBeganVariable");
				gamebeginmsgsent = true;
				levelmaster.resetScore();

			}
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		{
			if(!gamebeginmsgsent == true)
			{
				levelmaster.SendMessage("SetGameBeganVariable");
				gamebeginmsgsent = true;
				
			}
		}

		if(gamebeginmsgsent == true)
		{
			if(GameOver == false)
			{
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			//MagnitudeVector = (Input.GetTouch(0).deltaPosition/Input.GetTouch(0).deltaTime);
			transform.Translate(new Vector3(0,1,0) * Speed * Time.deltaTime * Input.GetTouch(0).deltaPosition.y/30);
			}
			}
		}


		if (Input.GetButton("Jump"))
		{
			levelmaster.SendMessage("SetGameBeganVariable");
			gamebeginmsgsent = true;
			//audio.Play();

		}
	}
	IEnumerator OnCollisionEnter2D(Collision2D other)
	{	
		if(other.gameObject.layer == 8)
		{	
			AudioSource.PlayClipAtPoint(gameoverbuzz,this.transform.position);
			Handheld.Vibrate();
			GameOver = true;
			levelmaster.SendMessage("setGameOver");
			PlayerPrefs.Save();
			
			//gameObject.rigidbody2D.gravityScale = 15;
			//gameObject.rigidbody2D.isKinematic = false;
			//levelmaster.SendMessage("JumpObjManager");
			//levelmaster.SendMessage("GetBallLoc",ball_loc);
			//levelmaster.SendMessage("CurrentObjectManager");
			//levelmaster.SendMessage("TimeScaleManager", 0f);

			if(GameOver == true)
			{
				//animator.SetInteger("BallState",1);
			}
			yield return new WaitForSeconds(0.7f);

			Destroy(gameObject);
			levelmaster.SendMessage("LoadLoserBaby");
			GameObject.Destroy(levelmaster);
			}

		/*if(other.gameObject.layer ==12)
		{
			audio.Stop();
			audio.PlayOneShot(gameoverbuzz);
			//other.SendMessage("PlayAudio");
			//audio.PlayOneShot(fast);
			//audio.PlayDelayed(3);
		}*/
	}

	}
	



	