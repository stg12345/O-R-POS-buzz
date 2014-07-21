using UnityEngine;
using System.Collections;

public class GUIAspectRatio : MonoBehaviour {
	public Vector2 scaleOnRatio = new Vector2(0.1f,0.1f);
	private Transform myTrans;
	private float widthHeightRatio;
	// Use this for initialization
	void Start () {
		myTrans = transform;
		SetScale();
	}
	
	// Update is called once per frame

	void SetScale()
	{
		widthHeightRatio = (float)Screen.width/Screen.height;
		myTrans.localScale = new Vector3(scaleOnRatio.x, widthHeightRatio * scaleOnRatio.y, 1);
	}

}
