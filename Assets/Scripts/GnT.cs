using UnityEngine;
using System.Collections;

public class GnT : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		animator.speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update (){
	}
}